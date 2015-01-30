using ViagogoWatcher.Model.DAL;

namespace ViagogoWatcher.Model.Alerts
{
    public class AlertRepository
    {
        private readonly ViagogoContext _viagogoContext;

        public AlertRepository(ViagogoContext viagogoContext)
        {
            _viagogoContext = viagogoContext;
        }

        public void Insert(Alert alert)
        {
            _viagogoContext.Alerts.Add(alert);
            _viagogoContext.SaveChanges();
        }
    }
}