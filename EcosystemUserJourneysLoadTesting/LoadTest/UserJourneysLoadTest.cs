using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using EcosystemUserJourneys.LoadTesting.DataCollection;
using EcosystemUserJourneys.PageObjects.Intractions.FlowManagers;
using EcosystemUserJourneys.TestData.DataSetupHelpers;
using EcosystemUserJourneys.TestData.Enums;
using EcosystemUserJourneys.TestData.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Compatibility;

namespace EcosystemUserJourneys.LoadTesting.LoadTest
{
    [TestFixture]
    public class UserJourneysLoadTest
    {
        private int maxNumberOfUsers;
        private double timeToRun;
        private string path;

        [SetUp]
        public void Setup()
        {
            DataCollector.DataModelCollection = new List<DataCollectionModel>();
            this.maxNumberOfUsers = int.Parse(ConfigurationManager.AppSettings.Get("NumberOfUsers"));
            this.timeToRun = double.Parse(ConfigurationManager.AppSettings.Get("TimePeriod"));
            this.path = GetPath() + "\\results-" + DateTime.UtcNow.ToString("yyyyMMdd-hhmmssff") + ".json";
        }

        [TestCase(4, ProductCategoryType.Men)]
        public void UserRegistrationAndBuyingItems(int numberOfItems, ProductCategoryType productCategoryType)
        {

            var testStopWatch = new Stopwatch();
            testStopWatch.Start();
            while (testStopWatch.Elapsed < TimeSpan.FromMinutes(timeToRun))
            {
                Parallel.For(1, maxNumberOfUsers, i =>
                {
                    var data = new DataCollectionModel
                    {
                        StartTime = DateTime.UtcNow,
                        TestName = MethodBase.GetCurrentMethod().Name
                    };
                    try
                    {
                        var userJourneyManager = new UserJourneyManager("chrome");
                        var user = new UserCreationHelper().BasicUser;
                        userJourneyManager.RegisterOnReebonz(user, RegistrationType.ViaEmail);
                        userJourneyManager.BuyItemsFromCategory(numberOfItems, productCategoryType);

                        data.EndTime = DateTime.UtcNow;
                        data.TotalTimeInSeconds = (data.EndTime - data.StartTime).Seconds;
                        data.SuccessfulResult = CheckResult(user);
                        DataCollector.DataModelCollection.Add(data);
                        userJourneyManager.Driver.Quit();
                    }
                    catch (Exception)
                    {
                        data.EndTime = DateTime.UtcNow;
                        data.SuccessfulResult = false;
                    }
                });
            }

            var timings = JsonConvert.SerializeObject(DataCollector.DataModelCollection);
            using (var writer = new StreamWriter(this.path))
            {
                writer.Write(timings);
                writer.Flush();
            }
        }

        private static string GetPath()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        private static bool CheckResult(User user)
        {
            return true;
        }
    }
}
