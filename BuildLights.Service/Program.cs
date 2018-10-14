using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace BuildLights.Service
{
    class BuildLightsService
    {
        public void Start() {  }
        public void Stop() {  }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>                                   
            {
                x.Service<BuildLightsService>(s =>                                  
                {
                    s.ConstructUsing(name => new BuildLightsService());             
                    s.WhenStarted(tc => tc.Start());                        
                    s.WhenStopped(tc => tc.Stop());                         
                });
                x.RunAsLocalSystem();                                       

                x.SetDescription("Sample Topshelf Host");                   
                x.SetDisplayName("Stuff");                                  
                x.SetServiceName("Stuff");                                  
            });                                                             

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  
            Environment.ExitCode = exitCode;
        }
    }
}
