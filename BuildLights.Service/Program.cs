using System;
using System.Text;
using BuildLights.Service.Properties;
using Topshelf;
using MicrosoftBuildStatus = Microsoft.TeamFoundation.Build.Client.BuildStatus; 


namespace BuildLights.Service
{
    class Program
    {
        static void Main(string[] args)
        {

            var bdc = new BuildDefinitionCriteria
            {
                ServerAddress = Settings.Default.ServerAddress,
                BuildDefinitionName = Settings.Default.BuildDefinitionName,
                TeamProjectName = Settings.Default.TeamProjectName
            };
            var checkInterval = TimeSpan.FromSeconds(Settings.Default.CheckInterval);
            var rc = HostFactory.Run(x =>                                   
            {
                x.Service<BuildLightsService>(s =>                                  
                {
                    s.ConstructUsing(name => new BuildLightsService(bdc, checkInterval));             
                    s.WhenStarted(tc => tc.Start());                        
                    s.WhenStopped(tc => tc.Stop());                         
                });
                x.RunAsLocalSystem();                                       

                x.SetDescription("TFS Build Status Fetch Service");
                x.SetDisplayName("TFSBuildStatusFetchService");
                x.SetServiceName("TFSBuildStatusFetchService");                                  
            });                                                             

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  
            Environment.ExitCode = exitCode;
        }
    }
}
