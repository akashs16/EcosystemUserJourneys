namespace EcosystemUserJourneys.AcceptanceTests.Steps
{
    using System;
    using PageObjects.Intractions.FlowManagers;
    using TechTalk.SpecFlow;
    using TestData.DataSetupHelpers;
    using TestData.Enums;
    using TestData.Model;

    [Binding]
    public class SignInAndRegistrationSteps
    {
        private User user;
        private UserJourneyManager userJourneyManager;

        [Given(@"I am using (.*) browser")]
        public void GivenIAmUsingBrowser(string browser)
        {
            this.userJourneyManager = new UserJourneyManager(browser);
        }

        [Given(@"I am a first time Reebonz user")]
        public void GivenIamAFirstTimeReebonzUser()
        {
            var userCreationHelper = new UserCreationHelper();
            this.user = userCreationHelper.BasicUser;
        }

        [When(@"I register on Reebonz")]
        public void WhenIRegisterOnReebonz()
        {
            this.userJourneyManager.RegisterOnReebonz(this.user, RegistrationType.ViaEmail);
        }

        [When(@"I try to buy (.*) numbers of items from (.*) merchant")]
        public void WhenITryToBuyNumbersOfItemsFromReebonzMerchant(int numberOfItems, string itemTypeFromFeature)
        {
            var itemType = EnumValueForString<ItemType>(itemTypeFromFeature);
            this.userJourneyManager.BuyItemsFromCategory(numberOfItems, ProductCategoryType.Women, this.user);
        }

        [Then(@"I should be successfully be able to by the item or items")]
        public void ThenIShouldBeSuccessfullyBeAbleToByTheItemOrItems()
        {
        }

        private static T EnumValueForString<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
