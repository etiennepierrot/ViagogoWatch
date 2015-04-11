namespace ViagogoWatcher.Model.Mailings
{
    public class SmtpServer
    {
        public string Address { get; private set; }
        public int Port { get; private set; }

        public SmtpServer(string address, int port)
        {
            Address = address;
            Port = port;
        }
    }
}