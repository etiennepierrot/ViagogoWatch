using System.Collections.Specialized;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.Model.DependancyInjector
{
    public class ConfMailingFactoryBuilder
    {
        private NameValueCollection _settings;

        public ConfMailingFactoryBuilder()
        {
            _settings = new NameValueCollection();
        }

        public IConfMailingFactory Build()
        {
            return new ConfMailingFactory(_settings);
        }

        public ConfMailingFactoryBuilder WithSettings(NameValueCollection settings)
        {
            _settings = settings;
            return this;
        }
    }
}