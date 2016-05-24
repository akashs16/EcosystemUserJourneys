using System;
using EcosystemUserJourneys.PageObjects.Intractions.Identifiers;
using EcosystemUserJourneys.TestData.Model;
using WebDriverAutomationFramework;

namespace EcosystemUserJourneys.PageObjects.Intractions.PageObjects
{
    public class SignInAndRegistrationPageObjects : BasePageObject
    {
        public SignInAndRegistrationPageObjects(string driver) : base(driver)
        {
        }

        public void RegisterViaEmail(Uri url, User user)
        {
            this.baseFunctions.ClickOnElement(HomePageIdentifiers.RegistrationLinkCss, WebElementType.CssSelector, TimeSpan.FromSeconds(2));
            this.baseFunctions.WaitForLoad(RegistrationOverlay.RegistrationModalClass, WebElementType.Class, TimeSpan.FromSeconds(3));
            this.baseFunctions.ClearAndSendText(RegistrationOverlay.FirstNameTextFieldId, WebElementType.Id, user.FirstName);
            this.baseFunctions.ClearAndSendText(RegistrationOverlay.LastNameTextFieldId, WebElementType.Id, user.LastName);
            this.baseFunctions.ClearAndSendText(RegistrationOverlay.EmailTextFieldId, WebElementType.Id, user.EmailAddress);
            this.baseFunctions.ClearAndSendText(RegistrationOverlay.PassowrdTextFieldId, WebElementType.Id, user.Password);
            this.baseFunctions.ClearAndSendText(RegistrationOverlay.ConfirmPasswordTextFieldId, WebElementType.Id, user.Password);

            // this to get to the registration button and perform a submit on it
            var element = this.baseFunctions.GetElement("div.form-group", WebElementType.CssSelector);
            var button = this.baseFunctions.GetElement(element, WebElementType.CssSelector, ":first-child");
            this.baseFunctions.PerformSubmit(button, TimeSpan.FromSeconds(8));
        }
    }
}