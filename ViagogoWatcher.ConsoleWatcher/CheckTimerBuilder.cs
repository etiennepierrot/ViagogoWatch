using ViagogoWatcher.Model.Alerts;
using ViagogoWatcher.Model.DependancyInjector;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.ConsoleWatcher
{
    public class CheckTimerBuilder
    {
        private IMailerService _mailerService;
        private IPriceChecker _priceChecker;

        public CheckTimerBuilder()
        {
            _mailerService = new MailerServiceBuilder().Build();
            _priceChecker = new PriceCheckerBuilder().Build();
        }

        public CheckTimerBuilder WithMailService(IMailerService mailerService)
        {
            _mailerService = mailerService;
            return this;
        }

        public CheckTimerBuilder WithPriceChecker(IPriceChecker priceChecker)
        {
            _priceChecker = priceChecker;
            return this;
        }

        public ICheckTimer Build()
        {
            return new CheckTimer(_mailerService, _priceChecker);
        }
    }
}