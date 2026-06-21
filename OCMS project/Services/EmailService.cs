using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OCMS_project.Services
{
    public class EmailService
    {
        public async Task<bool> SendStatusChangeEmailAsync(string toEmail, string userName, string newStatus)
        {
            try
            {
                var smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
                var smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
                var senderEmail = ConfigurationManager.AppSettings["SenderEmail"];
                var senderPassword = ConfigurationManager.AppSettings["SenderPassword"];
                var senderName = ConfigurationManager.AppSettings["SenderName"];

                var subject = "Your Account Status Has Been Changed";

                var body = $@"
                    <h2>Hello {userName},</h2>
                    <p>Your account status has been changed to: <strong>{newStatus}</strong>.</p>
                    <p>If you did not request this, please contact support.</p>
                    <br/>
                    <p>Regards,<br/>{senderName}</p>";

                using (var client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    var mail = new MailMessage
                    {
                        From = new MailAddress(senderEmail, senderName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };
                    mail.To.Add(toEmail);

                    await client.SendMailAsync(mail);
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log error here (aap file ya database me log kar sakte ho)
                System.Diagnostics.Debug.WriteLine("Email error: " + ex.Message);
                return false;
            }
        }
    }
}