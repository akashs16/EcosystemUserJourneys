namespace EcosystemUserJourneys.PageObjects.Intractions.PageObjects
{
    using System;
    using System.Linq;
    using Identifiers;
    using Identifiers.Checkout;
    using OpenQA.Selenium;
    using WebDriverAutomationFramework;

    public class HeaderPageObject : BasePageObject
    {
        public HeaderPageObject(string driver) : base(driver)
        {
        }

        public HeaderPageObject(IWebDriver driver, IProvidePageObjectBaseFunctions baseFunctions) : base(driver, baseFunctions)
        {
        }

        public void ProceedToCheckout()
        {
            this.BaseFunctions.ClickOnElement(HeaderIdentifiers.ShowMiniBasketClass, WebElementType.Class, TimeSpan.FromSeconds(2));
            this.BaseFunctions.ClickOnElement(HeaderIdentifiers.MiniBasketProceedToCheckoutCss, WebElementType.CssSelector, TimeSpan.FromSeconds(5));
            this.BaseFunctions.WaitForLoad(CheckoutPageIdentifiers.CheckoutPageId, WebElementType.Id, TimeSpan.FromSeconds(10));
        }

        public void OpenMenCategory(string categoryName)
        {
            var categories = this.BaseFunctions.GetElements(HeaderIdentifiers.MenCategoriesCss, WebElementType.CssSelector).ToList();
            var requiredCategory = categories.FirstOrDefault(x => x.GetAttribute("title").ToLower().Contains(categoryName.ToLower()));
            this.BaseFunctions.MoveToElement(HeaderIdentifiers.MenuMenuElementId, WebElementType.Id);
            this.BaseFunctions.ClickOnElement(requiredCategory, TimeSpan.FromSeconds(3));
            this.BaseFunctions.WaitForLoad(CategorySearchResultPageIdentifiers.PageTitleClass, WebElementType.Class, TimeSpan.FromSeconds(5));
        }

        public void OpenWomenCategory(string categoryName)
        {
            var categories = this.BaseFunctions.GetElements(HeaderIdentifiers.WomenCategoriesCss, WebElementType.CssSelector);
            var requiredCategory = categories.FirstOrDefault(x => x.GetAttribute("title").ToLower().Contains(categoryName.ToLower()));
            this.BaseFunctions.MoveToElement(HeaderIdentifiers.MenuWomenElementId, WebElementType.Id);
            this.BaseFunctions.ClickOnElement(requiredCategory, TimeSpan.FromSeconds(3));
        }
    }
}