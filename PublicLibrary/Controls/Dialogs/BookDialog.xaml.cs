using PublicLibrary.Models;
using PublicLibrary.ViewModels;
using System.Windows.Controls;

namespace PublicLibrary.Controls
{
    public partial class BookDialog : UserControl
    {
        public BookDialog()
        {
            InitializeComponent();
        }

        public BookDialog(Book book)
        {
            InitializeComponent();

            DataContext = new BookDialogViewModel() { Book = book };
        }
    }
}
