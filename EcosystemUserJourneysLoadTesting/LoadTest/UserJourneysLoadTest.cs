using System;
using System.Configuration;
using System.Reflection;
using System.Threading.Tasks;
using EcosystemUserJourneys.LoadTesting.DataCollection;
using EcosystemUserJourneys.PageObjects.Intractions.FlowManagers;
using EcosystemUserJourneys.TestData.DataSetupHelpers;
using EcosystemUserJourneys.TestData.Enums;
using EcosystemUserJourneys.TestData.Model;
using NUnit.Framework;
using NUnit.Framework.Compatibility;

namespace EcosystemUserJourneys.LoadTesting.LoadTest
{
    [TestFixture]
    public class UserJourneysLoadTest
    {
        [TestCase(4, ItemType.MarketPlace)]
        public void UserRegistrationAndBuyingItems(int numberOfItems, ItemType itemType)
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

                    var userJourneyManager = new UserJourneyManager("chrome");
                    var user = new UserCreationHelper().BasicUser;
                    userJourneyManager.RegisterOnReebonz(user, RegistrationType.ViaEmail);
                    userJourneyManager.BuyItems(numberOfItems, itemType);
                    data.EndTime = DateTime.UtcNow;
                    data.TotalTime = (data.StartTime - data.EndTime).Seconds;

                    data.SuccessfulResult = CheckResult(user);
                    DataCollector.DataModelCollection.Add(data);
                    userJourneyManager.Driver.Quit();
                });
            }
        }

        private static bool CheckResult(User user)
        {
            throw new NotImplementedException();
        }
    }
}
