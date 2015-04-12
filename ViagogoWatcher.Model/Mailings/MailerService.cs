using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        public void SendAlert(string mailTo, string alertName, IEnumerable<ProductDto> products)
        {
            if (!products.Any())
            {
                return;
            }

            string subject = string.Format("[ViagogoWatcher] Alert : {0}", alertName);

            StringBuilder sb = new StringBuilder();

            foreach (var productDto in products)
            {
                sb.AppendLine(productDto.ToString());
            }

            _smtpClientFacade.Send(mailTo, subject, sb.ToString());
        }

        public void Stop()
        {
            _smtpClientFacade.Send(_confMailing.MailAdmin, "Service Stoped", string.Empty);
        }
    }
}