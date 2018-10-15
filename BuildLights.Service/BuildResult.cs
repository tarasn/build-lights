using System;
using Microsoft.TeamFoundation.Build.Client;

namespace BuildLights.Service
{
    class BuildResult
    {
        public string BuildNumber { get; set; }
        public DateTime FinishTime { get; set; }
        public DateTime LastChangedOn { get; set; }
        public BuildStatus BuildStatus { get; set; }
        public DateTime StartTime { get; set; }
    }
}