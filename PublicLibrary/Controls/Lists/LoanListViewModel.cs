using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using MoreLinq;
using PublicLibrary.Controls;
using PublicLibrary.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        public void OnSelected()
        {
            for (int i = 0; i < Loans.Count; i++)
            {
                Loans[i].IsSelected = IsSelectAll;
            }
        }

        public ICommand AddLoanCommand => new RelayCommand(OnAddLoan);
        public async void OnAddLoan()
        {
            Loan loan = new Loan();

            await DialogHost.Show(new LoanDialog(loan), (s, e) =>
            {
                if (Equals(e.Parameter, true))
                {
                    loan.Id = (App.LibraryService.Loans.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
                    loan.LoanDate = DateTime.Now;
                    loan.BookItem.LoanId = loan.Id;
                    loan.BookItemId = loan.BookItem.Id;
                    loan.CustomerId = loan.Customer.Id;
                    App.LibraryService.AddLoan(loan);
                    Load();
                }
            });
        }
    }
}

