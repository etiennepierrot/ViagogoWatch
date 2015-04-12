using System;
using ViagogoWatcher.Model.Persistances;

namespace ViagogoWatcher.Model.Events
{
    public class Event
    {
        public string Code
        {
            get { return State.Code; }
        }

        public string Url
        {
            get { return State.Url; }
        }

        public string Name
        {
            get { return State.Name; }
        }

        internal EventState State;

        public Event(string url, string name)
        {
            State = new EventState();
            State.Code = Guid.NewGuid().ToString("N");
            State.Url = url;
            State.Name = name;
        }

        internal Event(EventState state)
        {
            State = state;
        }


    }
}