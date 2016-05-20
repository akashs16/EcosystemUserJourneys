using System;

namespace EcosystemUserJourneys.TestData.DataGenerators
{
    public static class UserDataGenerator
    {
        private const string USER_NAME = "ReebonzTestUser";

        private const string EMAIL_POST_FIX = "@reebonz.com";

        public const string Password = "P@ssword@123";

        public const string LastName = "Reebonz";

        public static string EmailAddress => Guid.NewGuid().ToString("N") + EMAIL_POST_FIX;

        public static string Name => USER_NAME + DateTime.UtcNow.ToString("yyMMddhhmmss").Substring(0, 5);
    }
}