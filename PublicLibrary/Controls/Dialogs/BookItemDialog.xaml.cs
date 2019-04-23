using PublicLibrary.Models;
using PublicLibrary.ViewModels;
using System.Windows.Controls;

namespace PublicLibrary.Controls
{
    public partial class BookItemDialog : UserControl
    {
        public BookItemDialog()
        {
            InitializeComponent();
        }

        public BookItemDialog(BookItem bookItem)
        {
            InitializeComponent();

            DataContext = new BookItemDialogViewModel() { BookItem = bookItem };
        }
    }
}
