using System.Collections.Generic;
using System.Linq;
using ViagogoWatcher.Model.Connector;
using ViagogoWatcher.Model.Mailings;
using ViagogoWatcher.Model.Subscriptions;
using ViagogoWatcher.Model.Urls;

namespace ViagogoWatcher.Model.Events
{
    public interface IEventChecker
    {
        void Check();
        void CheckEvent(Event @event);
    }

    public class EventChecker : IEventChecker
    {
        private readonly IEventRepository _eventRepository;
        private readonly IViagogoConnector _viagogoConnector;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMailerService _mailerService;

        public EventChecker(IEventRepository eventRepository, IViagogoConnector viagogoConnector, ISubscriptionRepository subscriptionRepository, IMailerService mailerService)
        {
            _eventRepository = eventRepository;
            _viagogoConnector = viagogoConnector;
            _subscriptionRepository = subscriptionRepository;
            _mailerService = mailerService;
        }

        public void Check()
        {
            var events = _eventRepository.GetAll();
            foreach (var @event in events)
            {
                CheckEvent(@event);
            }
        }

        public void CheckEvent(Event @event)
        {
            var products = _viagogoConnector.GetProduct(@event.Url);
            IEnumerable<Subscription> subscriptions = _subscriptionRepository.GetSubscriptionsByEvent(@event.Code);

            foreach (var subscription in subscriptions)
            {
                var productDtosToSend = subscription.Match(products);
                _mailerService.SendAlert(subscription.Email, @event.Name, productDtosToSend);
                subscription.SetUrlSended(productDtosToSend.Select(x => new Url(x.BuyUrl)));
                _subscriptionRepository.Save();
            }

        }
    }
}