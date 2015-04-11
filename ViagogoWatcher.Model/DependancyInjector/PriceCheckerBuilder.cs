using ViagogoWatcher.Model.Alerts;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.Model.DependancyInjector
{
    public class PriceCheckerBuilder
    {
        private IMailerService _mailerService;

        public PriceCheckerBuilder()
        {
            _mailerService = new MailerServiceBuilder().Build();
            
        }
        public PriceChecker Build()
        {
            return new PriceChecker(_mailerService);
        }

        public PriceCheckerBuilder WithMailService(IMailerService mailerService)
        {
            _mailerService = mailerService;
            return this;
        }
    }
}