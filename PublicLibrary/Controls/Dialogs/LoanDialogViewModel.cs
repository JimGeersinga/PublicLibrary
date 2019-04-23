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
            BookItems = new ObservableCollection<BookItem>(App.LibraryService.BookItems.Where(x => x.LoanId == null));
            Customers = new ObservableCollection<Customer>(App.LibraryService.Customers);
        }
    }
}
