namespace ViagogoWatcher.Model.Urls
{
    public class Url
    {
        private readonly string _url;

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