using ViagogoWatcher.Model.Alerts;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.Model.DependancyInjector
{
    public class ViagogoAlertBuilder
    {
        private IMailerService _mailerService;

        public ViagogoAlertBuilder()
        {
            _mailerService = new MailerServiceBuilder().Build();
        }

        public ViagogoAlertBuilder WithMailService(IMailerService mailerService)
        {
            _mailerService = mailerService;
            return this;
        }

        public IViagogoAlert Build()
        {
            return new ViagogoAlert(_mailerService);
        }
    }
}