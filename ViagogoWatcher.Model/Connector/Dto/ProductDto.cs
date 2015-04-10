using System.Collections.Generic;

namespace ViagogoWatcher.Model.Connector.Dto
{
    public class Money
    {
        public long Amout { get; private set; }
        public string Currency { get; private set; }

    }

    public class ProductDto
    {
        public long RawPrice { get; set; }
        public string Section { get; set; }
        public IEnumerable<long> AvailableQuantities { get; set; }
        public string TicketClassName { get; set; }
        public string BuyUrl { get; set; }
    }
}