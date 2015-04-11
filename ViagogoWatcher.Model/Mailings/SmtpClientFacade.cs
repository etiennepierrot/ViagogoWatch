using System.Net.Mail;

namespace ViagogoWatcher.Model.Mailings
{
    public class SmtpClientFacade : ISmtpClientFacade
    {
        private readonly ConfMailing _confMailing;

        public SmtpClientFacade(ConfMailing confMailing)
        {
            _confMailing = confMailing;
        }

        public void Send(string mail, string subject, string body)
        {
            MailMessage mailMessage = new MailMessage { From = new MailAddress(_confMailing.From) };

            mailMessage.To.Add(mail);
            
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            SmtpClient smtpClient = _confMailing.GetSmtpClient();
            smtpClient.Send(mailMessage);
        }
    }
}