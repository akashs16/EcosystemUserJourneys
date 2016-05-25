namespace EcosystemUserJourneys.PageObjects.Intractions.PageObjects
{
    using System;
    using System.Linq;
    using Enums;
    using Identifiers.Checkout;
    using Identifiers.Checkout.Payment;
    using OpenQA.Selenium;
    using TestData.Model;
    using WebDriverAutomationFramework;

    public class CheckoutPageObject : BasePageObject
    {
        public CheckoutPageObject(string driver) : base(driver)
        {
        }

        public CheckoutPageObject(IWebDriver driver, IProvidePageObjectBaseFunctions baseFunctions) : base(driver, baseFunctions)
        {
        }

        public void Checkout(bool addAddress, bool addDiscount, bool addContactNumber, PaymentMethod paymentMethod, User user = null)
        {
            if (addAddress)
            {
                this.AddNewAddress(user);
            }

            if (addDiscount)
            {
                this.AddNewDiscount();
            }

            if (addContactNumber)
            {
                this.AddNewContactNumber(user);
            }

            this.SelectPayment(paymentMethod);
            this.PerformCheckout(paymentMethod);
        }

        private void PerformCheckout(PaymentMethod paymentMethod)
        {
            this.BaseFunctions.ClickOnElement(CheckoutPageIdentifiers.ConfirmPoliciesCheckBoxId, WebElementType.Id, TimeSpan.FromSeconds(2));
            this.BaseFunctions.ClickOnElement(CheckoutPageIdentifiers.PlaceOrderButtonId, WebElementType.Id, TimeSpan.FromSeconds(2));

            switch (paymentMethod)
            {
                case PaymentMethod.Card:
                    this.BaseFunctions.WaitForLoad("easypay2-start", WebElementType.Id, TimeSpan.FromSeconds(4));
                    break;
                case PaymentMethod.DBS:
                    break;
                case PaymentMethod.UOB:
                    break;
                case PaymentMethod.PayPal:
                    break;
                case PaymentMethod.GlobalBill:
                    break;
                case PaymentMethod.OCBC:
                    break;
                case PaymentMethod.China:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(paymentMethod), paymentMethod, null);
            }
        }

        private void SelectPayment(PaymentMethod paymentMethod)
        {
            var availablePaymentMethods = this.BaseFunctions.GetElements(CheckoutPageIdentifiers.GetAllPaymentMethodsCss, WebElementType.CssSelector);
            var element = availablePaymentMethods.FirstOrDefault(x => x.Text.Contains(paymentMethod.ToString()));
            var requiredElement = this.BaseFunctions.GetElement(element, WebElementType.CssSelector, "input");
            this.BaseFunctions.ClickOnElement(requiredElement, TimeSpan.FromSeconds(3));
        }

        private void AddNewContactNumber(User user)
        {
            this.BaseFunctions.ClearAndSendText(CheckoutPageIdentifiers.PhoneNumberTextFieldId, WebElementType.Id, user.PhoneNumber);
        }

        private void AddNewDiscount()
        {
            //TODO
        }

        private void AddNewAddress(User user)
        {
            this.BaseFunctions.ClickOnElement(CheckoutPageIdentifiers.AddNewAddressCss, WebElementType.CssSelector, TimeSpan.FromSeconds(2));
            this.BaseFunctions.WaitForLoad(AddNewShippingAddressIdentifiers.AddNewAddressOverLayClass, WebElementType.Class, TimeSpan.FromSeconds(4));
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.NameId, WebElementType.Id, user.FullName);
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.StreetAddressLineOneId, WebElementType.Id, user.Address.AddressLineOne);
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.StreetAddressLineTwoId, WebElementType.Id, user.Address.AddressLineTwo);
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.StreetAddressLineThreeId, WebElementType.Id, user.Address.AddressLineThree);
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.CityId, WebElementType.Id, user.Address.TownOrCity);
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.PostalCodeId, WebElementType.Id, user.Address.PostalCode);
            this.BaseFunctions.SelectWebElement(AddNewShippingAddressIdentifiers.CountryDropDownId, WebElementType.Id, "Singapore", SelectionType.Text);
            this.BaseFunctions.ClickOnElement(AddNewShippingAddressIdentifiers.SaveAddressButtonCss, WebElementType.CssSelector, TimeSpan.FromSeconds(4));
        }

        public void PerformCardPayment(CardPayment cardPaymentDetails)
        {
            this.BaseFunctions.ClearAndSendText(CardsIdentifiers.NameOnTheCardTextFieldId, WebElementType.Id, cardPaymentDetails.NameOnTheCard);
            this.BaseFunctions.ClearAndSendText(CardsIdentifiers.CardNumberTextFieldId, WebElementType.Id, cardPaymentDetails.CardNumber);
            this.BaseFunctions.ClearAndSendText(CardsIdentifiers.CvvCodeTextFieldId, WebElementType.Id, cardPaymentDetails.Cvv.ToString());
            this.BaseFunctions.SelectWebElement(CardsIdentifiers.ExpirationDateMonthDropDownId, WebElementType.Id, cardPaymentDetails.ExpiryDetails.Month.ToString(), SelectionType.Text);
            this.BaseFunctions.SelectWebElement(CardsIdentifiers.ExpirationDateYearDropDownId, WebElementType.Id, cardPaymentDetails.ExpiryDetails.Year.ToString(), SelectionType.Text);

            this.BaseFunctions.ClickOnElement(CardsIdentifiers.SubmitButtonId, WebElementType.Id, TimeSpan.FromSeconds(3));
        }
    }
}