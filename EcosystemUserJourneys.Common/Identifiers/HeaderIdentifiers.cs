namespace EcosystemUserJourneys.PageObjects.Intractions.Identifiers
{
    public static class HeaderIdentifiers
    {
        public const string MiniBasketProceedToCheckoutCss = "div.minibasket > div > div > div.actions > a.btn.btn-secondary";

        public const string MenMenuCss = "#wrapper > div:first-child> div > div.main-menu > div > div > div.col-md-6.mega-menu > ul > li:nth-child(2)";

        public const string WomenMenuCss = "#wrapper > div:first-child > div > div.main-menu > div > div > div.col-md-6.mega-menu > ul > li:nth-child(1)";

        public const string MenCategoriesCss = MenMenuCss + " > div > div > div > div > div.col-lg-10 > div > div:nth-child(2) > ul > li > a";

        public const string WomenCategoriesCss = WomenMenuCss + " > div > div > div > div > div > div.row > div:nth-child(2) > ul >li > a";

        public const string MenuMenuElementId = "menuMen";

        public const string MenuWomenElementId = "menuWomen";

        public const string ShowMiniBasketClass = "show-basket";
    }
}