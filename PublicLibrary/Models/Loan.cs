using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;

namespace PublicLibrary.Models
{
    public class Loan: ViewModelBase
    {
        [JsonIgnore]
        public bool IsSelected { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("bookItemId")]
        public long BookItemId { get; set; }

        [JsonIgnore]
        public BookItem BookItem { get; set; }

        [JsonProperty("customerId")]
        public long CustomerId { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }

        [JsonProperty("loanDate")]
        public DateTime LoanDate { get; set; }
    }
}
