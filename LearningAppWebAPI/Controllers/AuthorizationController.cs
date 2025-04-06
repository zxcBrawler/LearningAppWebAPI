using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LearningAppWebAPI.Data;
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
    public class AuthorizationController(AuthorizationService authorizationService) : ControllerBase
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
            var userResult = await authorizationService.LoginAsync(loginRequestDto);

            if (userResult.IsSuccess) return Ok(userResult.Value);
            Console.WriteLine($"Login failed: {userResult.ErrorMessage}");
            
            return StatusCode(userResult.StatusCode, new { message = userResult.ErrorMessage });
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
            
            return StatusCode(result.StatusCode, result.IsSuccess ? result.Value : result.ErrorMessage);
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
            var jti = User.FindFirstValue(JwtRegisteredClaimNames.Jti);
            var response = await authorizationService.LogoutAsync(long.Parse(userId), jti);
            return StatusCode(response.StatusCode, response.IsSuccess ? response.Value : response.ErrorMessage);
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
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto refreshTokenRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await authorizationService.RefreshToken(refreshTokenRequestDto);
            if (response.IsSuccess) return Ok(response.Value);
            Console.WriteLine($"Login failed: {response.ErrorMessage}");
            
            return StatusCode(response.StatusCode, new { message = response.ErrorMessage });
        }
    }
}
