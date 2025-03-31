using System.Security.Claims;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.DTO.Request;
using LearningAppWebAPI.Models.Enum;
using LearningAppWebAPI.Security;
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
    public class AuthorizationController(TokenService tokenService) : ControllerBase
    {
        /// <summary>
        /// Dummy login for testing purposes
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            
            var user = new DummyUser();
            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = tokenService.GenerateToken(claims);
            
            return Ok(new {
                Token = token,
                User = user.Username,
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
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
            
            return Ok();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        [Authorize]
        public async Task<IActionResult> RefreshToken()
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
