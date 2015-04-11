using System.Collections.Generic;
using ViagogoWatcher.Model.Moneys;
using ViagogoWatcher.Model.Urls;

namespace ViagogoWatcher.Model.Connector.Dto
{
    public class ProductDto
    {
        public Money RawPrice { get; set; }
        public string Section { get; set; }
        public IEnumerable<long> AvailableQuantities { get; set; }
        public string TicketClassName { get; set; }
        public Url BuyUrl { get; set; }
    }
}