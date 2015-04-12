using System;
using System.Net.Mail;
using SendGrid;

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
            var mailMessage = new SendGridMessage { From = new MailAddress(_confMailing.MailAdmin) };
            mailMessage.AddTo(mail);

            mailMessage.Subject = subject;
            mailMessage.Text = body;

            var transportWeb = new Web(_confMailing.Credential.GetNetworkCredential());
            transportWeb.Deliver(mailMessage);

        }
    }
}