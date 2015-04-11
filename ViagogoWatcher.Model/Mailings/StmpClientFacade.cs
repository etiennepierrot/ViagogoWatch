using System.Net.Mail;

namespace ViagogoWatcher.Model.Mailings
{
    public interface ISmtpClientFacade
    {
        void Send(MailMessage mailMessage);
    }

    public class SmtpClientFacade : ISmtpClientFacade
    {
        private readonly ConfMailing _confMailing;

        public SmtpClientFacade(ConfMailing confMailing)
        {
            _confMailing = confMailing;
        }

        public void Send(MailMessage mailMessage)
        {
            SmtpClient smtpClient = _confMailing.GetSmtpClient();
            smtpClient.Send(mailMessage);
        }
    }
}