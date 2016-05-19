using EcosystemUserJourneys.TestData.DataGenerators;
using EcosystemUserJourneys.TestData.Model;

namespace EcosystemUserJourneys.TestData.DataSetupHelpers
{
    public class UserCreationHelper
    {
        public User BasicUser { get; set; }

        public UserCreationHelper()
        {
            BasicUser = CreateBasicUser();
        }

        private static User CreateBasicUser()
        {
            return new User()
            {
                EmailAddress = UserDataGenerator.EmailAddress,
                FirstName = UserDataGenerator.Name,
                LastName = UserDataGenerator.LastName,
                Password = UserDataGenerator.Password
            };
        }
    }
}