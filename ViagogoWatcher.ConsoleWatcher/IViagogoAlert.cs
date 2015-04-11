namespace ViagogoWatcher.ConsoleWatcher
{
    public interface IViagogoAlert
    {
        void Start();
        void Watch();
        void Stop();
    }
}