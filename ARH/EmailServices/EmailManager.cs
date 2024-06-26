using System.Net.Mail;
using System.Net;

namespace Skyline_Manager.EmailServices
{
    public class EmailManager
    {
        public static bool SendEmail(string To, string Subject, string Body)
        {
            bool flag = false;
            EmailSettings mailSettings = new EmailSettings();
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(mailSettings.EmailSenderAccount, mailSettings.EmailSenderName);
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.EnableSsl = true;
            client.Port = mailSettings.Port;
            client.Host = mailSettings.Host;
            client.Credentials = new NetworkCredential(mailSettings.EmailSenderAccount, mailSettings.EmailSenderAccountSecret);

            try
            {
                client.Send(mail);
                flag = true;
            }
            catch (Exception ex)
            {
                string errorMessage = string.Empty;
                errorMessage = ex.ToString();
                flag = false;

            }

            return flag;
        }

    }
}
