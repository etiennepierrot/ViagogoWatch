using System.Configuration;
using System.Net;
using System.Net.Mail;
using ViagoWatcher.Model.Connector.Dto;

namespace ConsoleWatcher
{
    public class Mailer
    {

        const string login = "ep.mail.sender.viagogo";
        const string password = "viagogowatch123%";

        public static void SendMail(string mailTo, string alertName, ProductDto productLowerPrice)
        {
            MailMessage mail = new MailMessage();
            var smtpClient = GetSmtpClient();

            mail.From = new MailAddress(login + "@gmail.com");

            foreach (string s in mailTo.Split(';'))
            {
                mail.To.Add(s);
            }


            mail.Subject = alertName + " - " + productLowerPrice.RawPrice + "€";
            mail.Body = productLowerPrice.BuyUrl;

            smtpClient.Send(mail);
        }

        private static SmtpClient GetSmtpClient()
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(login, password),
                EnableSsl = true
            };
            return SmtpServer;
        }

        public static void SendStopMail()
        {
            SmtpClient smtpClient = GetSmtpClient();
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(login + "@gmail.com"),
                Subject = "Service Stoped",
            };
            mailMessage.To.Add(ConfigurationManager.AppSettings["AdminMail"]);

            smtpClient.Send(mailMessage);
        }
    }
}