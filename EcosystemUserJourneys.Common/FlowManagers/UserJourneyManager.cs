using System;
using System.Configuration;
using EcosystemUserJourneys.PageObjects.Intractions.PageObjects;
using EcosystemUserJourneys.TestData;
using EcosystemUserJourneys.TestData.Enums;
using EcosystemUserJourneys.TestData.Model;

namespace EcosystemUserJourneys.PageObjects.Intractions.FlowManagers
{
    public class UserJourneyManager
    {
        private SignInAndRegistrationPageObjects signInAndRegistrationPageObject;

        public UserJourneyManager(string driver)
        {
            this.signInAndRegistrationPageObject = new SignInAndRegistrationPageObjects(driver);
        }

        public void BuyItems(int numberOfItems, ItemType itemType)
        {
            //TODO
        }

        public void RegisterOnReebonz(User userDetails, RegistrationType registrationType)
        {
            var url = new Uri(ConfigurationManager.ConnectionStrings["LandingPage"].ConnectionString);

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