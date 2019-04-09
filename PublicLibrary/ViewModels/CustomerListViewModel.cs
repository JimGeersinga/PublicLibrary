using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

        public ICommand CreateCommand => new RelayCommand(OnCreate);
        public async void OnCreate()
        {
            for (int i = 0; i < Customers.Count; i++)
            {
                Customers[i].IsSelected = IsSelectAll;
            }
        }

        public ICommand EditCommand => new RelayCommand(OnEdit);
        public async void OnEdit()
        {
            for (int i = 0; i < Customers.Count; i++)
            {
                Customers[i].IsSelected = IsSelectAll;
            }
        }

        public ICommand DeleteCommand => new RelayCommand(OnDelete);
        public async void OnDelete()
        {
            for (int i = Customers.Count - 1; i >= 0; i--)
            {
                if (Customers[i].IsSelected)
                {
                    Customers.RemoveAt(i);
                }
            }
            App.LibraryService.Customers = Customers.ToList();
        }
    }
}
