namespace EcosystemUserJourneys.Phoenix.PageObjects.Intractions.PageObjects
{
    using OpenQA.Selenium;
    using WebDriverAutomationFramework;

    public class LandingPagePageObjects: BasePageObject
    {
        public LandingPagePageObjects(string driver) : base(driver)
        {
        }

        public LandingPagePageObjects(IWebDriver driver, IProvidePageObjectBaseFunctions baeBaseFunctions) : base(driver, baeBaseFunctions)
        {
        }
    }
}