using GalaSoft.MvvmLight;
using PublicLibrary.Models;
using System.Collections.ObjectModel;

namespace PublicLibrary
{
    public class BookListViewModel : ViewModelBase
    {
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                RaisePropertyChanged();
            }
        }

        public BookListViewModel()
        {
            Load();
        }

        public void Load()
        {
            Books = new ObservableCollection<Book>(App.LibraryService.Books);
        }
    }
}
