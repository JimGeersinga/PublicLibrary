using GalaSoft.MvvmLight;
using PublicLibrary.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PublicLibrary
{
    public class BookItemListViewModel : ViewModelBase
    {
        private ObservableCollection<BookItem> _bookItems;
        public ObservableCollection<BookItem> BookItems
        {
            get => _bookItems;
            set
            {
                _bookItems = value;
                RaisePropertyChanged();
            }
        }

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
    }
}
