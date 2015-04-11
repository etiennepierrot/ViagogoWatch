namespace ViagogoWatcher.Model.Mailings
{
    public interface ISmtpClientFacade
    {
        void Send(string mail, string subject, string body);
    }
}