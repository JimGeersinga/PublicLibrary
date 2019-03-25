using PublicLibrary.Models;
using System.Collections.Generic;

namespace PublicLibrary
{
    public class LibraryService
    {
        public LibraryService()
        {

        }

        public List<Book> Books { get; set; } = new List<Book>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Loan> Loans { get; set; } = new List<Loan>();

        public void AddBook(Book item)
        {
            Books.Add(item);
        }

        public void RemoveBook(Book item)
        {
            Books.Remove(item);
        }

        public void AddCustomer(Customer item)
        {
            Customers.Add(item);
        }

        public void RemoveCustomer(Customer item)
        {
            Customers.Remove(item);
        }

        public void AddLoan(Loan item)
        {
            Loans.Add(item);
        }

        public void RemoveLoan(Loan item)
        {
            Loans.Remove(item);
        }
    }
}
