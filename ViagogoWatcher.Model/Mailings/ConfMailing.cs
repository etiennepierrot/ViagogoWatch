using System.Net;
using System.Net.Mail;

namespace ViagogoWatcher.Model.Mailings
{
    public class ConfMailing
    {
        public Credential Credential { get; private set; }
        public string From { get; private set; }
        public string MailAdmin { get; private set; }
        public SmtpServer SmtpServer { get; private set; }

        public ConfMailing(string from, string mailAdmin, SmtpServer smtpServer, Credential credential)
        {
            From = @from;
            MailAdmin = mailAdmin;
            SmtpServer = smtpServer;
            Credential = credential;
        }

        public SmtpClient GetSmtpClient()
        {
            SmtpClient client = new SmtpClient(SmtpServer.Address)
            {
                Port = SmtpServer.Port,
                Credentials = Credential.GetNetworkCredential(),
                EnableSsl = true
            };
            return client;
        }
 
    }
}