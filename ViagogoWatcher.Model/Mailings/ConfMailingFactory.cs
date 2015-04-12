using System.Collections.Specialized;

namespace ViagogoWatcher.Model.Mailings
{
    public class ConfMailingFactory : IConfMailingFactory
    {
        private readonly NameValueCollection _settings;

        public ConfMailingFactory(NameValueCollection settings)
        {
            _settings = settings;
        }

        public ConfMailing CreateConfMailing()
        {
            string login = _settings["Mailing.Login"];
            string password = _settings["Mailing.Password"];
            string mailAdmin = _settings["Mailing.AdminMail"];

            Credential credential = new Credential(login, password);
            ConfMailing confMailing = new ConfMailing(mailAdmin, credential);
            return confMailing;
        }
    }
}