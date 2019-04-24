using GalaSoft.MvvmLight;
using PublicLibrary.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PublicLibrary.ViewModels
{
    public class LoanDialogViewModel : ViewModelBase
    {
        public Loan Loan { get; set; }

        public ObservableCollection<BookItem> BookItems { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }

        public LoanDialogViewModel()
        {
            Load();
        }

        public void Load()
        {
            var items = App.LibraryService.BookItems.Where(x => x.LoanId == null);
            foreach (var item in items)
            {
                item.Book = App.LibraryService.Books.FirstOrDefault(x => x.Id == item.BookId);               
            }
            BookItems = new ObservableCollection<BookItem>(items);

            Customers = new ObservableCollection<Customer>(App.LibraryService.Customers);
        }
    }
}
