using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PublicLibrary.Models
{
    public class BookItem : ViewModelBase
    {
        [JsonIgnore]
        public bool IsSelected { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("bookId")]
        public long BookId { get; set; }

        public Book Book { get; set; }

        [JsonProperty("isbn")]
        public string ISBN { get; set; }

        [JsonProperty("supplied")]
        public DateTime Supplied { get; set; }

        public Loan Loan { get; set; }
    }
}
