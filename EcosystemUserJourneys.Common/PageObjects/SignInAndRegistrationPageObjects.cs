﻿using System;
using System.Configuration;
using EcosystemUserJourneys.PageObjects.Intractions.Identifiers;
using EcosystemUserJourneys.TestData;
using EcosystemUserJourneys.TestData.Model;
using WebDriverAutomationFramework;

namespace EcosystemUserJourneys.PageObjects.Intractions.PageObjects
{
    public class SignInAndRegistrationPageObjects : BasePageObject
    {
        public SignInAndRegistrationPageObjects(string driver) : base(driver)
        {
        }

        public void RegisterViaEmail(Uri url, User user)
        {
            this.baseFunctions.ClickOnElement(HomePageIdentifiers.RegistrationLink, WebElementType.CssSelector, TimeSpan.FromSeconds(2));
            this.baseFunctions.WaitForLoad(RegistrationOverlay.RegistrationModal, TimeSpan.FromSeconds(3), WebElementType.Class);
            this.baseFunctions.ClearAndSendText(RegistrationOverlay.FirstNameTextField, WebElementType.Id, user.FirstName);
            this.baseFunctions.ClearAndSendText(RegistrationOverlay.LastNameTextField, WebElementType.Id, user.LastName);
            this.baseFunctions.ClearAndSendText(RegistrationOverlay.EmailTextField, WebElementType.Id, user.EmailAddress);
            this.baseFunctions.ClearAndSendText(RegistrationOverlay.PassowrdTextField, WebElementType.Id, user.Password);
            this.baseFunctions.ClearAndSendText(RegistrationOverlay.ConfirmPasswordTextField, WebElementType.Id, user.Password);

            // this to get to the registration button and perform a submit on it
            var element = this.baseFunctions.FindElementByLocator("div.form-group", WebElementType.CssSelector);
            var button = this.baseFunctions.FindElementByElement(element, WebElementType.CssSelector, ":first-child");
            this.baseFunctions.PerformSubmit(button, TimeSpan.FromSeconds(8));
        }
    }
}