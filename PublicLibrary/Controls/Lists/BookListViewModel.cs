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
    public class BookListViewModel : ViewModelBase
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

        public ObservableCollection<Book> Books { get; set; }

        public BookListViewModel()
        {
            Load();
        }

        public void Load()
        {
            string search = Search?.ToLower();
            IEnumerable<Book> books = App.LibraryService.Books.Where(x => string.IsNullOrWhiteSpace(search) ||
                                                            (x.Author != null && x.Author.ToLower().Contains(search)) ||
                                                            (x.Country != null && x.Country.ToLower().Contains(search)) ||
                                                            (x.ImageLink != null && x.ImageLink.ToLower().Contains(search)) ||
                                                            (x.Language != null && x.Language.ToLower().Contains(search)) ||
                                                            (x.Link != null && x.Link.ToString().ToLower().Contains(search)) ||
                                                            (x.Title != null && x.Title.ToLower().Contains(search)) ||
                                                            (x.Year.ToString().Contains(search)));
            Books = new ObservableCollection<Book>(books);
        }

        public ICommand SelectCommand => new RelayCommand(OnSelected);
        public async void OnSelected()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                Books[i].IsSelected = IsSelectAll;
            }
            App.LibraryService.Books = Books.ToList();
        }

        public ICommand AddBookCommand => new RelayCommand(OnAddBook);
        public async void OnAddBook()
        {
            Book book = new Book();

            await DialogHost.Show(new BookDialog(book), (s, e) =>
            {
                try
                {
                    if (Equals(e.Parameter, true))
                    {
                        book.Id = (App.LibraryService.Books.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
                        App.LibraryService.AddBook(book);
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
