using GalaSoft.MvvmLight;
using PublicLibrary.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PublicLibrary.ViewModels
{
    public class BookItemDialogViewModel : ViewModelBase
    {
        public BookItem BookItem { get; set; }
        public ObservableCollection<Book> Books { get; set; }

        public BookItemDialogViewModel()
        {
            Load();
        }

        public void Load()
        {
            Books = new ObservableCollection<Book>(App.LibraryService.Books);
        }
    }
}
