using GalaSoft.MvvmLight;
using PublicLibrary.Models;
using System.Collections.ObjectModel;

namespace PublicLibrary
{
    public class LoanListViewModel : ViewModelBase
    {
        private ObservableCollection<Loan> _loans;
        public ObservableCollection<Loan> Loans
        {
            get => _loans;
            set
            {
                _loans = value;
                RaisePropertyChanged();
            }
        }

        public LoanListViewModel()
        {
            Load();
        }

        public void Load()
        {
            Loans = new ObservableCollection<Loan>(App.LibraryService.Loans);
        }
    }
}

