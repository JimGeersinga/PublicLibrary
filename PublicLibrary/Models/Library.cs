using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLibrary.Models
{
    public class Library
    {
        public List<Customer> Customers { get; set; }
        public List<Book> Books { get; set; }
        public List<BookItem> BookItems { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
