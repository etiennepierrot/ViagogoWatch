namespace ViagogoWatcher.Model.Alerts
{
    public interface IViagogoAlert
    {
        void Start();
        void Watch();
        void Stop();
    }
}