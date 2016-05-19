using System;
using System.Configuration;
using System.Reflection;
using System.Threading.Tasks;
using EcosystemUserJourneys.LoadTesting.DataCollection;
using NUnit.Framework;
using NUnit.Framework.Compatibility;

namespace EcosystemUserJourneys.LoadTesting.LoadTest
{
    [TestFixture]
    public class UserJourneysLoadTest
    {
        [Test]
        public void UserRegistration()
        {
            var maxNumberOfUsers = int.Parse(ConfigurationManager.AppSettings.Get("NumberOfUsers"));
            var timeToRun = double.Parse(ConfigurationManager.AppSettings.Get("TimePeriod"));
            var testStopWatch = new Stopwatch();
            testStopWatch.Start();
            while (testStopWatch.Elapsed < TimeSpan.FromMinutes(timeToRun))
            {
                Parallel.For(1, maxNumberOfUsers, i =>
                {
                    var data = new DataCollectionModel { StartTime = DateTime.UtcNow, TestName = MethodBase.GetCurrentMethod().Name };
                    
                    //TODO something there that builds and end to end test

                });
            }
        }
    }
}
