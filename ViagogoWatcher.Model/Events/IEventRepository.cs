using System.Collections.Generic;

namespace ViagogoWatcher.Model.Events
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        void Add(Event @event);
    }

    public class TestEventRepository : IEventRepository
    {
        public IEnumerable<Event> GetAll()
        {
            return new List<Event>
            {
                new Event( "E-915795","http://www.viagogo.fr/psg/Billets-de-sport/Football/Ligue-1/Paris-Saint-Germain-Billets/E-915795", "PSG- Barca")
            };
        }

        public void Add(Event @event)
        {
            
        }
    }
}