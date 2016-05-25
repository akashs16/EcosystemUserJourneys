namespace EcosystemUserJourneys.UserUsageTesting.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using DataCollection;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using PageObjects.Intractions.FlowManagers;
    using TestData.DataSetupHelpers;
    using TestData.Enums;
    using TestData.Model;

    [TestFixture]
    public class UserJourneysUsageTest
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

        [TestCase(2, ProductCategoryType.Men)]
        public void UserRegistrationAndBuyingItems(int numberOfItems, ProductCategoryType productCategoryType)
        {
            var userJourneyManager = new UserJourneyManager("chrome");
            var testStopWatch = new Stopwatch();
            testStopWatch.Start();
            while (testStopWatch.Elapsed < TimeSpan.FromMinutes(this.timeToRun))
            {
                Parallel.For(0, this.maxNumberOfUsers, i =>
                {
                    var data = new DataCollectionModel
                    {
                        StartTime = DateTime.UtcNow,
                        TestName = MethodBase.GetCurrentMethod().Name
                    };
                    try
                    {
                        var user = new UserCreationHelper().BasicUser;
                        userJourneyManager.RegisterOnReebonz(user, RegistrationType.ViaEmail);
                        userJourneyManager.BuyItemsFromCategory(numberOfItems, productCategoryType, user);

                        data.EndTime = DateTime.UtcNow;
                        data.TotalTimeInSeconds = (data.EndTime - data.StartTime).Seconds;
                        data.SuccessfulResult = CheckResult(user);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        data.EndTime = DateTime.UtcNow;
                        data.SuccessfulResult = false;
                    }
                    finally
                    {
                        DataCollector.DataModelCollection.Add(data);
                        userJourneyManager.Driver.Quit();
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
