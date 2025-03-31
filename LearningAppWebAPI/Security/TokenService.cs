using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LearningAppWebAPI.Utils;
using Microsoft.IdentityModel.Tokens;

namespace LearningAppWebAPI.Security;

/// <summary>
/// 
/// </summary>
/// <param name="config"></param>
[ScopedService]
public class TokenService(IConfiguration config)
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="claims"></param>
    /// <returns></returns>
    /// <exception cref="ApplicationException"></exception>
    public string GenerateToken(IEnumerable<Claim> claims)
    {
        var jwtKey = config["Jwt:Key"];
        if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 32)
        {
            throw new ApplicationException("JWT Key must be at least 32 characters long");
        }
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(config["Jwt:ExpiryInMinutes"])),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}