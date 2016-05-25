namespace EcosystemUserJourneys.Phoenix.PageObjects.Intractions.PageObjects
{
    using System;
    using OpenQA.Selenium;
    using Selectors;
    using TestData.Model;
    using WebDriverAutomationFramework;

    public class HeaderPageObjects : BasePageObject
    {
        public HeaderPageObjects(string driver) : base(driver)
        {
        }

        public HeaderPageObjects(IWebDriver driver, IProvidePageObjectBaseFunctions baeBaseFunctions) : base(driver, baeBaseFunctions)
        {
        }

        public void RegisterViaEmail(User user)
        {
            this.BaseFunctions.ClickOnElement(HeaderSelectors.RegistrationLinkClass, WebElementType.Class, TimeSpan.FromSeconds(2));
            this.BaseFunctions.WaitForLoad(RegistrationPopupSelectors.RegistrationPopUpCss, WebElementType.CssSelector, TimeSpan.FromSeconds(5));

            this.BaseFunctions.ClearAndSendText(RegistrationPopupSelectors.EmailAddressTextFieldCss, WebElementType.CssSelector, user.EmailAddress);
            this.BaseFunctions.ClearAndSendText(RegistrationPopupSelectors.PasswordTextFieldCss, WebElementType.CssSelector, user.Password);
            this.BaseFunctions.ClearAndSendText(RegistrationPopupSelectors.FirstNameTextFieldCss, WebElementType.CssSelector, user.FirstName);
            this.BaseFunctions.ClearAndSendText(RegistrationPopupSelectors.LastNameTextFieldCss, WebElementType.CssSelector, user.LastName);
            this.BaseFunctions.SelectWebElement(RegistrationPopupSelectors.GenderDropDownCss, WebElementType.CssSelector, user.Gender.ToString(), SelectionType.Text);

            this.BaseFunctions.ClickOnElement(RegistrationPopupSelectors.ReceiveInfomationCheckboxCss, WebElementType.CssSelector, TimeSpan.FromSeconds(1));
            this.BaseFunctions.ClickOnElement(RegistrationPopupSelectors.RegisterWithEmailButtonCss, WebElementType.CssSelector, TimeSpan.FromSeconds(1));

            var result = this.BaseFunctions.WaitTillPropertyChanges(this.CheckAttributes,
                TimeSpan.FromSeconds(10), RegistrationPopupSelectors.RegistrationPopModalId, WebElementType.Id, "style", "display: none;");

            if (!result)
            {
                throw new Exception("The wait for element failed");
            }
        }

        private bool CheckAttributes(string identifier, WebElementType webElementType, string attributeName, string attributeValue)
        {
            var attributeValueFromPage = this.BaseFunctions.GetAttribute(identifier, webElementType, attributeName);

            return string.Equals(attributeValueFromPage, attributeValue);
        }
    }
}