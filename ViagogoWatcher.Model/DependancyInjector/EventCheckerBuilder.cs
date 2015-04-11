﻿using ViagogoWatcher.Model.Connector;
using ViagogoWatcher.Model.Events;
using ViagogoWatcher.Model.Mailings;
using ViagogoWatcher.Model.Subscriptions;

namespace ViagogoWatcher.Model.DependancyInjector
{
    public class EventCheckerBuilder
    {
        private IEventRepository _eventRepository;
        private IViagogoConnector _viagogoConnector;
        private ISubscriptionRepository _subscriptionRepository;
        private IMailerService _mailerService;

        public EventCheckerBuilder()
        {
            _eventRepository = new EventRepository();
            _viagogoConnector = new ViagogoConnector();
            _subscriptionRepository = new SubscriptionRepository();
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