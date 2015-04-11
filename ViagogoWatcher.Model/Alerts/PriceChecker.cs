using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ViagogoWatcher.Model.Connector;
using ViagogoWatcher.Model.Connector.Dto;
using ViagogoWatcher.Model.Mailings;
using ViagogoWatcher.Model.Moneys;

namespace ViagogoWatcher.Model.Alerts
{
    public interface IPriceChecker
    {
        void CheckPrice();
    }

    public class PriceChecker : IPriceChecker
    {
        public readonly IList<string> urlSended = new List<string>();
        public readonly string alertName = ConfigurationManager.AppSettings["AlertName"];


        private readonly IMailerService _mailerService;

        public PriceChecker(IMailerService mailerService)
        {
            _mailerService = mailerService;
        }

        private static Money MaxPricingInEur()
        {
            int pricingInEur = int.Parse(ConfigurationManager.AppSettings["MaxPricingInEur"]);
            return new Money(pricingInEur);
        }

        public readonly string mailingList = ConfigurationManager.AppSettings["MailingList"];


        public void CheckPrice()
        {
            var viagogoConnector = new ViagogoConnector();

            IEnumerable<ProductDto> products = viagogoConnector.GetProduct(@"http://www.viagogo.fr/" + ConfigurationManager.AppSettings["UrlEvent"]);
            ProductDto productLowerPrice = products.Aggregate((x, y) => x.RawPrice < y.RawPrice ? x : y);

            if (productLowerPrice.RawPrice < MaxPricingInEur())
            {
                if (urlSended.Contains(productLowerPrice.BuyUrl.ToString()))
                {
                    _mailerService.SendAlert(mailingList, alertName, productLowerPrice);
                    urlSended.Add(productLowerPrice.BuyUrl.ToString());
                }
            }
        }
    }
}