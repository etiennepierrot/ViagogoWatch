using System.Configuration;
using Topshelf;
using ViagogoWatcher.Model.Alerts;
using ViagogoWatcher.Model.DependancyInjector;
using ViagogoWatcher.Model.Mailings;

namespace ViagogoWatcher.ConsoleWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>                                 
            {
                x.Service<IViagogoAlert>(s =>                        
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

        private static IViagogoAlert ViagogoAlert()
        {
            IConfMailingFactory confMailingFactory = new ConfMailingFactoryBuilder()
                .WithSettings(ConfigurationManager.AppSettings)
                .Build();

            ConfMailing confMailing = confMailingFactory.CreateConfMailing();

            IMailerService mailerService = new MailerServiceBuilder()
                .WithConfMailing(confMailing)
                .Build();

            IViagogoAlert viagogoAlert = new ViagogoAlertBuilder()
                .WithMailService(mailerService)
                .Build();

            return viagogoAlert;
        }
    }
}
