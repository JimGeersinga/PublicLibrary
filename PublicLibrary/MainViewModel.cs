using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
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
        public IControl SelectedPage { get; set; }

        public MainViewModel()
        {
            SelectedPage = new CustomerListControl();
            OnImportDefaults();
        }

        public ICommand SwitchPageCommand { get { return new RelayCommand<string>(OnSwitchPage); } }
        public async void OnSwitchPage(string page)
        {
            switch (page)
            {
                case "customers":
                    SelectedPage = new CustomerListControl();
                    break;
                case "books":
                    SelectedPage = new BookListControl();
                    break;
                case "bookitems":
                    SelectedPage = new BookItemListControl();
                    break;
                case "loans":
                    SelectedPage = new LoanListControl();
                    break;
            }

            SelectedPage.Reload();
        }

        public ICommand ImportCustomersCommand { get { return new RelayCommand(OnImportCustomers); } }
        public async void OnImportCustomers()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".json", // Required file extension 
                Filter = "Customers (.json)|*.json" // Optional file extensions
            };

            if (fileDialog.ShowDialog() == true)
            {
                try
                {
                    string content = File.ReadAllText(fileDialog.FileName);
                    List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(content);
                    App.LibraryService.ImportCustomers(customers);
                    SelectedPage.Reload();
                }
                catch (Exception)
                {
                    OkDialog dialog = new OkDialog()
                    {
                        ViewModel = new ViewModels.OkDialogViewModel("The file doesn't contain a valid customer list file format.")
                    };
                    await DialogHost.Show(dialog, "RootDialog");
                }
            }
        }

        public ICommand ImportBooksCommand { get { return new RelayCommand(OnImportBooks); } }
        public async void OnImportBooks()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                DefaultExt = ".json", // Required file extension 
                Filter = "Books (.json)|*.json" // Optional file extensions
            };

            if (fileDialog.ShowDialog() == true)
            {
                try
                {
                    string content = File.ReadAllText(fileDialog.FileName);
                    List<Book> books = JsonConvert.DeserializeObject<List<Book>>(content);
                    App.LibraryService.ImportBooks(books);
                    SelectedPage.Reload();
                }
                catch (Exception)
                {
                    OkDialog dialog = new OkDialog()
                    {
                        ViewModel = new ViewModels.OkDialogViewModel("The file doesn't contain a valid book list file format.")
                    };
                    await DialogHost.Show(dialog, "RootDialog");
                }
            }
        }

        public ICommand ImportDefaultsCommand { get { return new RelayCommand(OnImportDefaults); } }
        public async void OnImportDefaults()
        {
            try
            {
                string contentBooks = File.ReadAllText($"{Environment.CurrentDirectory}/Data/books.json");
                string contentCustomers = File.ReadAllText($"{Environment.CurrentDirectory}/Data/customers.json");
                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(contentBooks);
                List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(contentCustomers);
                App.LibraryService.ImportBooks(books);
                App.LibraryService.ImportCustomers(customers);
                SelectedPage.Reload();
            }
            catch (Exception ex)
            {

            }
        }

        public ICommand ImportLibraryCommand { get { return new RelayCommand(OnImportLibrary); } }
        public async void OnImportLibrary()
        {
            SelectedPage.Reload();
        }

        public ICommand ExportLibraryCommand { get { return new RelayCommand(OnExportLibrary); } }
        public async void OnExportLibrary()
        {
            SelectedPage.Reload();
        }

        public ICommand ClearCommand { get { return new RelayCommand(OnClear); } }
        public async void OnClear()
        {
            App.LibraryService = new LibraryService();
            SelectedPage.Reload();
        }
    }
}
