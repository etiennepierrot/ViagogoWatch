using System.Configuration;
using System.Timers;
using ViagogoWatcher.Model.Events;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.Service
{
    public class ClockTimer : IClockTimer
    {
        private readonly Timer _timer;
        public readonly IMailerService _mailerService;
        private readonly IEventChecker _eventChecker;


        public ClockTimer(IMailerService mailerService, IEventChecker eventChecker)
        {
            _mailerService = mailerService;
            int interval = int.Parse(ConfigurationManager.AppSettings["TimingRefreshInMs"]);
            _timer = new Timer(interval)
            {
                AutoReset = true,
                Enabled = true,
            };
            _timer.Elapsed += (sender, args) => Watch();
            _eventChecker = eventChecker;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Watch()
        {
            _eventChecker.Check();
        }

        public void Stop()
        {
            _timer.Stop();
            _mailerService.Stop();
        }


    }
}