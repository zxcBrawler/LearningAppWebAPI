using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Response;
using LearningAppWebAPI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LearningAppWebAPI.Security;

/// <summary>
/// 
/// </summary>
/// <param name="config"></param>

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
    public ICollection<Claim> WriteClaims(DummyUser user) // change to User entity
    {
        return
        [
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
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

    private static string HashToken(string token)
    {
        return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(token)));
    }
}