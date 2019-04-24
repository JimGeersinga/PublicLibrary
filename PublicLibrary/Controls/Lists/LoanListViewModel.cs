using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using MoreLinq;
using PublicLibrary.Controls;
using PublicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PublicLibrary
{
    public class LoanListViewModel : ViewModelBase
    {
        public bool IsSelectAll { get; set; }

        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                Load();
            }
        }

        public ObservableCollection<Loan> Loans { get; set; }

        public LoanListViewModel()
        {
            Load();
        }

        public void Load()
        {
            string search = Search?.ToLower();
            List<Loan> items = App.LibraryService.Loans.Where(x => string.IsNullOrWhiteSpace(search) ||
                               (x.BookItem?.Book?.Title != null && x.BookItem.Book.Title.ToLower().Contains(search)) ||
                               (x.BookItem?.ISBN != null && x.BookItem.ISBN.ToLower().Contains(search)) ||
                               (x.Customer?.Username != null && x.Customer.Username.ToLower().Contains(search)) ||
                               (x.LoanDate != null && x.LoanDate.ToString(Constants.DateTimeUiFormat).ToLower().Contains(search))).ToList();
            foreach (Loan item in items)
            {
                item.Customer = App.LibraryService.Customers.FirstOrDefault(x => x.Id == item.CustomerId);
                item.BookItem = App.LibraryService.BookItems.FirstOrDefault(x => x.Id == item.BookItemId);
                if (item.BookItem != null)
                {
                    item.BookItem.Book = App.LibraryService.Books.FirstOrDefault(x => x.Id == item.BookItem.BookId);
                }
            }

            Loans = new ObservableCollection<Loan>(items);
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
                try
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
                }
                catch (Exception)
                {
                    e.Cancel();
                }
            });
        }
    }
}

