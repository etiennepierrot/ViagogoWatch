using ViagogoWatcher.Model.Connector.Dto;

namespace ViagogoWatcher.Model.Mailings
{
    public interface IMailerService
    {
        void SendAlert(string mailTo, string alertName, ProductDto productLowerPrice);
        void Stop();
    }
}