using Topshelf;

namespace ConsoleWatcher
{
    class Program
    {
        static void Main(string[] args)
        {


            HostFactory.Run(x =>                                 //1
            {
                x.Service<ViagogoAlert>(s =>                        //2
                {
                    s.ConstructUsing(name => new ViagogoAlert());     //3
                    s.WhenStarted(tc => tc.Watch());              //4
                    s.WhenStopped(tc => tc.Stop());               //5
                });
                x.RunAsLocalSystem();                            //6

                x.SetDescription("ViagogoWatcher");        //7
                x.SetDisplayName("ViagogoWatcher");                       //8
                x.SetServiceName("ViagogoWatcher");                       //9
            });           




            

            
        }
    }
}
