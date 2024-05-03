using Application.DTOs.Email;
using Application.Interfaces.Services;
using System.Net.Mail;
using System.Net;


namespace Infrastructure.Implementations.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmail(EmailDto email)
        {
            const string fromMail = "********@gmail.com";

            const string fromPassword = "**********";

            var message = new MailMessage
            {
                From = new MailAddress(fromMail),
                Subject = email.Subject,
                Body = "<html><body> " + email.Message + " </body></html>",
                IsBodyHtml = true,
            };

            message.To.Add(new MailAddress(email.Email));

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }
    }
}
