using System;
using EcosystemUserJourneys.PageObjects.Intractions;
using EcosystemUserJourneys.PageObjects.Intractions.PageObjects;
using EcosystemUserJourneys.TestData.DataSetupHelpers;
using EcosystemUserJourneys.TestData.Model;
using TechTalk.SpecFlow;

namespace EcosystemUserJourneys.AcceptanceTests.Steps
{
    [Binding]
    public class SignInAndRegistrationSteps
    {
        private User user;
        private SignInAndRegistrationPageObjects signInAndRegistrationPageObject;

        [Given(@"I am using (.*) browser")]
        public void GivenIAmUsingBrowser(string browser)
        {
            this.signInAndRegistrationPageObject = new SignInAndRegistrationPageObjects(browser);
        }

        [Given(@"I am a first time Reebonz user")]
        public void GivenIAmAFirstTimeReebonzUser()
        {
            var userCreationHelper = new UserCreationHelper();
            this.user = userCreationHelper.BasicUser;
        }

        [When(@"I register on Reebonz")]
        public void WhenIRegisterOnReebonz()
        {
            var url = new Uri("http://rbz-sit-node.azurewebsites.net/sg");
            this.signInAndRegistrationPageObject.RegisterViaEmail(url, user);
        }

        [When(@"I try to buy (.*) numbers of items from (.*) merchant")]
        public void WhenITryToBuyNumbersOfItemsFromReebonzMerchant(int p0, string merchantType)
        {
        }

        [Then(@"I should be successfully be able to by the item or items")]
        public void ThenIShouldBeSuccessfullyBeAbleToByTheItemOrItems()
        {
        }
    }
}
