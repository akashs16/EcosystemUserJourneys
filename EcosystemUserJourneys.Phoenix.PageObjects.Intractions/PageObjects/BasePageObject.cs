﻿namespace EcosystemUserJourneys.Phoenix.PageObjects.Intractions.PageObjects
{
    using System;
    using System.Configuration;
    using OpenQA.Selenium;
    using TestData;
    using WebDriverAutomationFramework;

    public class BasePageObject
    {
        public readonly IProvidePageObjectBaseFunctions BaseFunctions;
        public IWebDriver Driver { get; private set; }

        protected BasePageObject(string driver)
        {
            if (string.IsNullOrEmpty(driver))
            {
                throw new Exception("driver name not cannot create Driver instance");
            }

            var factory = new BaseOperationsFactory();
            this.BaseFunctions = factory.Create(driver);
            this.Driver = this.BaseFunctions.Driver;
        }

        protected BasePageObject(IWebDriver driver, IProvidePageObjectBaseFunctions baeBaseFunctions)
        {
            this.Driver = driver;
            this.BaseFunctions = baeBaseFunctions;
        }

        public void OpenWebPage(string url)
        {
            var key = this.BaseFunctions.GetMatchingPropertyName(url, typeof(Constants)).ToString();
            var stringUrl = ConfigurationManager.AppSettings.Get(key);
            var navigationUri = new Uri(stringUrl);
            this.BaseFunctions.NavigateToUrl(navigationUri);
        }

        public void OpenWebPage(Uri navigationUri)
        {
            this.BaseFunctions.NavigateToUrl(navigationUri);
        }
    }
}