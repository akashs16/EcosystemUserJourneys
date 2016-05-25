namespace EcosystemUserJourneys.PageObjects.Intractions.PageObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Identifiers;
    using OpenQA.Selenium;
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
                this.BaseFunctions.MoveToElement(product);
                this.BaseFunctions.ClickOnElement(addToCartElement, TimeSpan.FromSeconds(4));
            }
        }
    }
}