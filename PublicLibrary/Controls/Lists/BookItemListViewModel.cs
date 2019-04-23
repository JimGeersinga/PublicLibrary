using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using PublicLibrary.Controls;
using PublicLibrary.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PublicLibrary
{
    public class BookItemListViewModel : ViewModelBase
    {
        public bool IsSelectAll { get; set; }

        public ObservableCollection<BookItem> BookItems { get; set; }

        public BookItemListViewModel()
        {
            Load();
        }

        public void Load()
        {
            var items = App.LibraryService.BookItems;
            foreach(var item in items)
            {
                var loan = App.LibraryService.Loans.FirstOrDefault(x => x.BookItemId == item.Id);
                if(loan != null)
                {
                    Customer customer = App.LibraryService.Customers.FirstOrDefault(x => x.Id == loan.CustomerId);
                    loan.Customer = customer;
                }
                item.Loan = loan;
            }
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
                if (Equals(e.Parameter, true))
                {
                    bookItem.Id = (App.LibraryService.Books.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
                    bookItem.BookId = bookItem.Book.Id;
                    App.LibraryService.AddBookItem(bookItem);
                    Load();
                }
            });
        }
    }
}
