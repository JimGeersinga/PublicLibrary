using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    }
}
