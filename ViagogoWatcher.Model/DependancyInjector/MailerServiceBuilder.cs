using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.Model.DependancyInjector
{
    public class MailerServiceBuilder
    {
        private ISmtpClientFacade _smtpClientFacade;
        private ConfMailing _confMailing;

        public MailerServiceBuilder()
        {
            _smtpClientFacade = new StmpClientFacadeBuilder().Build();
            IConfMailingFactory confMailingFactory = new ConfMailingFactoryBuilder().Build();
            _confMailing = confMailingFactory.CreateConfMailing();
        }

        public MailerServiceBuilder WithConfMailing(ConfMailing confMailing)
        {
            _confMailing = confMailing;
            return this;
        }

        public MailerServiceBuilder WithStmpClientFacade(ISmtpClientFacade smtpClientFacade)
        {
            _smtpClientFacade = smtpClientFacade;
            return this;
        }

        public IMailerService Build()
        {
            return new MailerServiceService(_smtpClientFacade, _confMailing);
        }
    }
}