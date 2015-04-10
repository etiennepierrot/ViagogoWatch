using Topshelf;

namespace ViagogoWatcher.ConsoleWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>                                 
            {
                x.Service<ViagogoAlert>(s =>                        
                {
                    s.ConstructUsing(name => new ViagogoAlert());    
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
