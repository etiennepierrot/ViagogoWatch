using System.Collections.Generic;
using System.Linq;
using ViagogoWatcher.Model.Urls;

namespace ViagogoWatcher.Model.Connector.Dto
{
    public class ProductDto
    {
        public long RawPrice { get; set; }
        public string Section { get; set; }
        public IEnumerable<long> AvailableQuantities { get; set; }
        public string TicketClassName { get; set; }
        public string BuyUrl { get; set; }

        public override string ToString()
        {
            return string.Format("TicketClassName: {0}, BuyUrl: {1}, AvailableQuantities: {2}, Section: {3}, RawPrice: {4}", TicketClassName, BuyUrl, AvailableQuantities.Max(), Section, RawPrice);
        }
    }
}