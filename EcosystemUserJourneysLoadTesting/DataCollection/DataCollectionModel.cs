using System;

namespace EcosystemUserJourneys.LoadTesting.DataCollection
{
    public class DataCollectionModel
    {
        public string TestName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan TotalTime { get; set; }
    }
}