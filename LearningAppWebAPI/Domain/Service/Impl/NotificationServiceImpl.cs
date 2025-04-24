using LearningAppWebAPI.Domain.Repository;
using LearningAppWebAPI.Domain.Service.Interface;
using Microsoft.AspNetCore.Identity.UI.Services;
using IEmailSender = LearningAppWebAPI.Remote.IEmailSender;

namespace LearningAppWebAPI.Domain.Service.Impl;

/// <summary>
/// 
/// </summary>
/// <param name="userRepository"></param>
public class NotificationServiceImpl(UserRepository userRepository, IEmailSender emailSender,  ILogger<NotificationServiceImpl> logger) : INotificationService
{
    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public async Task SendNotificationsToUsers(DateTime currentUtcTime)
    {
        var usersToNotify = await userRepository.GetAllAsync();
        
        usersToNotify = usersToNotify.Where(u => u is { IsEmailNotificationsEnabled: true, EmailNotificationsDateTime: not null } && u.EmailNotificationsDateTime.Value.Hour == currentUtcTime.Hour && u.EmailNotificationsDateTime.Value.Minute == currentUtcTime.Minute).ToList();

        if (usersToNotify.Count == 0)
        {
            return;
        }
        logger.LogInformation($"Found {usersToNotify.Count} users to notify");
        foreach (var user in usersToNotify)
        {
            try
            {
                emailSender.SendNotificationEmail(user.Email, "Dear " + user.Username);
                user.LastNotificationSentAt = currentUtcTime;
                await userRepository.UpdateAsync(user.Id, user);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to send notification to {user.Email}");
            }
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="notificationTime"></param>
    public async Task ScheduleUserNotificationsAsync(long userId, DateTime? notificationTime)
    {
        try
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null) return;

            user.EmailNotificationsDateTime = notificationTime;
            user.IsEmailNotificationsEnabled = true;

            await userRepository.UpdateAsync(userId, user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
       
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    public async Task StopNotifications(long userId)
    {
        try
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null) return;
            user.EmailNotificationsDateTime = null;
            user.IsEmailNotificationsEnabled = false;

            await userRepository.UpdateAsync(userId, user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}