using System.Configuration;
using Topshelf;
using ViagogoWatcher.Model.DependancyInjector;
using ViagogoWatcher.Model.Events;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.ConsoleWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>                                 
            {
                x.Service<IClockTimer>(s =>                        
                {
                    s.ConstructUsing(name => ViagogoAlert());    
                    s.WhenStarted(tc => tc.Watch());             
                    s.WhenStopped(tc => tc.Stop());              
                });
                x.RunAsLocalSystem();                            

                x.SetDescription("ViagogoWatcher");       
                x.SetDisplayName("ViagogoWatcher");                     
                x.SetServiceName("ViagogoWatcher");                       
            });      
            
        }

        private static IClockTimer ViagogoAlert()
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
