using GalaSoft.MvvmLight;
using PublicLibrary.Models;

namespace PublicLibrary.ViewModels
{
    public class LoanDialogViewModel : ViewModelBase
    {
        public Loan Loan { get; set; }

        public LoanDialogViewModel()
        {
            Load();
        }

        public void Load()
        {
            //Loans = new ObservableCollection<Loan>(App.LibraryService.Loans);
        }
    }
}
