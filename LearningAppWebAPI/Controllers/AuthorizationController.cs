using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LearningAppWebAPI.Domain.Service;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.DTO.Response;
using LearningAppWebAPI.Security;
using LearningAppWebAPI.Utils.CustomAttributes;
using Microsoft.AspNetCore.Authorization;
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
        /// Log in user method. All field are required
        /// </summary>
        /// <param name="loginRequestDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        [NoCurrentUser]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = authorizationService.LoginAsync(loginRequestDto).Result.Value;
            
            var claims = tokenService.WriteClaims(user);
            var accessToken = tokenService.GenerateAccessToken(claims);
            var refreshToken = tokenService.GenerateRefreshToken(claims);

            if (user != null) await tokenService.StoreRefreshTokenAsync(user.Id, refreshToken);

            return Ok(new LoginResponse
            {
                AccessToken = accessToken.Token,
                AccessTokenExpiryDate = accessToken.ExpiryDate,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiryDate = refreshToken.ExpiryDate
            });
        }
        
        /// <summary>
        /// Register user method. All field are required
        /// </summary>
        /// <param name="registerRequestDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        [NoCurrentUser]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await authorizationService.RegisterAsync(registerRequestDto);
            
            return Ok(result);
        }
        /// <summary>
        ///  Revokes user's refresh token, and blacklists user's access token
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
         
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null) await tokenService.RevokeTokensFromUser(userId);
            
            var jti = User.FindFirstValue(JwtRegisteredClaimNames.Jti);
            if (jti != null) await tokenService.BlacklistAccessToken(jti);
            return NoContent();
        }
        /// <summary>
        /// Refreshes user access token based on provided refreshTokenRequest, containing old access token and current refresh token
        /// </summary>
        /// <param name="refreshTokenRequestDto"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [NoCurrentUser]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto refreshTokenRequestDto)
        {
            try
            {
                var newTokens = await tokenService.RefreshTokensAsync(
                    refreshTokenRequestDto.OldAccessToken, 
                    refreshTokenRequestDto.RefreshToken);
        
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
                return StatusCode(500, ex.Message);
            }
        }
    }
}
