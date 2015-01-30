namespace ViagogoWatcher.Model.Alerts
{
    public class AlertService
    {
        private readonly AlertRepository _alertRepository;

        public AlertService(AlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        public void Create(string url, long maxPrice, string[] emails, long nbPlaces, string category)
        {
            Alert alert = new Alert
            {
                Category = category,
                Emails = emails,
                MaxPrice = maxPrice,
                NbPlaces = nbPlaces,
                Url = url
            };

            _alertRepository.Insert(alert);

        }
    }
}