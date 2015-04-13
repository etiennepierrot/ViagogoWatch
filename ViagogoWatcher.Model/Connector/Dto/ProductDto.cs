using System.Collections.Generic;
using System.Linq;

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
            return string.Format("BuyUrl: {0} <br/>AvailableQuantities: {1} <br/>Section: {2}<br/>RawPrice: {3}", BuyUrl, AvailableQuantities.Max(), Section, RawPrice);
        }
    }
}