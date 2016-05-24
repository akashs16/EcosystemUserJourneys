using System;
using EcosystemUserJourneys.TestData.Model;

namespace EcosystemUserJourneys.TestData.DataSetupHelpers
{
    public class PaymentDataSetter
    {
        public CardPayment GetCardPaymentDetails()
        {
            return new CardPayment()
            {
                ExpiryDetails = new ExpiryDetails()
                {
                    Month = DateTime.UtcNow.Month,
                    Year = DateTime.UtcNow.AddYears(2).Year
                },
                CardNumber = "41111111111111111",
                Cvv = 989,
                NameOnTheCard = "Reebonz AutomatedTester"
            };
        }
    }
}