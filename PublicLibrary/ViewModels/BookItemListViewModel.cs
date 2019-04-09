using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    }
}
