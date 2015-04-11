using System.Net;

namespace ViagogoWatcher.Model.Mailings
{
    public class Credential
    {
        private readonly string _login;
        private readonly string _password;

        public Credential(string login, string password)
        {
            _login = login;
            _password = password;
        }

        public NetworkCredential GetNetworkCredential()
        {
            return new NetworkCredential(_login, _password);
        }
    }
}