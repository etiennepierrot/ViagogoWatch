using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace ViagogoWatcher.Model.Persistances
{

    public class UrlState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UrlId { get; set; }
        public string Url { get; set; }
        public SubscriptionState SubscriptionState { get; set; }
    }

    public class SubscriptionState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SubscriptionId { get; set; }
        public string Email { get; set; }
        public long MaxPricing { get; set; }
        public virtual ICollection<UrlState> UrlStates { get; set; } 
        public string CodeEvent { get; set; }
        public int NBPlace { get; set; }
        public string CodeSubscription { get; set; }
    }

    public class EventState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EventId { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }

    public class ViagogoWatcherContext : DbContext
    {
        public ViagogoWatcherContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<EventState> Events { get; set; }
        public DbSet<SubscriptionState> Subscriptions { get; set; }
        public DbSet<UrlState> Urls { get; set; } 
    }
}
