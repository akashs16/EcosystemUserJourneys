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
        private readonly HeaderPageObject headerPageObject;
        private readonly Uri baseUrl;
        public readonly IWebDriver Driver;
        private CategorySearchResultsPageObject categorySearchResultsPageObject;

        public UserJourneyManager(string driverName)
        {
            this.headerPageObject = new HeaderPageObject(driverName);
            this.baseUrl = new Uri(ConfigurationManager.ConnectionStrings["HomePage"].ConnectionString);
            this.Driver = this.headerPageObject.Driver;

            this.categorySearchResultsPageObject = new CategorySearchResultsPageObject(this.Driver, this.headerPageObject.BaseFunctions);
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
            switch (productCategoryType)
            {
                case ProductCategoryType.Men:
                    this.headerPageObject.SelectMaleCategory(categoryName);
                    break;
                case ProductCategoryType.Women:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(productCategoryType), productCategoryType, null);
            }

            this.categorySearchResultsPageObject.AddItemsToCart(numberOfItems);
        }

        public void NavigateToHomePage()
        {
            this.headerPageObject.OpenWebPage(this.baseUrl);
        }
    }
}
