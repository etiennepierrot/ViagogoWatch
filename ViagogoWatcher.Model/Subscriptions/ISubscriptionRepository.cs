using System.Collections.Generic;
using System.Linq;
using ViagogoWatcher.Model.Moneys;
using ViagogoWatcher.Model.Persistances;

namespace ViagogoWatcher.Model.Subscriptions
{
    public interface ISubscriptionRepository
    {
        IEnumerable<Subscription> GetSubscriptionsByEvent(string codeEvent);
        void Add(Subscription subscription);
        void Save();
    }

    public class EFSubscriptionRepository : ISubscriptionRepository
    {
        private ViagogoWatcherContext _viagogoWatcherContext;

        public EFSubscriptionRepository(ViagogoWatcherContext viagogoWatcherContext)
        {
            _viagogoWatcherContext = viagogoWatcherContext;
        }


        public IEnumerable<Subscription> GetSubscriptionsByEvent(string codeEvent)
        {
            var eventStates = _viagogoWatcherContext.Subscriptions.Where(x => x.CodeEvent == codeEvent).ToList();
            return eventStates.Select(x => new Subscription(x));

        }

        public void Add(Subscription subscription)
        {
            var subscriptionStates = _viagogoWatcherContext.Set<SubscriptionState>();
            subscriptionStates.Add(subscription.State);
            _viagogoWatcherContext.SaveChanges();
        }

        public void Save()
        {
            _viagogoWatcherContext.SaveChanges();
        }
    }

    public class TestSubscriptionRepository : ISubscriptionRepository
    {
        public IEnumerable<Subscription> GetSubscriptionsByEvent(string codeEvent)
        {
            return new List<Subscription>
            {
                new Subscription(new Money(150), 1, "etienne.pierrot@gmail.com", codeEvent)
            };
        }

        public void Add(Subscription subscription)
        {
            
        }

        public void Save()
        {
            
        }
    }
}