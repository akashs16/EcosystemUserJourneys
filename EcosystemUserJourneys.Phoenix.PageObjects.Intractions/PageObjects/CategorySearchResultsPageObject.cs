namespace EcosystemUserJourneys.Phoenix.PageObjects.Intractions.PageObjects
{
    using System;
    using System.Linq;
    using OpenQA.Selenium;
    using Selectors;
    using WebDriverAutomationFramework;

    public class CategorySearchResultsPageObject : BasePageObject
    {
        public CategorySearchResultsPageObject(string driver) : base(driver)
        {
        }

        public CategorySearchResultsPageObject(IWebDriver driver, IProvidePageObjectBaseFunctions baeBaseFunctions) : base(driver, baeBaseFunctions)
        {
        }

        public void AddItemsToCart(int numberOfItems)
        {
            var products = this.BaseFunctions.GetElements(CategorySearchResultsPageSelectors.AllProductsCss, WebElementType.CssSelector).Take(numberOfItems);

            foreach (var product in products)
            {
                var quickViewLink = this.BaseFunctions.GetElement(product, WebElementType.CssSelector, CategorySearchResultsPageSelectors.QuickViewLinkPerProductsCss);
                this.BaseFunctions.MoveToElementWithRetries(product, quickViewLink);
                this.BaseFunctions.WaitForLoad(QuickViewSelectors.QuickViewOverLayId, WebElementType.Id, TimeSpan.FromSeconds(3));
                this.BaseFunctions.ClickOnElement(QuickViewSelectors.AddToBagButtonCss, WebElementType.CssSelector, TimeSpan.FromSeconds(2));
            }
        }
    }
}