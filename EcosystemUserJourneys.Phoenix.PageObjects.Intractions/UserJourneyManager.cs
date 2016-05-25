namespace EcosystemUserJourneys.Phoenix.PageObjects.Intractions
{
    using System;
    using System.Configuration;
    using OpenQA.Selenium;
    using PageObjects;
    using TestData.Enums;
    using TestData.Model;

    public class UserJourneyManager
    {
        private readonly HeaderPageObjects headerPageObject;
        private readonly Uri baseUrl;
        public readonly IWebDriver Driver;

        public UserJourneyManager(string driverName)
        {
            this.headerPageObject = new HeaderPageObjects(driverName);
            this.baseUrl = new Uri(ConfigurationManager.ConnectionStrings["HomePage"].ConnectionString);
            this.Driver = this.headerPageObject.Driver;
        }

        public void RegisterOnReebonz(User user, RegistrationType viaEmail)
        {
            switch (viaEmail)
            {
                case RegistrationType.ViaEmail:
                    this.headerPageObject.RegisterViaEmail(user);
                    break;
                case RegistrationType.ViaFacebook:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viaEmail), viaEmail, null);
            }
        }

        public void BuyItemsFromCategory(int numberOfItems, ProductCategoryType productCategoryType, User user, string categoryName)
        {
        }

        public void NavigateToHomePage()
        {
            this.headerPageObject.OpenWebPage(this.baseUrl);
        }
    }
}
