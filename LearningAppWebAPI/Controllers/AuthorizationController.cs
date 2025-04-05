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
    /// Provides endpoints for user authentication, registration, and token management.
    /// Implements JWT-based authentication flow with access and refresh tokens.
    /// </summary>
    /// <remarks>
    /// This controller handles the complete authentication lifecycle including:
    /// - User login with JWT generation
    /// - New user registration
    /// - Token refresh mechanism
    /// - Session invalidation (logout)
    /// </remarks>
    /// <seealso cref="ControllerBase"/>
    [Route("api/[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "users")]
    [ApiController]
    public class AuthorizationController(ITokenService tokenService, AuthorizationService authorizationService) : ControllerBase
    {
        
        /// <summary>
        /// Authenticates a user and generates JWT tokens
        /// </summary>
        /// <param name="loginRequestDto">Contains user credentials (username/email and password)</param>
        /// <returns>
        /// Returns a LoginResponse containing:
        /// - Access token (short-lived, for API authorization)
        /// - Refresh token (long-lived, for obtaining new access tokens)
        /// - Token expiration dates
        /// </returns>
        /// <response code="200">Successful authentication. Returns tokens.</response>
        /// <response code="400">Invalid request format or missing required fields.</response>
        /// <response code="401">Invalid credentials or unauthorized access attempt.</response>
        /// <remarks>
        /// Sample request:
        /// POST /api/Authorization/login
        /// {
        ///     "username": "johndoe",
        ///     "password": "Str0ngP@ssw0rd!"
        /// }
        /// </remarks>
        [HttpPost]
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
        /// Registers a new user in the system
        /// </summary>
        /// <param name="registerRequestDto">Contains user registration information</param>
        /// <returns>Result of the registration operation</returns>
        /// <response code="200">User successfully registered</response>
        /// <response code="400">Invalid request or user already exists</response>
        /// <remarks>
        /// Sample request:
        /// POST /api/Authorization/register
        /// {
        ///     "username": "johndoe",
        ///     "email": "john@example.com",
        ///     "password": "Str0ngP@ssw0rd!"
        /// }
        /// </remarks>
        [HttpPost]
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
        /// Invalidates the current user's authentication tokens
        /// </summary>
        /// <returns>No content</returns>
        /// <response code="204">Tokens successfully invalidated</response>
        /// <response code="401">Unauthorized access attempt</response>
        /// <remarks>
        /// This endpoint:
        /// 1. Revokes all refresh tokens for the current user
        /// 2. Blacklists the current access token
        /// Requires a valid access token in the Authorization header
        /// </remarks>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(204)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> LogOut()
        {
         
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null) await tokenService.RevokeTokensFromUser(long.Parse(userId));
            
            var jti = User.FindFirstValue(JwtRegisteredClaimNames.Jti);
            if (jti != null) await tokenService.BlacklistAccessToken(jti);
            return NoContent();
        }
        /// <summary>
        /// Generates new access token using a valid refresh token
        /// </summary>
        /// <param name="refreshTokenRequestDto">Contains the expired access token and valid refresh token</param>
        /// <returns>New access token</returns>
        /// <response code="200">Returns new tokens</response>
        /// <response code="401">Invalid or expired tokens provided</response>
        /// <response code="404">Refresh token not found</response>
        /// <remarks>
        /// Sample request:
        /// POST /api/Authorization/refresh-token
        /// {
        ///     "oldAccessToken": "expired.jwt.token",
        ///     "refreshToken": "valid.refresh.token"
        /// }
        /// 
        /// This implements the refresh token rotation pattern for enhanced security.
        /// </remarks>
        [HttpPost]
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
