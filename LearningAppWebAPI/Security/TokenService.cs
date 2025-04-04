using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LearningAppWebAPI.Security;



/// <summary>
/// 
/// </summary>
/// <param name="config"></param>
/// <param name="dbContext"></param>
public class TokenService(IConfiguration config, AppDbContext dbContext) : ITokenService
{
    private string ValidateSigningKey()
    {
        var key = config["Jwt:Key"];
        
        if (string.IsNullOrEmpty(key) || key.Length < 32)
            throw new ApplicationException("Key must be at least 32 characters long");

        return key;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    public TokenResponse GenerateAccessToken(ICollection<Claim> claims)
    {
        return GenerateJwtToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingKey: ValidateSigningKey() 
        );
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    public TokenResponse GenerateRefreshToken(ICollection<Claim> claims)
    {
        return GenerateJwtToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(14),
            signingKey: ValidateSigningKey()
        );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="claims"></param>
    /// <param name="expires"></param>
    /// <param name="signingKey"></param>
    /// <returns></returns>
    public TokenResponse GenerateJwtToken(
        ICollection<Claim> claims,
        DateTime expires,
        string signingKey)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: credentials
        );

        return new TokenResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpiryDate = expires
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public ICollection<Claim> WriteClaims(User? user)
    {
        return
        [
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.RoleName.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        ];
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="token"></param>
    public async Task StoreRefreshTokenAsync(int userId, TokenResponse token)
    {
        var existingTokens = await dbContext.RefreshToken
            .Where(rt => rt.UserId == userId)
            .ToListAsync();

        foreach (var oldToken in existingTokens)
        {
            oldToken.RevokedAt = DateTime.UtcNow;
            oldToken.IsRevoked = true;
        }
        
        var hashedToken = HashToken(token.Token);
        await dbContext.RefreshToken.AddAsync(new RefreshToken
        {
            UserId = userId,
            ExpiryDate = token.ExpiryDate,
            HashedToken = hashedToken
        });
        
        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    public async Task RevokeTokensFromUser(string userId)
    {
       
        var tokens = await dbContext.RefreshToken
            .Where(rt => rt.UserId == int.Parse(userId))
            .ToListAsync();

        foreach (var token in tokens)
        {
            token.IsRevoked = true;
            token.RevokedAt = DateTime.UtcNow;
        }
        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jti"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task BlacklistAccessToken(string jti)
    {
        await dbContext.BlacklistedAccessTokens.AddAsync(new BlacklistedAccessToken()
        {
            Jti = jti,
            ExpiryDate = DateTime.UtcNow.AddDays(1)
        });
        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="jti"></param>
    /// <returns></returns>
    public async Task<bool> IsTokenBlacklisted(string jti)
    {
        return await dbContext.BlacklistedAccessTokens
            .AnyAsync(t => t.Jti == jti && t.ExpiryDate > DateTime.UtcNow);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="expiredAccessToken"></param>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    /// <exception cref="SecurityTokenException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public async Task<TokenResponse> RefreshTokensAsync(string expiredAccessToken, string refreshToken)
    {
        var principal = GetPrincipalFromExpiredToken(expiredAccessToken);
        if (principal == null)
            throw new SecurityTokenException("Invalid access token");
        
        var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
        var jti = principal.FindFirstValue(JwtRegisteredClaimNames.Jti);
    
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(jti))
            throw new SecurityTokenException("Missing required claims");
        
        var isValidRefresh = await ValidateRefreshTokenAsync(int.Parse(userId), refreshToken);
        if (!isValidRefresh)
            throw new SecurityTokenException("Invalid refresh token");
        
        var user = await dbContext.User
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
    
        if (user == null)
            throw new ArgumentException("User not found");
        
        var claims = WriteClaims(user);
        var newAccessToken = GenerateAccessToken(claims);
        
        await BlacklistAccessToken(jti);

        return newAccessToken;
    }

    private static string HashToken(string token)
    {
        return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(token)));
    }
    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ValidateSigningKey())),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            return tokenHandler.ValidateToken(token, tokenValidationParameters, out _);
        }
        catch
        {
            return null;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    private async Task<bool> ValidateRefreshTokenAsync(int userId, string refreshToken)
    {
        var hashedToken = HashToken(refreshToken);
    
        return await dbContext.RefreshToken
            .AnyAsync(rt => 
                rt.UserId == userId &&
                rt.HashedToken == hashedToken &&
                !rt.IsRevoked &&
                rt.ExpiryDate > DateTime.UtcNow);
    }
}