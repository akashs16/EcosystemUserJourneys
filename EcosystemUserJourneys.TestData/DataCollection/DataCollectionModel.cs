namespace EcosystemUserJourneys.MarketPlace.UserUsageTesting.DataCollection
{
    using System;

    public class DataCollectionModel
    {
        public string TestName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalTimeInSeconds { get; set; }
        public bool SuccessfulResult { get; set; }
    }
}