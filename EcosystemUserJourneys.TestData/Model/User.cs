﻿namespace EcosystemUserJourneys.TestData.Model
{
    public class User
    {
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public ShippingAddress Address { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;

        public Gender Gender { get; set; }
    }
}
