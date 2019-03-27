using Newtonsoft.Json;

namespace PublicLibrary.Models
{
    public class Customer
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("gender", Required = Required.AllowNull)]
        public string Gender { get; set; }

        [JsonProperty("nameSet", Required = Required.AllowNull)]
        public string NameSet { get; set; }

        [JsonProperty("givenName", Required = Required.AllowNull)]
        public string GivenName { get; set; }

        [JsonProperty("surname", Required = Required.AllowNull)]
        public string Surname { get; set; }

        [JsonProperty("streetAddress", Required = Required.AllowNull)]
        public string StreetAddress { get; set; }

        [JsonProperty("zipCode", Required = Required.AllowNull)]
        public string ZipCode { get; set; }

        [JsonProperty("city", Required = Required.AllowNull)]
        public string City { get; set; }

        [JsonProperty("emailAddress", Required = Required.AllowNull)]
        public string EmailAddress { get; set; }

        [JsonProperty("username", Required = Required.AllowNull)]
        public string Username { get; set; }

        [JsonProperty("telephoneNumber", Required = Required.AllowNull)]
        public string TelephoneNumber { get; set; }
    }
}
