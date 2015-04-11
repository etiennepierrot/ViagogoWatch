using ViagogoWatcher.Model.Connector.Dto;

namespace ViagogoWatcher.Model.Mailings
{
    public class MailerService : IMailerService
    {
        private readonly ISmtpClientFacade _smtpClientFacade;
        private readonly ConfMailing _confMailing;

        public MailerService(ISmtpClientFacade smtpClientFacade, ConfMailing confMailing)
        {
            _smtpClientFacade = smtpClientFacade;
            _confMailing = confMailing;
        }

        public void SendAlert(string mailTo, string alertName, ProductDto productLowerPrice)
        {
            string subject = alertName + " - " + productLowerPrice.RawPrice;
            string body = productLowerPrice.BuyUrl.ToString();

            _smtpClientFacade.Send(mailTo, subject, body);
        }

        public void Stop()
        {
            _smtpClientFacade.Send(_confMailing.MailAdmin, "Service Stoped", string.Empty);
        }
    }
}