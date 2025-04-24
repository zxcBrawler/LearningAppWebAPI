using LearningAppWebAPI.Domain.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LearningAppWebAPI.Controllers;

/// <summary>
/// 
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
[ApiExplorerSettings(GroupName = "users")]
public class NotificationsController(INotificationService notificationService) : BasicController
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SetNotificationsDateTime(string dateTime)
    {
        await notificationService.ScheduleUserNotificationsAsync(UserId, DateTime.Parse(dateTime));
        return Ok();
    }
    [HttpPost]
    public async Task<IActionResult> StopNotifications()
    {
        await notificationService.StopNotifications(UserId);
        return Ok();
    }
}