using System.Security.Claims;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Response;

namespace LearningAppWebAPI.Security;

public interface ITokenService
{
     /// <summary>
     /// 
     /// </summary>
     /// <param name="claims"></param>
     /// <returns></returns>
     TokenResponse GenerateAccessToken(ICollection<Claim> claims);
     /// <summary>
     /// 
     /// </summary>
     /// <param name="claims"></param>
     /// <returns></returns>
     TokenResponse GenerateRefreshToken(ICollection<Claim> claims);

     /// <summary>
     /// 
     /// </summary>
     /// <param name="claims"></param>
     /// <param name="expires"></param>
     /// <param name="signingKey"></param>
     /// <returns></returns>
     TokenResponse GenerateJwtToken(ICollection<Claim> claims, DateTime expires, string signingKey);
     /// <summary>
     /// 
     /// </summary>
     /// <param name="user"></param>
     /// <returns></returns>
     ICollection<Claim> WriteClaims(User? user);
     /// <summary>
     /// 
     /// </summary>
     /// <param name="userId"></param>
     /// <param name="token"></param>
     /// <returns></returns>
     Task StoreRefreshTokenAsync(int userId, TokenResponse token);
     /// <summary>
     /// 
     /// </summary>
     /// <param name="userId"></param>
     /// <returns></returns>
     Task RevokeTokensFromUser(string userId);
     /// <summary>
     /// 
     /// </summary>
     /// <param name="jti"></param>
     /// <returns></returns>
     Task BlacklistAccessToken(string jti);
     /// <summary>
     /// 
     /// </summary>
     /// <param name="jti"></param>
     /// <returns></returns>
     Task<bool> IsTokenBlacklisted(string jti);

     /// <summary>
     /// 
     /// </summary>
     /// <param name="expiredAccessToken"></param>
     /// <param name="refreshToken"></param>
     /// <returns></returns>
     Task<TokenResponse> RefreshTokensAsync(string expiredAccessToken, string refreshToken);

     /// <summary>
     /// 
     /// </summary>
     /// <param name="userId"></param>
     /// <param name="refreshToken"></param>
     /// <returns></returns>
     Task<bool> ValidateRefreshTokenAsync(int userId, string refreshToken);


}