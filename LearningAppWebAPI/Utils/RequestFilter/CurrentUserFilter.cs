using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LearningAppWebAPI.Utils.CustomAttributes;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LearningAppWebAPI.Utils.RequestFilter;

/// <summary>
/// 
/// </summary>
[ScopedService]
public class CurrentUserFilter : IAsyncActionFilter
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.ActionDescriptor.EndpointMetadata
            .Any(m => m is NoCurrentUserAttribute))
        {
            await next();
            return;
        }
        var user = context.HttpContext.User;
       
        if (context.HttpContext.User.Identity?.IsAuthenticated == true)
        {
            context.HttpContext.Items["CurrentUserId"] = user.FindFirstValue(ClaimTypes.NameIdentifier);
            context.HttpContext.Items["CurrentUserEmail"] = user.FindFirstValue(ClaimTypes.Email);
            context.HttpContext.Items["CurrentUserUsername"] = user.FindFirstValue(ClaimTypes.Name);
            context.HttpContext.Items["CurrentUserRoles"] = user.FindFirstValue(ClaimTypes.Role);
            context.HttpContext.Items["CurrentUserJTI"] = user.FindFirstValue(JwtRegisteredClaimNames.Jti);
        }

        await next();
    }
}