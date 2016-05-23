using System;
using System.Configuration;
using EcosystemUserJourneys.PageObjects.Intractions.PageObjects;
using EcosystemUserJourneys.TestData.Enums;
using EcosystemUserJourneys.TestData.Model;
using OpenQA.Selenium;

namespace EcosystemUserJourneys.PageObjects.Intractions.FlowManagers
{
    public class UserJourneyManager
    {
        private readonly SignInAndRegistrationPageObjects signInAndRegistrationPageObject;
        private readonly Uri baseUrl;
        private readonly HomePagePageObject homePagePageObject;
        private readonly CategoryResultPageObject categoryResultPageObject;
        private readonly ShoppingCartPageObject shoppingCartPageObject;
        private readonly CheckoutPageObject checkoutPageObject;
        public IWebDriver Driver { get; private set; }

        public UserJourneyManager(string driver)
        {
            this.signInAndRegistrationPageObject = new SignInAndRegistrationPageObjects(driver);
            this.Driver = this.signInAndRegistrationPageObject.Driver;

            this.homePagePageObject = new HomePagePageObject(driver);
            this.categoryResultPageObject = new CategoryResultPageObject(driver);
            this.shoppingCartPageObject = new ShoppingCartPageObject(driver);
            this.checkoutPageObject = new CheckoutPageObject(driver);

            this.baseUrl = new Uri(ConfigurationManager.ConnectionStrings["LandingPage"].ConnectionString);
        }

        public void BuyItemsFromCategory(int numberOfItems, ProductCategoryType cateogryType)
        {
            switch (cateogryType)
            {
                case ProductCategoryType.Men:
                    this.homePagePageObject.OpenMenCategory("watches");
                    break;
                case ProductCategoryType.Women:
                    this.homePagePageObject.OpenWomenCategory("watches");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cateogryType), cateogryType, null);
            }
            this.categoryResultPageObject.AddItemsToCart(numberOfItems);
            this.shoppingCartPageObject.ProceedToCheckout();
            this.checkoutPageObject.Checkout();
        }

        public void RegisterOnReebonz(User userDetails, RegistrationType registrationType)
        {
            signInAndRegistrationPageObject.OpenWebPage(baseUrl);
            switch (registrationType)
            {
                case RegistrationType.ViaEmail:
                    signInAndRegistrationPageObject.RegisterViaEmail(baseUrl, userDetails);
                    break;
                case RegistrationType.ViaFacebook:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationType), registrationType, null);
            }

        }
    }
}