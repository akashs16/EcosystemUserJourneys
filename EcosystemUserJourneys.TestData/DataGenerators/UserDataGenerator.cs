using System;

namespace EcosystemUserJourneys.TestData.DataGenerators
{
    public static class UserDataGenerator
    {
        private const string USER_NAME = "ReebonzTestUser";

        private const string EMAIL_POST_FIX = "@reebonz.com";

        public const string Password = "P@ssword@123";

        public const string LastName = "Reebonz";

        public static string EmailAddress => DateTime.UtcNow.ToString("yyMMddhhmmss") + EMAIL_POST_FIX;

        public static string Name => USER_NAME + DateTime.UtcNow.ToString("yyMMddhhmmss").Substring(0, 5);
    }
}