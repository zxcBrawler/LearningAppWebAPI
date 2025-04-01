using System.Security.Claims;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models.DTO.Response;

namespace LearningAppWebAPI.Security;

public interface ITokenService
{
     TokenResponse GenerateAccessToken(ICollection<Claim> claims);
     TokenResponse GenerateRefreshToken(ICollection<Claim> claims);

     TokenResponse GenerateJwtToken(ICollection<Claim> claims, DateTime expires, string signingKey);
     ICollection<Claim> WriteClaims(DummyUser user);
     Task StoreRefreshTokenAsync(int userId, TokenResponse token);
     Task RevokeTokensFromUser(string userId);
     Task BlacklistAccessToken(string jti);
     Task<bool> IsTokenBlacklisted(string jti);
}