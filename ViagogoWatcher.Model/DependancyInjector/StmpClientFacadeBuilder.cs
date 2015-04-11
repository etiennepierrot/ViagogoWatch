using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.Model.DependancyInjector
{
    public class StmpClientFacadeBuilder
    {
        private ConfMailing _confMailing;

        public StmpClientFacadeBuilder WithConfMailing(ConfMailing confMailing)
        {
            _confMailing = confMailing;
            return this;
        }

        public ISmtpClientFacade Build()
        {
            return new SmtpClientFacade(_confMailing);
        }
    }
}