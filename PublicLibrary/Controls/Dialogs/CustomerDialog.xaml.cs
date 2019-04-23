using PublicLibrary.Models;
using PublicLibrary.ViewModels;
using System.Windows.Controls;

namespace PublicLibrary.Controls
{
    public partial class CustomerDialog : UserControl
    {
        public CustomerDialog()
        {
            InitializeComponent();
        }

        public CustomerDialog(Customer customer)
        {
            InitializeComponent();

            DataContext = new CustomerDialogViewModel() { Customer = customer };
        }
    }
}
