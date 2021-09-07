using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.BLL.MailHelper
{
    public class MailSendingManager
    {
        public bool SendMail(string FromMail, string head, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("saban.kalanc@demircode.com");
                message.To.Add(FromMail);
                message.To.Add("info@demircode.com");
                message.Subject = head;
                message.IsBodyHtml = true;
                message.Body = body;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("saban.kalanc@demircode.com", "Saban1923");
                smtpClient.Send(message);
                return true;
            }
            catch (Exception e)
            {
                var message = e.Message;
                return false;
            }
        }
    }
}
