namespace EcosystemUserJourneys.Phoenix.PageObjects.Intractions.PageObjects
{
    using System;
    using System.Configuration;
    using System.Linq;
    using OpenQA.Selenium;
    using Selectors;
    using TestData.Enums;
    using TestData.Model;
    using WebDriverAutomationFramework;

    public class HeaderPageObject : BasePageObject
    {
        private readonly string baseUrl;

        public HeaderPageObject(string driver) : base(driver)
        {
            this.baseUrl = ConfigurationManager.ConnectionStrings["HomePage"].ConnectionString;
        }

        public HeaderPageObject(IWebDriver driver, IProvidePageObjectBaseFunctions baeBaseFunctions) : base(driver, baeBaseFunctions)
        {
            this.baseUrl = ConfigurationManager.ConnectionStrings["HomePage"].ConnectionString;
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

            var result = this.BaseFunctions.WaitTillSpecifiedCondition(this.CheckAttributes,
                TimeSpan.FromSeconds(10), RegistrationPopupSelectors.RegistrationPopModalId, WebElementType.Id, "style", "display: none;");

            if (!result)
            {
                throw new Exception("The wait for element failed");
            }
        }

        public void SelectMaleCategory(string categoryName)
        {
            this.BaseFunctions.MoveToElement(HeaderSelectors.MenCategorylinkId, WebElementType.Id);
            var categories = this.BaseFunctions.GetElements(HeaderSelectors.AllCategoriesCss, WebElementType.CssSelector);
            var requiredCategory = categories.First(x => x.Text.ToLower().Contains(categoryName.ToLower()));
            var actualCategoryName = requiredCategory.Text;
            this.BaseFunctions.ClickOnElement(requiredCategory, TimeSpan.Zero);

            this.BaseFunctions.WaitTillSpecifiedCondition(this.CheckUrl, TimeSpan.FromSeconds(6), ProductCategoryType.Men.ToString(), actualCategoryName);
        }

        private bool CheckUrl(params object[] objects)
        {
            return this.BaseFunctions.Driver.Url == ConstructUrlString(objects);
        }

        private bool CheckAttributes(params object[] objects)
        {
            var attributeValueFromPage = this.BaseFunctions.GetAttribute(objects[0].ToString(), (WebElementType)objects[1], objects[2].ToString());

            return string.Equals(attributeValueFromPage, objects[3].ToString());
        }

        private static string ConstructUrlString(params object[] objects)
        {
            return objects.Aggregate("", (current, items) => current + "/" + items.ToString().ToLower());
        }
    }
}