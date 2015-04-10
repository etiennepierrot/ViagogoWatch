using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Timers;
using ViagogoWatcher.Model.Connector;
using ViagogoWatcher.Model.Connector.Dto;

namespace ViagogoWatcher.ConsoleWatcher
{
    public class ViagogoAlert
    {
        const string baseUrl = @"http://www.viagogo.fr/";
        readonly string pathToWatch = ConfigurationManager.AppSettings["UrlEvent"];
        readonly string mailingList = ConfigurationManager.AppSettings["MailingList"];
        readonly string alertName = ConfigurationManager.AppSettings["AlertName"];
        readonly int maxPricingInEur = int.Parse(ConfigurationManager.AppSettings["MaxPricingInEur"]);
        private readonly Timer _timer;
        readonly IList<string> urlSended = new List<string>();


        public ViagogoAlert()
        {
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
                if (!urlSended.Contains(productLowerPrice.BuyUrl))
                {
                    Mailer.SendMail(mailingList, alertName, productLowerPrice);
                    urlSended.Add(productLowerPrice.BuyUrl);
                }
            }
        }

        public void Stop()
        {
            _timer.Stop();
            Mailer.SendStopMail();
        }


    }
}