using Topshelf;
using ViagogoWatcher.Service;

namespace ViagogoWatcher.ConsoleWatcher
{
    public class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>                                 
            {
                x.Service<IClockTimer>(s =>                        
                {
                    s.ConstructUsing(name => ClockTimerBuilder.Build());    
                    s.WhenStarted(tc => tc.Watch());             
                    s.WhenStopped(tc => tc.Stop());              
                });
                x.RunAsLocalSystem();                            

                x.SetDescription("ViagogoWatcher");       
                x.SetDisplayName("ViagogoWatcher");                     
                x.SetServiceName("ViagogoWatcher");                       
            });      
            
        }

        
    }
}
