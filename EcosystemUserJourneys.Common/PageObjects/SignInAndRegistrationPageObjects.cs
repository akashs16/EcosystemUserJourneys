namespace EcosystemUserJourneys.PageObjects.Intractions.PageObjects
{
    using System;
    using Identifiers;
    using TestData.Model;
    using WebDriverAutomationFramework;

    public class SignInAndRegistrationPageObjects : BasePageObject
    {
        public SignInAndRegistrationPageObjects(string driver) : base(driver)
        {
        }

        public void RegisterViaEmail(User user)
        {
            this.BaseFunctions.ClickOnElement(HomePageIdentifiers.RegistrationLinkCss, WebElementType.CssSelector, TimeSpan.FromSeconds(2));
            this.BaseFunctions.WaitForLoad(RegistrationOverlay.RegistrationModalClass, WebElementType.Class, TimeSpan.FromSeconds(3));
            this.BaseFunctions.ClearAndSendText(RegistrationOverlay.FirstNameTextFieldId, WebElementType.Id, user.FirstName);
            this.BaseFunctions.ClearAndSendText(RegistrationOverlay.LastNameTextFieldId, WebElementType.Id, user.LastName);
            this.BaseFunctions.ClearAndSendText(RegistrationOverlay.EmailTextFieldId, WebElementType.Id, user.EmailAddress);
            this.BaseFunctions.ClearAndSendText(RegistrationOverlay.PassowrdTextFieldId, WebElementType.Id, user.Password);
            this.BaseFunctions.ClearAndSendText(RegistrationOverlay.ConfirmPasswordTextFieldId, WebElementType.Id, user.Password);

            // this to get to the registration button and perform a submit on it
            var element = this.BaseFunctions.GetElement("div.form-group", WebElementType.CssSelector);
            var button = this.BaseFunctions.GetElement(element, WebElementType.CssSelector, ":first-child");
            this.BaseFunctions.PerformSubmit(button, TimeSpan.FromSeconds(10));
        }
    }
}