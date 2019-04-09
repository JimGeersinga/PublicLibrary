using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PublicLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PublicLibrary
{
    public class LoanListViewModel : ViewModelBase
    {
        public bool IsSelectAll { get; set; }

        public ObservableCollection<Loan> Loans { get; set; }

        public LoanListViewModel()
        {
            Load();
        }

        public void Load()
        {
            Loans = new ObservableCollection<Loan>(App.LibraryService.Loans);
        }

        public ICommand SelectCommand => new RelayCommand(OnSelected);
        public async void OnSelected()
        {
            for (int i = 0; i < Loans.Count; i++)
            {
                Loans[i].IsSelected = IsSelectAll;
            }
        }
    }
}

