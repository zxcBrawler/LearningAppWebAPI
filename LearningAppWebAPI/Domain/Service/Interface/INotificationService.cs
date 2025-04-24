namespace LearningAppWebAPI.Domain.Service.Interface;

public interface INotificationService
{
    Task SendNotificationsToUsers(DateTime currentUtcTime);
    Task ScheduleUserNotificationsAsync(long userId, DateTime? notificationTime);
    Task StopNotifications(long userId);
}