using System;
using System.Collections.Generic;
using System.Linq;
using ViagogoWatcher.Model.Persistances;

namespace ViagogoWatcher.Model.Events
{
    public class EFEventRepository : IEventRepository
    {
        private ViagogoWatcherContext _viagogoWatcherContext;

        public EFEventRepository(ViagogoWatcherContext viagogoWatcherContext)
        {
            _viagogoWatcherContext = viagogoWatcherContext;
        }

        public IEnumerable<Event> GetAll()
        {
            var eventStates = _viagogoWatcherContext.Events;
            List<EventState> listEventStates = eventStates.ToList();
            return listEventStates.Select(x => new Event(x));
        }

        public void Add(Event @event)
        {
            var events = _viagogoWatcherContext.Set<EventState>();
            events.Add(@event.State);
            _viagogoWatcherContext.SaveChanges();
        }

        public Event FindByCode(string codeEvent)
        {
            var @event = _viagogoWatcherContext.Events.SingleOrDefault(x => x.Code == codeEvent);
            if (@event == null)
            {
                return Event.NotFound;
            }
            return new Event(@event);
        }
    }
}