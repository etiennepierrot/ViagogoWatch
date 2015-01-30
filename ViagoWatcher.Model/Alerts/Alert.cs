using System.Collections.Generic;

namespace ViagogoWatcher.Model.Alerts
{
    public class Alert
    {
       public long ID { get; set; }
        public string Url { get; set; }
        public long MaxPrice { get; set; }
        public virtual ICollection<string> Emails { get; set; } 
        public long NbPlaces { get; set; }
        public string Category { get; set; }
    }
}
