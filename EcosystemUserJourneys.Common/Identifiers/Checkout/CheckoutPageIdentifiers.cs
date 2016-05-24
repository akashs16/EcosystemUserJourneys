namespace EcosystemUserJourneys.PageObjects.Intractions.Identifiers.Checkout
{
    public static class CheckoutPageIdentifiers
    {
        public const string CheckoutAddressesId = "checkout-addresses";

        public const string AddNewAddressCss = "#checkout-addresses > div > div > a";

        public const string DiscountCodeTextFieldId = "discount-code";

        public const string ApplyDiscountButtonId = "add-discount-code";

        public const string PhoneNumberTextFieldId = "PhoneNumber";

        public const string CheckoutPaymentMethodsId = "checkout-payment-methods";

        public const string GetAllPaymentMethodsCss = "#checkout-payment-methods > div > div.col-md-7>div.payment-method>input";

        public const string GetAllItemsLinksFromCheckoutCss = "#checkout-items > div:nth-child(1) > div > div > div > table > tbody tr> td.checkout-description > h3 > a";

        public const string ConfirmPoliciesCheckBoxId = "confirm-policies";

        public const string PlaceOrderButtonId = "button-confirm";
    }
}