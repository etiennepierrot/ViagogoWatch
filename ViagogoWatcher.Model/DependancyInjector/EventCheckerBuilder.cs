using ViagogoWatcher.Model.Connector;
using ViagogoWatcher.Model.Events;
using ViagogoWatcher.Model.Mailings;
using ViagogoWatcher.Model.Persistances;
using ViagogoWatcher.Model.Subscriptions;

namespace ViagogoWatcher.Model.DependancyInjector
{

    public static class EventRepositoryBuilder
    {
        public static IEventRepository Build()
        {
            return new EFEventRepository(new ViagogoWatcherContext());
        }
    }

    public class EventCheckerBuilder
    {
        private IEventRepository _eventRepository;
        private IViagogoConnector _viagogoConnector;
        private ISubscriptionRepository _subscriptionRepository;
        private IMailerService _mailerService;

        public EventCheckerBuilder()
        {
            ViagogoWatcherContext viagogoWatcherContext = new ViagogoWatcherContext();
            _eventRepository = new EFEventRepository(viagogoWatcherContext);
            _viagogoConnector = new ViagogoConnector();
            _subscriptionRepository = new EFSubscriptionRepository(viagogoWatcherContext);
            _mailerService = new MailerServiceBuilder().Build();
        }

        public EventCheckerBuilder WithMailserService(IMailerService mailerService)
        {
            _mailerService = mailerService;
            return this;
        }

        public EventCheckerBuilder WithViagogoConnector(IViagogoConnector viagogoConnector)
        {
            _viagogoConnector = viagogoConnector;
            return this;
        }

        public IEventChecker Build()
        {
            return new EventChecker(_eventRepository, _viagogoConnector, _subscriptionRepository, _mailerService);
        }
    }
}
