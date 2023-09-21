using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Infrastructure.Services.EmailServices
{
    public static class Email
    {
        public static void SendMail(string to, string subject, string html,string from,string password)
        {
            //// create message 
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("postmaster@aliyusifov.com"));
            //email.To.Add(MailboxAddress.Parse(to));
            //email.Subject = subject;
            //email.Body = new TextPart(TextFormat.Html) { Text = html };

            //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            //{
            //    return true;
            //};

            //// send email
            //using var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.None);
            //smtp.Authenticate(from, password);
            //smtp.Send(email);
            //smtp.Disconnect(true);
            using(var client = new SmtpClient("smtp.gmail.com", 587))
                {
                client.Credentials =
                  new NetworkCredential(from, password);
                client.EnableSsl = true;
                //  client.UseDefaultCredentials = true;
                var htmlTextPart = new TextPart(TextFormat.Html)
                {
                    Text = html
                };
                var msg = new MailMessage(from, to);
                msg.IsBodyHtml = true;
                msg.Body = html;
                msg.Subject = subject;

                client.Send(msg);
            }

        }
    }
}
