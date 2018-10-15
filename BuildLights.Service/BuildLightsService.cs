using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Client;

namespace BuildLights.Service
{
    class BuildLightsService
    {
        private readonly BuildDefinitionCriteria _buildDefinitionCriteria;
        private readonly TimeSpan _interval;
        private Task _taskChecker;
        readonly CancellationTokenSource _tokenSource = new CancellationTokenSource();

        public BuildLightsService(BuildDefinitionCriteria buildDefinitionCriteria, TimeSpan interval)
        {
            _buildDefinitionCriteria = buildDefinitionCriteria;
            _interval = interval;
        }

       

        public void Start()
        {
            _taskChecker = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var buildResults = FetchBuildResults();
                    Thread.Sleep(_interval);
                    if (_tokenSource.Token.IsCancellationRequested)
                    {
                        _tokenSource.Token.ThrowIfCancellationRequested();
                    }
                }
            }, _tokenSource.Token);
        }

        public void Stop()
        {
            _tokenSource.Cancel();
        }

        private IEnumerable<IBuildDetail> FetchBuildResults()
        {
            var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(_buildDefinitionCriteria.ServerAddress));
            tfs.EnsureAuthenticated();
            var buildServer = tfs.GetService<IBuildServer>();
            var buildSpec = buildServer.CreateBuildDetailSpec(_buildDefinitionCriteria.TeamProjectName,
                _buildDefinitionCriteria.BuildDefinitionName);
            buildSpec.InformationTypes = null;
            buildSpec.MinFinishTime = DateTime.Now.AddHours(-100);
            return buildServer.QueryBuilds(buildSpec).Builds.OrderByDescending(bd => bd.FinishTime);
        }


        private BuildResult ConvertTo(IBuildDetail buildDetail)
        {
            return new BuildResult
            {
                BuildNumber = buildDetail.BuildNumber,
                BuildStatus = buildDetail.Status,
                FinishTime = buildDetail.FinishTime,
                LastChangedOn = buildDetail.LastChangedOn,
                StartTime = buildDetail.StartTime
            };
        }

    }
}