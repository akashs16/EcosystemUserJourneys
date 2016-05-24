using System;
using System.Collections.Generic;
using System.Linq;
using EcosystemUserJourneys.PageObjects.Intractions.Identifiers;
using OpenQA.Selenium;
using WebDriverAutomationFramework;

namespace EcosystemUserJourneys.PageObjects.Intractions.PageObjects
{
    public class CategorySearchResultPageObject : BasePageObject
    {
        public List<string> ProductLinks { get; set; }

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