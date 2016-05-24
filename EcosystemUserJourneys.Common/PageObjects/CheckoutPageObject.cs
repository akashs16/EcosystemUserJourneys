using System;
using System.Linq;
using EcosystemUserJourneys.PageObjects.Intractions.Enums;
using EcosystemUserJourneys.PageObjects.Intractions.Identifiers.Checkout;
using EcosystemUserJourneys.TestData.Model;
using OpenQA.Selenium;
using WebDriverAutomationFramework;

namespace EcosystemUserJourneys.PageObjects.Intractions.PageObjects
{
    public class CheckoutPageObject : BasePageObject
    {
        public CheckoutPageObject(string driver) : base(driver)
        {
        }

        public CheckoutPageObject(IWebDriver driver,IProvidePageObjectBaseFunctions baseFunctions) : base(driver, baseFunctions)
        {
        }

        public void Checkout(bool addAddress, bool addDiscount, bool addContactNumber, PaymentMethod paymentMethod, User user = null)
        {
            if (addAddress)
            {
                AddNewAddress(user);
            }

            if (addDiscount)
            {
                AddNewDiscount();
            }

            if (addContactNumber)
            {
                AddNewContactNumber(user);
            }

            SelectPayment(paymentMethod);

            PerformCheckout();
        }

        private void PerformCheckout()
        {
            this.BaseFunctions.ClickOnElement(CheckoutPageIdentifiers.ConfirmPoliciesCheckBoxId, WebElementType.Id, TimeSpan.FromSeconds(3));
            this.BaseFunctions.ClickOnElement(CheckoutPageIdentifiers.PlaceOrderButtonId, WebElementType.Id, TimeSpan.FromSeconds(6));
        }

        private void SelectPayment(PaymentMethod paymentMethod)
        {
            var availablePaymentMethods = this.BaseFunctions.GetElements(CheckoutPageIdentifiers.GetAllPaymentMethodsCss, WebElementType.CssSelector);
            var element = availablePaymentMethods.First(x => x.Text.Contains(paymentMethod.ToString()));
            this.BaseFunctions.ClickOnElement(element, TimeSpan.FromSeconds(3));
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
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.NameId, WebElementType.Id, user.FirstName);
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.StreetAddressLineOneId, WebElementType.Id, user.Address.AddressLineOne);
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.StreetAddressLineTwoId, WebElementType.Id, user.Address.AddressLineTwo);
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.StreetAddressLineThreeId, WebElementType.Id, user.Address.AddressLineThree);
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.CityId, WebElementType.Id, user.Address.TownOrCity);
            this.BaseFunctions.ClearAndSendText(AddNewShippingAddressIdentifiers.PostalCodeId, WebElementType.Id, user.Address.PostalCode);
            this.BaseFunctions.SelectWebElement(AddNewShippingAddressIdentifiers.CountryDropDownId, WebElementType.Id, "Singapore", SelectionType.Value);
            this.BaseFunctions.ClickOnElement(AddNewShippingAddressIdentifiers.SaveAddressButtonCss, WebElementType.CssSelector, TimeSpan.FromSeconds(4));
        }
    }
}