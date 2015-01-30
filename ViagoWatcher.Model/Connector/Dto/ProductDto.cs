using System.Collections.Generic;

namespace ViagoWatcher.Model.Connector.Dto
{
    public class ProductDto
    {
        public long RawPrice { get; set; }
        public string Section { get; set; }
        public IEnumerable<long> AvailableQuantities { get; set; }
        public string TicketClassName { get; set; }
        public string BuyUrl { get; set; }
    }
}