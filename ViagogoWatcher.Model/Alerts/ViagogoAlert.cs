using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Timers;
using ViagogoWatcher.Model.Connector;
using ViagogoWatcher.Model.Connector.Dto;
using ViagogoWatcher.Model.Mailings;
using ViagogoWatcher.Model.Moneys;

namespace ViagogoWatcher.Model.Alerts
{
    public class ViagogoAlert : IViagogoAlert
    {
        const string baseUrl = @"http://www.viagogo.fr/";
        readonly string pathToWatch = ConfigurationManager.AppSettings["UrlEvent"];
        readonly string mailingList = ConfigurationManager.AppSettings["MailingList"];
        readonly string alertName = ConfigurationManager.AppSettings["AlertName"];
        readonly Money maxPricingInEur = MaxPricingInEur();

        private static Money MaxPricingInEur()
        {
            int pricingInEur = int.Parse(ConfigurationManager.AppSettings["MaxPricingInEur"]);
            return new Money(pricingInEur);
        }

        private readonly Timer _timer;
        private readonly IMailerService _mailerService;
        readonly IList<string> urlSended = new List<string>();


        public ViagogoAlert(IMailerService mailerService)
        {
            _mailerService = mailerService;
            _timer = new Timer(int.Parse(ConfigurationManager.AppSettings["TimingRefreshInMs"]))
            {
                AutoReset = true,
                Enabled = true,

            };
            _timer.Elapsed += (sender, args) => Watch();
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Watch()
        {
            var viagogoConnector = new ViagogoConnector();

            IEnumerable<ProductDto> products = viagogoConnector.GetProduct(baseUrl + pathToWatch);
            ProductDto productLowerPrice = products.Aggregate((x, y) => x.RawPrice < y.RawPrice ? x : y);

            if (productLowerPrice.RawPrice < maxPricingInEur)
            {
                if (!urlSended.Contains(productLowerPrice.BuyUrl.ToString()))
                {
                    _mailerService.SendAlert(mailingList, alertName, productLowerPrice);
                    urlSended.Add(productLowerPrice.BuyUrl.ToString());
                }
            }
        }

        public void Stop()
        {
            _timer.Stop();
            _mailerService.Stop();
        }


    }
}