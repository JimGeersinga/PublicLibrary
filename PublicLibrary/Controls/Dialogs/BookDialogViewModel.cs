using GalaSoft.MvvmLight;
using PublicLibrary.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PublicLibrary.ViewModels
{
    public class BookDialogViewModel : ViewModelBase
    {
        public Book Book { get; set; }
        
        public BookDialogViewModel()
        {
            Load();
        }

        public void Load()
        {
        }
    }
}
