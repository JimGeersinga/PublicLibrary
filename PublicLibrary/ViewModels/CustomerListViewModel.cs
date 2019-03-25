using GalaSoft.MvvmLight;
using PublicLibrary.Models;
using System.Collections.ObjectModel;

namespace PublicLibrary
{
    public class CustomerListViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                RaisePropertyChanged();
            }
        }

        public CustomerListViewModel()
        {
            Load();
        }

        public void Load()
        {
            Customers = new ObservableCollection<Customer>(App.LibraryService.Customers);
        }
    }
}
