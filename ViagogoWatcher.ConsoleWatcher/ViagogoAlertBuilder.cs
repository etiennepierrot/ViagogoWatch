using ViagogoWatcher.Model.Alerts;
using ViagogoWatcher.Model.DependancyInjector;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.ConsoleWatcher
{
    public class ViagogoAlertBuilder
    {
        private IMailerService _mailerService;
        private IPriceChecker _priceChecker;

        public ViagogoAlertBuilder()
        {
            _mailerService = new MailerServiceBuilder().Build();
            _priceChecker = new PriceCheckerBuilder().Build();
        }

        public ViagogoAlertBuilder WithMailService(IMailerService mailerService)
        {
            _mailerService = mailerService;
            return this;
        }

        public ViagogoAlertBuilder WithPriceChecker(IPriceChecker priceChecker)
        {
            _priceChecker = priceChecker;
            return this;
        }

        public IViagogoAlert Build()
        {
            return new ViagogoAlert(_mailerService, _priceChecker);
        }
    }
}