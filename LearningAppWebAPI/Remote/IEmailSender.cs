namespace LearningAppWebAPI.Remote;

/// <summary>
/// 
/// </summary>
public interface IEmailSender
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="toEmail"></param>
    /// <param name="subject"></param>
    /// <param name="userId"></param>
    void SendEmail(string toEmail, string subject, long userId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="toEmail"></param>
    /// <param name="subject"></param>
    void SendNotificationEmail(string toEmail, string subject);
}