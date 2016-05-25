namespace EcosystemUserJourneys.MarketPlace.PageObjects.Intractions.PageObjects
{
    using OpenQA.Selenium;
    using WebDriverAutomationFramework;

    public class HomePagePageObject:BasePageObject
    {
        public HomePagePageObject(string driver) : base(driver)
        {
        }

        public HomePagePageObject(IWebDriver driver, IProvidePageObjectBaseFunctions baseFunctions) : base(driver, baseFunctions)
        {
        }
    }
}