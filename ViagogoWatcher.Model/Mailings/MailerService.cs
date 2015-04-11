using System.Net.Mail;
using ViagogoWatcher.Model.Connector.Dto;

namespace ViagogoWatcher.Model.Mailings
{
    public interface IMailerService
    {
        void SendMail(string mailTo, string alertName, ProductDto productLowerPrice);
        void SendStopMail();
    }

    public class MailerServiceService : IMailerService
    {
        private readonly ISmtpClientFacade _smtpClientFacade;
        private readonly ConfMailing _confMailing;

        public MailerServiceService(ISmtpClientFacade smtpClientFacade, ConfMailing confMailing)
        {
            _smtpClientFacade = smtpClientFacade;
            _confMailing = confMailing;
        }

        public void SendMail(string mailTo, string alertName, ProductDto productLowerPrice)
        {

            MailMessage mail = new MailMessage {From = new MailAddress(_confMailing.From)};

            foreach (string s in mailTo.Split(';'))
            {
                mail.To.Add(s);
            }

            mail.Subject = alertName + " - " + productLowerPrice.RawPrice;
            mail.Body = productLowerPrice.BuyUrl.ToString();

            _smtpClientFacade.Send(mail);
        }

        public void SendStopMail()
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_confMailing.From),
                Subject = "Service Stoped",
            };

            mailMessage.To.Add(_confMailing.MailAdmin);

            _smtpClientFacade.Send(mailMessage);
        }
    }
}