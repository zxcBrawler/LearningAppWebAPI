using System.Net;
using System.Net.Mail;
using System.Text;

namespace LearningAppWebAPI.Remote;


/// <summary>
/// 
/// </summary>
public class EmailSender(IConfiguration config) : IEmailSender
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="toEmail"></param>
    /// <param name="subject"></param>
    /// <param name="userId"></param>
    public void SendEmail(string toEmail, string subject, long userId)
    {
        const string confirmationUrl = "https://localhost:7087/api/Authorization/ConfirmEmail/{0}";
        var fullUrl = string.Format(confirmationUrl, userId);
        using var client = new SmtpClient(config["Mail:Host"], int.Parse(config["Mail:Port"]));
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(config["Mail:From"], config["Mail:Password"]);
        
        var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(config["Mail:From"]);
        mailMessage.To.Add(toEmail);
        mailMessage.Subject = subject;
        mailMessage.IsBodyHtml = true;
        var mailBody = new StringBuilder();
        mailBody.AppendFormat("<h1>Welcome to Learning App!</h1>");
        mailBody.AppendFormat("<h2>Confirm your email!</h2>");
        mailBody.AppendFormat("<br />");
        mailBody.AppendFormat("<p>Thank you For Registering account</p>");
        mailBody.Append($"<h1>Click the link to verify your email: <a href=\"{fullUrl}\">Verify Email</a></h1>");
        mailBody.Append("<br />");
        mailMessage.IsBodyHtml = true;
        mailMessage.Body = mailBody.ToString();
        client.Send(mailMessage);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="toEmail"></param>
    /// <param name="subject"></param>
    public void SendNotificationEmail(string toEmail, string subject)
    {
        using var client = new SmtpClient(config["Mail:Host"], int.Parse(config["Mail:Port"]));
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(config["Mail:From"], config["Mail:Password"]);
        var mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(config["Mail:From"]);
        mailMessage.To.Add(toEmail);
        mailMessage.Subject = subject;
        mailMessage.IsBodyHtml = true;
        var mailBody = new StringBuilder();
        mailBody.AppendFormat("<h1>Your Daily Learning Reminder from Learning App!</h1>");
        mailBody.AppendFormat("<h2>Hello! It's time to continue your learning journey. Don't forget to learn something new today!</h2>");
        mailBody.AppendFormat("<br />");
        mailMessage.IsBodyHtml = true;
        mailMessage.Body = mailBody.ToString();
        client.Send(mailMessage);
    }
}