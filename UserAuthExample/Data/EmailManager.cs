using System.Net.Mail;
using UserAuthExample.Models;

namespace UserAuthExample.Data
{
    public class EmailManager
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailManager(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        // Create content to send reset email to user
        private static MailMessage CreateEmailMessage(Message message)
        {
            // Change to correct route check your launch setting.
            // Should just have to change the PORT
            var link = "https://localhost:PORT/User/ResetPassword/" + message.Token; // Here
            MailMessage mail = new();
            mail.To.Add(message.To);
            //Change to your email address
            mail.From = new MailAddress("myEmail@outlook.com"); // Here
            mail.Subject = message.Subject;
           
            string Body = $"<a href='{link}'>Reset Password</a>";
            mail.Body = Body;
            mail.IsBodyHtml = true;

            return mail;
        }

        // Use smtp to send email
        private bool Send(MailMessage mailMessage)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = _emailConfig.SmtpServer;
                smtp.Port = _emailConfig.Port;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(_emailConfig.UserName, _emailConfig.Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);

        }
    }
}
