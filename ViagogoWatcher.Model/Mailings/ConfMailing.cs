namespace ViagogoWatcher.Model.Mailings
{
    public class ConfMailing
    {
        public Credential Credential { get; private set; }
        public string MailAdmin { get; private set; }

        public ConfMailing(string mailAdmin, Credential credential)
        {
            MailAdmin = mailAdmin;
            Credential = credential;
        }
    }
}