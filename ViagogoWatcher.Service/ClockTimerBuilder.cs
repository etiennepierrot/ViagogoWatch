using System.Configuration;
using ViagogoWatcher.ConsoleWatcher;
using ViagogoWatcher.Model.DependancyInjector;
using ViagogoWatcher.Model.Events;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.Service
{
    public static class ClockTimerBuilder
    {
        public static IClockTimer Build()
        {
            IConfMailingFactory confMailingFactory = new ConfMailingFactoryBuilder()
                .WithSettings(ConfigurationManager.AppSettings)
                .Build();

            ConfMailing confMailing = confMailingFactory.CreateConfMailing();

            IMailerService mailerService = new MailerServiceBuilder()
                .WithConfMailing(confMailing)
                .WithStmpClientFacade(new SmtpClientFacade(confMailing))
                .Build();

            IEventChecker eventChecker = new EventCheckerBuilder()
                .WithMailserService(mailerService)
                .Build();

            IClockTimer clockTimer = new CheckTimerBuilder()
                .WithEventChecker(eventChecker)
                .WithMailService(mailerService)
                .Build();

            return clockTimer;
        }
    }
}
