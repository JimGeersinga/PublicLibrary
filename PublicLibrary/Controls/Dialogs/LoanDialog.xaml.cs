using PublicLibrary.Models;
using PublicLibrary.ViewModels;
using System.Windows.Controls;

namespace PublicLibrary.Controls
{
    public partial class LoanDialog : UserControl
    {
        public LoanDialog()
        {
            InitializeComponent();
        }

        public LoanDialog(Loan loan)
        {
            InitializeComponent();

            DataContext = new LoanDialogViewModel() { Loan = loan };
        }
    }
}
