namespace EcosystemUserJourneys.TestData.Model
{
    public class CardPayment
    {
        public string NameOnTheCard { get; set; }

        public string CardNumber { get; set; }

        public int Cvv { get; set; }

        public ExpiryDetails ExpiryDetails { get; set; }
    }
}