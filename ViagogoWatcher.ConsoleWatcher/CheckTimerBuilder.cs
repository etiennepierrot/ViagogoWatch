using ViagogoWatcher.Model.DependancyInjector;
using ViagogoWatcher.Model.Events;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.ConsoleWatcher
{
    public class CheckTimerBuilder
    {
        private IMailerService _mailerService;
        private IEventChecker _eventChecker;

        public CheckTimerBuilder()
        {
            _mailerService = new MailerServiceBuilder().Build();
            _eventChecker = new EventCheckerBuilder().Build();
        }

        public CheckTimerBuilder WithMailService(IMailerService mailerService)
        {
            _mailerService = mailerService;
            return this;
        }

        public CheckTimerBuilder WithEventChecker(IEventChecker eventChecker)
        {
            _eventChecker = eventChecker;
            return this;
        }

        public IClockTimer Build()
        {
            return new ClockTimer(_mailerService, _eventChecker);
        }
    }
}