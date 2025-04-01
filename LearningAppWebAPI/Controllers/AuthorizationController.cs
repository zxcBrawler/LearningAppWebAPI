using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Response;
using LearningAppWebAPI.Models.Enum;
using LearningAppWebAPI.Security;
using LearningAppWebAPI.Utils;
using LearningAppWebAPI.Utils.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LearningAppWebAPI.Controllers
{
    /// <summary>
    /// The authorization controller class
    /// </summary>
    /// <seealso cref="ControllerBase"/>
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "users")]
    [ApiController]
    public class AuthorizationController(ITokenService tokenService, AuthorizationService authorizationService) : ControllerBase
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        [NoCurrentUser]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = authorizationService.LoginAsync(loginRequest).Result.Value;
            
            var claims = tokenService.WriteClaims(user);
            var accessToken = tokenService.GenerateAccessToken(claims);
            var refreshToken = tokenService.GenerateRefreshToken(claims);
            
            await tokenService.StoreRefreshTokenAsync(user.Id, refreshToken);
            
            return Ok(new LoginResponse
            {
                AccessToken = accessToken.Token,
                AccessTokenExpiryDate = accessToken.ExpiryDate,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiryDate = refreshToken.ExpiryDate
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        [NoCurrentUser]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await authorizationService.RegisterAsync(request);
            
            return Ok(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null) await tokenService.RevokeTokensFromUser(userId);
            
            var jti = User.FindFirstValue(JwtRegisteredClaimNames.Jti);
            if (jti != null) await tokenService.BlacklistAccessToken(jti);
            return NoContent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [NoCurrentUser]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            try
            {
                var newTokens = await tokenService.RefreshTokensAsync(
                    refreshTokenRequest.OldAccessToken, 
                    refreshTokenRequest.RefreshToken);
        
                return Ok(newTokens);
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred");
            }
        }
    }
}
