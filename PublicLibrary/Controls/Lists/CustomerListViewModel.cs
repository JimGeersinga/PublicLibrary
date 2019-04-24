using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using PublicLibrary.Controls;
using PublicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PublicLibrary
{
    public class CustomerListViewModel : ViewModelBase
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

        public ObservableCollection<Customer> Customers { get; set; }

        public CustomerListViewModel()
        {
            Load();
        }

        public void Load()
        {
            string search = Search?.ToLower();
            List<Customer> customers = App.LibraryService.Customers.Where(x => string.IsNullOrWhiteSpace(search) ||
                                                            (x.Gender != null && x.Gender.ToLower().Contains(search)) ||
                                                            (x.NameSet != null && x.NameSet.ToLower().Contains(search)) ||
                                                            (x.GivenName != null && x.GivenName.ToLower().Contains(search)) ||
                                                            (x.Surname != null && x.Surname.ToLower().Contains(search)) ||
                                                            (x.StreetAddress != null && x.StreetAddress.ToLower().Contains(search)) ||
                                                            (x.ZipCode != null && x.ZipCode.ToLower().Contains(search)) ||
                                                            (x.EmailAddress != null && x.EmailAddress.ToLower().Contains(search)) ||
                                                            (x.Username != null && x.Username.ToLower().Contains(search)) ||
                                                            (x.TelephoneNumber != null && x.TelephoneNumber.ToLower().Contains(search))).ToList();
            Customers = new ObservableCollection<Customer>(customers);
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
                try
                {
                    if (Equals(e.Parameter, true))
                    {
                        customer.Id = (App.LibraryService.Customers.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
                        App.LibraryService.AddCustomer(customer);
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
