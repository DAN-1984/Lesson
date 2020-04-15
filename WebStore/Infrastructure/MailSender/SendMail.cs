using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.MailSender
{
    public class SendMail
    {
        public static async Task SendEmailAsync(MailViewModel mail)
        {
            MailAddress from = new MailAddress("dashkin.1984@inbox.ru", mail.Name);
            MailAddress to = new MailAddress("dashkin.1984@inbox.ru");
            MailMessage m = new MailMessage(from, to);
            m.Subject = mail.Subject;
            m.Body = "Сообщение от: " + mail.Email + "\n\n" + mail.Message;
            m.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
            //smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential("dashkin.1984@inbox.ru", "*++6699919");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);  
        }
    }
}
