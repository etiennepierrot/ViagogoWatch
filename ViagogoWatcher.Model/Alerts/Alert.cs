using System.Collections.Generic;
using ViagogoWatcher.Model.Moneys;
using ViagogoWatcher.Model.Urls;

namespace ViagogoWatcher.Model.Alerts
{
    public class Alert
    {
        public long ID { get; set; }
        public Url Url { get; set; }
        public Money MaxPrice { get; set; }
        public virtual ICollection<string> Emails { get; set; } 
        public long NbPlaces { get; set; }
        public string Category { get; set; }
    }
}
