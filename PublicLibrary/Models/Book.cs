using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PublicLibrary.Models
{
    
    public class Book
    {
        [JsonProperty("id", Required = Required.Default)]
        public long Id { get; set; }
        
        [JsonProperty("author", Required = Required.AllowNull)]
        public string Author { get; set; }

        [JsonProperty("country", Required = Required.AllowNull)]
        public string Country { get; set; }

        [JsonProperty("imageLink", Required = Required.AllowNull)]
        public string ImageLink { get; set; }

        [JsonProperty("language", Required = Required.AllowNull)]
        public string Language { get; set; }

        [JsonProperty("link", Required = Required.AllowNull)]
        public Uri Link { get; set; }

        [JsonProperty("pages", Required = Required.AllowNull)]
        public long Pages { get; set; }

        [JsonProperty("title", Required = Required.AllowNull)]
        public string Title { get; set; }

        [JsonProperty("year", Required = Required.AllowNull)]
        public long Year { get; set; }

        public List<BookItem> BookItems { get; set; }
    }
}
