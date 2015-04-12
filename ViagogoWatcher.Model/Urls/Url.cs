using System.Collections.Generic;
using ViagogoWatcher.Model.Persistances;

namespace ViagogoWatcher.Model.Urls
{
    public class Url
    {
        internal UrlState State;

        private sealed class URLEqualityComparer : IEqualityComparer<Url>
        {
            public bool Equals(Url x, Url y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(ToString(), y.ToString());
            }

            public int GetHashCode(Url obj)
            {
                return (obj != null ? obj.ToString().GetHashCode() : 0);
            }
        }

        private static readonly IEqualityComparer<Url> URLComparerInstance = new URLEqualityComparer();

        public static IEqualityComparer<Url> URLComparer
        {
            get { return URLComparerInstance; }
        }

        public Url(string url)
        {
            State = new UrlState();
            State.Url = url;
        }

        public override string ToString()
        {
            return State.Url;
        }
    }
}