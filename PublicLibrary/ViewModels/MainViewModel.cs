using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Newtonsoft.Json;
using PublicLibrary.Controls;
using PublicLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace PublicLibrary
{
    public class MainViewModel : ViewModelBase
    {
        private IControl _selectedPage;
        public IControl SelectedPage
        {
            get => _selectedPage;
            set
            {
                _selectedPage = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            SelectedPage = new BookListControl();
        }

        public ICommand SwitchPageCommand { get { return new RelayCommand<string>(OnSwitchPage); } }
        public void OnSwitchPage(string page)
        {
            switch (page)
            {
                case "books":
                    SelectedPage = new BookListControl();
                    break;
                case "customers":
                    SelectedPage = new CustomerListControl();
                    break;
                case "loans":
                    SelectedPage = new LoanListControl();
                    break;
            }

            SelectedPage.Reload();
        }

        public ICommand ImportCustomersCommand { get { return new RelayCommand(OnImportCustomers); } }
        public void OnImportCustomers()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".json", // Required file extension 
                Filter = "Json documenten (.json)|*.json" // Optional file extensions
            };

            if (fileDialog.ShowDialog() == true)
            {
                string content = File.ReadAllText(fileDialog.FileName);
                List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(content);
                App.LibraryService.Customers = customers;
                SelectedPage.Reload();
            }
        }

        public ICommand ImportBooksCommand { get { return new RelayCommand(OnImportBooks); } }
        public void OnImportBooks()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".json", // Required file extension 
                Filter = "Json documenten (.json)|*.json" // Optional file extensions
            };

            if (fileDialog.ShowDialog() == true)
            {
                string content = File.ReadAllText(fileDialog.FileName);
                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(content);
                App.LibraryService.Books = books;
                SelectedPage.Reload();
            }
        }

        public ICommand ImportDefaultsCommand { get { return new RelayCommand(OnImportDefaults); } }
        public void OnImportDefaults()
        {
            try
            {
                string contentBooks = File.ReadAllText($"{Environment.CurrentDirectory}/Data/books.json");
                string contentCustomers = File.ReadAllText($"{Environment.CurrentDirectory}/Data/customers.json");
                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(contentBooks);
                List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(contentCustomers);
                App.LibraryService.Books = books;
                App.LibraryService.Customers = customers;
                SelectedPage.Reload();
            }
            catch (Exception ex)
            {

            }
        }

        public ICommand ImportLibraryCommand { get { return new RelayCommand(OnImportLibrary); } }
        public void OnImportLibrary()
        {
            SelectedPage.Reload();
        }

        public ICommand ExportLibraryCommand { get { return new RelayCommand(OnExportLibrary); } }
        public void OnExportLibrary()
        {
            SelectedPage.Reload();
        }

        public ICommand ClearCommand { get { return new RelayCommand(OnClear); } }
        public void OnClear()
        {
            App.LibraryService = new LibraryService();
            SelectedPage.Reload();
        }
    }
}
