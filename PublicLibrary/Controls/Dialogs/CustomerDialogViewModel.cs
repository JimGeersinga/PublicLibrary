using GalaSoft.MvvmLight;
using PublicLibrary.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PublicLibrary.ViewModels
{
    public class CustomerDialogViewModel : ViewModelBase
    {
        public Customer Customer { get; set; }
        
        public CustomerDialogViewModel()
        {
            Load();
        }

        public void Load()
        {
        }
    }
}
