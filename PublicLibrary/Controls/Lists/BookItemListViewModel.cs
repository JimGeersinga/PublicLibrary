using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using PublicLibrary.Controls;
using PublicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PublicLibrary
{
    public class BookItemListViewModel : ViewModelBase
    {
        public bool IsSelectAll { get; set; }

        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                Load();
            }
        }


        public ObservableCollection<BookItem> BookItems { get; set; }

        public BookItemListViewModel()
        {
            Load();
        }

        public void Load()
        {
            List<BookItem> items = App.LibraryService.BookItems;
            foreach (BookItem item in items)
            {
                item.Book = App.LibraryService.Books.FirstOrDefault(x => x.Id == item.BookId);
                item.Loan = App.LibraryService.Loans.FirstOrDefault(x => x.BookItemId == item.Id);
                if (item.Loan != null)
                {
                    item.Loan.Customer = App.LibraryService.Customers.FirstOrDefault(x => x.Id == item.Loan.CustomerId);
                }
            }

            string search = Search?.ToLower();
            items = items.Where(x => string.IsNullOrWhiteSpace(search) ||
                               (x.Book?.Title != null && x.Book.Title.ToLower().Contains(search)) ||
                               (x.Book?.Author != null && x.Book.Author.ToLower().Contains(search)) ||
                               (x.ISBN != null && x.ISBN.ToLower().Contains(search)) ||
                               (x.Supplied != null && x.Supplied.ToString(Constants.DateTimeUiFormat).ToLower().Contains(search)) ||
                               (x.Loan?.Customer?.Username != null && x.Loan.Customer.Username.ToLower().Contains(search))).ToList();

            BookItems = new ObservableCollection<BookItem>(items);
        }

        public ICommand SelectCommand => new RelayCommand(OnSelected);
        public async void OnSelected()
        {
            for (int i = 0; i < BookItems.Count; i++)
            {
                BookItems[i].IsSelected = IsSelectAll;
            }
        }

        public ICommand AddBookItemCommand => new RelayCommand(OnAddBookItem);
        public async void OnAddBookItem()
        {
            BookItem bookItem = new BookItem();

            await DialogHost.Show(new BookItemDialog(bookItem), (s, e) =>
            {
                try
                {
                    if (Equals(e.Parameter, true))
                    {
                        bookItem.Id = (App.LibraryService.BookItems.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
                        bookItem.BookId = bookItem.Book.Id;
                        bookItem.Supplied = DateTime.Now;
                        App.LibraryService.AddBookItem(bookItem);
                        Load();
                    }
                }
                catch (Exception)
                {
                    e.Cancel();
                }
            });
        }
    }
}
