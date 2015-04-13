using System.Collections.Generic;

namespace ViagogoWatcher.Model.Events
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        void Add(Event @event);
        Event FindByCode(string codeEvent);
    }
}