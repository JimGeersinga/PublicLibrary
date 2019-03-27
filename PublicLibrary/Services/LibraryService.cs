using PublicLibrary.Models;
using System;
using System.Collections.Generic;

namespace PublicLibrary
{
    public class LibraryService
    {
        public static Random Random = new Random();

        public LibraryService()
        {

        }

        public List<Book> Books { get; set; } = new List<Book>();
        public List<BookItem> BookItems { get; set; } = new List<BookItem>();
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
        public void ImportBooks(List<Book> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Book item = items[i];
                item.Id = i;

                List<BookItem> bookItems = new List<BookItem>();
                for (int j = 0; j < Random.Next(1, 10); j++)
                {
                    BookItem bookItem = new BookItem()
                    {
                        Id = Convert.ToInt64($"{i}{j}"),
                        BookId = item.Id,
                        Book = item,
                        ISBN = GenerateISBN(),
                        Supplied = GenerateDate()
                    };
                    bookItems.Add(bookItem);
                    AddBookItem(bookItem);
                }

                item.BookItems = bookItems;
                AddBook(item);
            }
        }

        public void AddCustomer(Customer item)
        {
            Customers.Add(item);
        }
        public void RemoveCustomer(Customer item)
        {
            Customers.Remove(item);
        }
        public void ImportCustomers(List<Customer> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                AddCustomer(items[i]);
            }
        }

        public void AddBookItem(BookItem item)
        {
            BookItems.Add(item);
        }
        public void RemoveBookItem(BookItem item)
        {
            BookItems.Remove(item);
        }

        public void AddLoan(Loan item)
        {
            Loans.Add(item);
        }
        public void RemoveLoan(Loan item)
        {
            Loans.Remove(item);
        }

        private string GenerateISBN()
        {
            string isbn = string.Empty;
            for (int i = 0; i < 13; i++)
            {
                isbn += Random.Next(0, 9);
            }
            return isbn;
        }

        private DateTime GenerateDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(Random.Next(range));
        }
    }
}
