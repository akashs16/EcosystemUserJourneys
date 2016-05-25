namespace EcosystemUserJourneys.Phoenix.PageObjects.Intractions.PageObjects.Selectors
{
    public static class RegistrationPopupSelectors
    {
        public const string RegistrationPopUpCss = ".modal-content.model-lg";

        public const string RegistrationPopModalId = "js-register-modal";

        public const string EmailAddressTextFieldCss = "#js-register-form > div:nth-child(1) > input[type=\"text\"]";

        public const string PasswordTextFieldCss = "#js-register-form > div:nth-child(2) > input[type=\"password\"]";

        public const string FirstNameTextFieldCss = "#js-register-form > div:nth-child(3) > div > div:nth-child(1) > input[type=\"text\"]";

        public const string LastNameTextFieldCss = "#js-register-form > div:nth-child(3) > div > div:nth-child(2) > input[type=\"text\"]";

        public const string GenderDropDownCss = "#js-register-form > div:nth-child(4) > select";

        public const string ReceiveInfomationCheckboxCss = "#js-register-form > div:nth-child(5) > label > span.custom";

        public const string RegisterWithEmailButtonCss = "#js-register-form > div:nth-child(6) > input[type=\"submit\"]";
    }
}