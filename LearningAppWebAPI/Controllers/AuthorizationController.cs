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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        /// Dummy login for testing purposes
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        [NoCurrentUser]
        public async Task<IActionResult> Login() //LoginRequest loginRequest
        {
            var user = new DummyUser();
            
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok();
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
        [Authorize]
        [NoCurrentUser]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok();
        }
        [HttpPost("[action]")]
        [Authorize]
        public async Task<IActionResult> ValidateToken()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            return Ok();
        }
    }
}
