using Hangfire.Schedule.ScheduleJobs.Managers.Interfaces;
using System.Net.Mail;
using System.Net;

namespace Hangfire.Schedule.ScheduleJobs.Managers
{
    public class EmailManager : IEmailManager
    {
        public void SendEmail()
        {
            var fromAddress = new MailAddress("ensar.src94@gmail.com", "Ensar Saraç");
            var toAddress = new MailAddress("ensar.src94@gmail.com");
            const string fromPassword = ".";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", // Örn: smtp.gmail.com
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            string htmlContent = @"
    <html>
        <body style='font-family: Arial, sans-serif;'>
            <h2 style='color: #2e6c80;'>Merhaba!</h2>
            <p>Bu bir <strong>test e-postasıdır</strong>. Hangfire üzerinden gönderildi.</p>
            <p style='margin-top: 20px;'>İyi çalışmalar!<br><em>Test Ekibi</em></p>
        </body>
    </html>";


            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Hangfire Test",
                Body = htmlContent,
                IsBodyHtml = true 
            };

            smtp.Send(message);
        }
    }
}
