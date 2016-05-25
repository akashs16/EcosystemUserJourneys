namespace EcosystemUserJourneys.PageObjects.Intractions.PageObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Identifiers;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using WebDriverAutomationFramework;

    public class CategorySearchResultPageObject : BasePageObject
    {
        public List<string> ProductLinks { get; }

        public CategorySearchResultPageObject(string driver) : base(driver)
        {
            this.ProductLinks = new List<string>();
        }

        public CategorySearchResultPageObject(IWebDriver driver, IProvidePageObjectBaseFunctions baseFunctions) : base(driver, baseFunctions)
        {
            this.ProductLinks = new List<string>();
        }

        public void AddItemsToCart(int numberOfItems)
        {
            var products = this.BaseFunctions.GetElements(CategorySearchResultPageIdentifiers.AllProductsOnPageCss,
                 WebElementType.CssSelector).Take(numberOfItems);

            foreach (var product in products)
            {
                var addToCartElement = this.BaseFunctions.GetElement(product, WebElementType.CssSelector,
                    CategorySearchResultPageIdentifiers.ProdcutAddToCartCss);
                this.ProductLinks.Add(this.BaseFunctions.GetAttribute(product, CategorySearchResultPageIdentifiers.ProductLinkCss, WebElementType.CssSelector, "href").ToString());
                this.CheckAndMoveToElement(product, addToCartElement);
            }

            this.BaseFunctions.WaitForUnload(HeaderIdentifiers.MiniBasketProceedToCheckoutCss, WebElementType.CssSelector, TimeSpan.FromSeconds(10), true);
        }

        private void CheckAndMoveToElement(IWebElement product, IWebElement webElement, int numberOfRetries = 5)
        {
            while (numberOfRetries > 0)
            {
                try
                {
                    this.BaseFunctions.MoveToElement(product);
                    var wait = new WebDriverWait(this.BaseFunctions.Driver, TimeSpan.FromSeconds(5));
                    wait.Until(x => (webElement.Displayed && webElement.Enabled));
                    this.BaseFunctions.ClickOnElement(webElement, TimeSpan.FromSeconds(2));
                    break;
                }
                catch (WebDriverTimeoutException)
                {
                    this.CheckAndMoveToElement(product, webElement, numberOfRetries--);
                }
            }
        }
    }
}