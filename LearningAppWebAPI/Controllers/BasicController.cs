using System.Security.Claims;
using LearningAppWebAPI.Domain.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers;

/// <summary>
/// 
/// </summary>
[Authorize]
public class BasicController : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="UnauthorizedAccessException"></exception>
    /// <exception cref="FormatException"></exception>
    protected long UserId
    {
        get
        {
            var value = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(value))
            {
                throw new UnauthorizedAccessException("User is not logged in");
            }

            if (!long.TryParse(value, out var userId))
            {
                throw new FormatException($"Invalid user id {userId}");
            }
            return userId;
        }
    }
}