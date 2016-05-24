using System;
using System.Configuration;
using EcosystemUserJourneys.TestData;
using OpenQA.Selenium;
using WebDriverAutomationFramework;

namespace EcosystemUserJourneys.PageObjects.Intractions.PageObjects
{
    public class BasePageObject
    {
        public IProvidePageObjectBaseFunctions baseFunctions;
        public IWebDriver Driver { get; set; }

        public BasePageObject(string driver)
        {
            if (string.IsNullOrEmpty(driver))
            {
                throw new Exception("driver name not cannot create Driver instance");
            }

            var factory = new BaseOperationsFactory();
            this.baseFunctions = factory.Create(driver);
            this.Driver = baseFunctions.Driver;
        }

        public void OpenWebPage(string url)
        {
            var key = this.baseFunctions.GetMatchingPropertyName(url, typeof(Constants)).ToString();
            var stringUrl = ConfigurationManager.AppSettings.Get(key);
            var navigationUri = new Uri(stringUrl);
            this.baseFunctions.NavigateToUrl(navigationUri);
        }

        public void OpenWebPage(Uri navigationUri)
        {
            this.baseFunctions.NavigateToUrl(navigationUri);
        }
    }
}