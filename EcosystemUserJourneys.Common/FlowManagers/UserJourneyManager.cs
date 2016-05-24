using System;
using System.Configuration;
using EcosystemUserJourneys.PageObjects.Intractions.Enums;
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
        private readonly CategorySearchResultPageObject categorySearchResultPageObject;
        private readonly HeaderPageObject headerPageObject;
        private readonly CheckoutPageObject checkoutPageObject;
        public IWebDriver Driver { get; private set; }

        public UserJourneyManager(string driver)
        {
            this.signInAndRegistrationPageObject = new SignInAndRegistrationPageObjects(driver);
            this.Driver = this.signInAndRegistrationPageObject.Driver;
            var baseFunction = this.signInAndRegistrationPageObject.BaseFunctions;
            this.categorySearchResultPageObject = new CategorySearchResultPageObject(this.Driver, baseFunction);
            this.headerPageObject = new HeaderPageObject(this.Driver, baseFunction);
            this.checkoutPageObject = new CheckoutPageObject(this.Driver, baseFunction);

            this.baseUrl = new Uri(ConfigurationManager.ConnectionStrings["LandingPage"].ConnectionString);
        }

        public void BuyItemsFromCategory(int numberOfItems, ProductCategoryType cateogryType, User user)
        {
            switch (cateogryType)
            {
                case ProductCategoryType.Men:
                    this.headerPageObject.OpenMenCategory("watches");
                    break;
                case ProductCategoryType.Women:
                    this.headerPageObject.OpenWomenCategory("watches");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cateogryType), cateogryType, null);
            }
            this.categorySearchResultPageObject.AddItemsToCart(numberOfItems);
            this.headerPageObject.ProceedToCheckout();
            this.checkoutPageObject.Checkout(true, true, true, PaymentMethod.Cards, user);
        }

        public void RegisterOnReebonz(User userDetails, RegistrationType registrationType)
        {
            signInAndRegistrationPageObject.OpenWebPage(baseUrl);
            switch (registrationType)
            {
                case RegistrationType.ViaEmail:
                    signInAndRegistrationPageObject.RegisterViaEmail(userDetails);
                    break;
                case RegistrationType.ViaFacebook:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationType), registrationType, null);
            }

        }
    }
}