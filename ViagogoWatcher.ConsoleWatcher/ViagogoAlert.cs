using System.Configuration;
using System.Timers;
using ViagogoWatcher.Model.Alerts;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.ConsoleWatcher
{
    public class ViagogoAlert : IViagogoAlert
    {
        private readonly Timer _timer;
        public readonly IMailerService _mailerService;
        private readonly IPriceChecker _priceChecker;


        public ViagogoAlert(IMailerService mailerService, IPriceChecker priceChecker)
        {
            _mailerService = mailerService;
            _timer = new Timer(int.Parse(ConfigurationManager.AppSettings["TimingRefreshInMs"]))
            {
                AutoReset = true,
                Enabled = true,

            };
            _timer.Elapsed += (sender, args) => Watch();
            _priceChecker = priceChecker;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Watch()
        {
            _priceChecker.CheckPrice();
        }

        public void Stop()
        {
            _timer.Stop();
            _mailerService.Stop();
        }


    }
}