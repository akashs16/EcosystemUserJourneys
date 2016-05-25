namespace EcosystemUserJourneys.TestData.DataSetupHelpers
{
    using System;
    using Model;

    public class PaymentDataSetter
    {
        public CardPayment GetCardPaymentDetails(string nameOfTheUser)
        {
            return new CardPayment()
            {
                ExpiryDetails = new ExpiryDetails()
                {
                    Month = DateTime.UtcNow.Month.ToString("0#"),
                    Year = DateTime.UtcNow.AddYears(2).ToString("yy")
                },
                CardNumber = "41111111111111111",
                Cvv = 989,
                NameOnTheCard = nameOfTheUser
            };
        }
    }
}