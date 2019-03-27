using GalaSoft.MvvmLight;
using PublicLibrary.Models;

namespace PublicLibrary.ViewModels
{
    public class LoanDialogViewModel : ViewModelBase
    {
        private Loan _loan;
        public Loan Loan
        {
            get => _loan;
            set
            {
                _loan = value;
                RaisePropertyChanged();
            }
        }

        public LoanDialogViewModel()
        {
            Load()
        }

        public void Load()
        {
            Loans = new ObservableCollection<Loan>(App.LibraryService.Loans);
        }
    }
}
