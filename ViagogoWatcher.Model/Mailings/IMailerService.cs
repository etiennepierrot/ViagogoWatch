using System.Collections.Generic;
using ViagogoWatcher.Model.Connector.Dto;

namespace ViagogoWatcher.Model.Mailings
{
    public interface IMailerService
    {
        void SendAlert(string mailTo, string alertName, IEnumerable<ProductDto> products, string codeSubscription);
        void Stop();
    }
}