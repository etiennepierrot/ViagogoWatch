using System.Collections.Generic;

namespace ViagogoWatcher.Model.Urls
{
    public class Url
    {
        private readonly string _url;

        private sealed class URLEqualityComparer : IEqualityComparer<Url>
        {
            public bool Equals(Url x, Url y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x._url, y._url);
            }

            public int GetHashCode(Url obj)
            {
                return (obj._url != null ? obj._url.GetHashCode() : 0);
            }
        }

        private static readonly IEqualityComparer<Url> URLComparerInstance = new URLEqualityComparer();

        public static IEqualityComparer<Url> URLComparer
        {
            get { return URLComparerInstance; }
        }

        public Url(string url)
        {
            _url = url;
        }

        public override string ToString()
        {
            return _url;
        }
    }
}