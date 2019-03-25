using Newtonsoft.Json;
using System;

namespace PublicLibrary.Models
{
    public class Customer
    {
        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("nameSet")]
        public string NameSet { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("telephoneNumber")]
        public string TelephoneNumber { get; set; }
    }
}
