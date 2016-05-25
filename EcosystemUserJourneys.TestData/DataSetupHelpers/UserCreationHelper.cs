namespace EcosystemUserJourneys.TestData.DataSetupHelpers
{
    using System;
    using Model;

    public class UserCreationHelper
    {
        public User BasicUser { get; private set; }

        public UserCreationHelper()
        {
            this.BasicUser = CreateBasicUser();
        }

        private static User CreateBasicUser()
        {
            return new User()
            {
                EmailAddress = "Reebonz" + Guid.NewGuid().ToString("N") + "@Reebonz.com",
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Password = "P@ssword@123",
                PhoneNumber = "81343456",
                Gender = Gender.Male,
                Address = new ShippingAddress()
                {
                    AddressLineOne = Faker.Address.StreetName(),
                    AddressLineTwo = Faker.Address.StreetSuffix(),
                    AddressLineThree = Faker.Address.StreetAddress(),
                    Country = "Singapore",
                    PostalCode = Faker.Address.ZipCode(),
                    TownOrCity = "Singapore",
                }
            };
        }
    }
}