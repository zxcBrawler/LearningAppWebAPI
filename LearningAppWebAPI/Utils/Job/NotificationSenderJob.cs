using Coravel.Invocable;
using LearningAppWebAPI.Domain.Service.Interface;

namespace LearningAppWebAPI.Utils.Job;

/// <summary>
/// 
/// </summary>
/// <param name="notificationService"></param>
/// <param name="logger"></param>
public class NotificationSenderJob(INotificationService notificationService, ILogger<NotificationSenderJob> logger) : IInvocable
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task Invoke()
    {
        logger.LogInformation("Sending user notifications");
        await notificationService.SendNotificationsToUsers(DateTime.UtcNow.AddHours(3));
        logger.LogInformation("Sending user notifications FINISHED");
    }
}