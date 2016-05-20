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
        public IWebDriver Driver { get; set; }

        public UserJourneyManager(string driver)
        {
            this.signInAndRegistrationPageObject = new SignInAndRegistrationPageObjects(driver);
            this.Driver = this.signInAndRegistrationPageObject.Driver;
        }

        public void BuyItems(int numberOfItems, ItemType itemType)
        {
            //TODO
        }

        public void RegisterOnReebonz(User userDetails, RegistrationType registrationType)
        {
            var url = new Uri(ConfigurationManager.ConnectionStrings["LandingPage"].ConnectionString);
            signInAndRegistrationPageObject.OpenWebPage(url);
            switch (registrationType)
            {
                case RegistrationType.ViaEmail:
                    signInAndRegistrationPageObject.RegisterViaEmail(url, userDetails);
                    break;
                case RegistrationType.ViaFacebook:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(registrationType), registrationType, null);
            }

        }
    }
}