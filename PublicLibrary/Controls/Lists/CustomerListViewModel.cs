using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using PublicLibrary.Controls;
using PublicLibrary.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PublicLibrary
{
    public class CustomerListViewModel : ViewModelBase
    {
        public bool IsSelectAll { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerListViewModel()
        {
            Load();
        }

        public void Load()
        {
            Customers = new ObservableCollection<Customer>(App.LibraryService.Customers);
        }

        public ICommand SelectCommand => new RelayCommand(OnSelected);
        public async void OnSelected()
        {
            for (int i = 0; i < Customers.Count; i++)
            {
                Customers[i].IsSelected = IsSelectAll;
            }
        }

        public ICommand AddCustomerCommand => new RelayCommand(OnCustomerAdd);
        public async void OnCustomerAdd()
        {
            Customer customer = new Customer();

            await DialogHost.Show(new CustomerDialog(customer), (s, e) =>
            {
                if (Equals(e.Parameter, true))
                {
                    customer.Id = (App.LibraryService.Customers.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
                    App.LibraryService.AddCustomer(customer);
                    Load();
                }
            });
        }
    }
}
