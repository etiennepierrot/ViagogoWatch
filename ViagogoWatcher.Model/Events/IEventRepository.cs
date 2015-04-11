using System.Collections.Generic;

namespace ViagogoWatcher.Model.Events
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
    }

    public class EventRepository : IEventRepository
    {
        public IEnumerable<Event> GetAll()
        {
            return new List<Event>
            {
                new Event
                {
                    Id = "E-915795",
                    Url = "http://www.viagogo.fr/psg/Billets-de-sport/Football/Ligue-1/Paris-Saint-Germain-Billets/E-915795",
                    Name = "PSG - Barca"
                }
            };
        }
    }
}