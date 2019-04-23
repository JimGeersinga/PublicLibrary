using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using PublicLibrary.Controls;
using PublicLibrary.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PublicLibrary
{
    public class BookListViewModel : ViewModelBase
    {
        public bool IsSelectAll { get; set; }

        public ObservableCollection<Book> Books { get; set; }

        public BookListViewModel()
        {
            Load();
        }

        public void Load()
        {
            Books = new ObservableCollection<Book>(App.LibraryService.Books);
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
                if (Equals(e.Parameter, true))
                {
                    book.Id = (App.LibraryService.Books.OrderByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0) + 1;
                    App.LibraryService.AddBook(book);
                    Load();
                }
            });
        }
    }
}
