using System.Collections.Specialized;

namespace ViagogoWatcher.Model.Mailings
{
    public interface IConfMailingFactory
    {
        ConfMailing CreateConfMailing();
    }

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
            string address = _settings["Mailing.Server"];
            int port = int.Parse(_settings["Mailing.Port"]);
            string mailAdmin = _settings["Mailing.AdminMail"];

            Credential credential = new Credential(login, password);
            SmtpServer smtpServer = new SmtpServer(address, port);
            ConfMailing confMailing = new ConfMailing(login, mailAdmin, smtpServer, credential);
            return confMailing;
        }
    }
}