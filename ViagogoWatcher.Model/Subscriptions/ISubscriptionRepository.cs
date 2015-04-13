using System.Collections.Generic;
using System.Linq;
using ViagogoWatcher.Model.Persistances;

namespace ViagogoWatcher.Model.Subscriptions
{
    public interface ISubscriptionRepository
    {
        IEnumerable<Subscription> GetSubscriptionsByEvent(string codeEvent);
        void Add(Subscription subscription);
        void Save();
        void DeleteByCode(string codeSubscription);
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

        public void DeleteByCode(string codeSubscription)
        {
            var subcription = _viagogoWatcherContext.Subscriptions.Single(x => x.CodeSubscription == codeSubscription);
            DeleteSubsciption(subcription);
        }

        private void DeleteSubsciption(SubscriptionState subcription)
        {
            var subscriptionStates = _viagogoWatcherContext.Set<SubscriptionState>();
            var urls = _viagogoWatcherContext.Set<UrlState>();
            urls.RemoveRange(subcription.UrlStates);
            subscriptionStates.Remove(subcription);
            _viagogoWatcherContext.SaveChanges();
        }
    }
}