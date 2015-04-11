using System.Collections.Generic;
using ViagogoWatcher.Model.Moneys;

namespace ViagogoWatcher.Model.Subscriptions
{
    public interface ISubscriptionRepository
    {
        IEnumerable<Subscription> GetSubscriptionsByEventId(string eventId);
    }

    public class SubscriptionRepository : ISubscriptionRepository
    {
        public IEnumerable<Subscription> GetSubscriptionsByEventId(string eventId)
        {
            return new List<Subscription>
            {
                new Subscription(new Money(150), 1, "etienne.pierrot@gmail.com")
            };
        }
    }
}