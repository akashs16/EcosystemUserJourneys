namespace EcosystemUserJourneys.TestData.DataSetupHelpers
{
    using System;
    using Model;

    public class UserCreationHelper
    {
        public User BasicUser { get; private set; }

        public UserCreationHelper()
        {
            BasicUser = CreateBasicUser();
        }

        private static User CreateBasicUser()
        {
            return new User()
            {
                EmailAddress = "Reebonz" + Guid.NewGuid().ToString("N") + "@Reebonz.com",
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Password = "P@ssword@123",
                PhoneNumber = Faker.Phone.Number(),
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