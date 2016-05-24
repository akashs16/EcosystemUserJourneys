using OpenQA.Selenium;
using WebDriverAutomationFramework;

namespace EcosystemUserJourneys.PageObjects.Intractions.PageObjects
{
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