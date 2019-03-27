using PublicLibrary.ViewModels;
using System.Windows.Controls;

namespace PublicLibrary.Controls
{
    public partial class OkDialog : UserControl
    {
        private OkDialogViewModel _viewModel;
        public OkDialogViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                this.DataContext = _viewModel;
            }
        }

        public OkDialog()
        {
            InitializeComponent();
            ViewModel = new OkDialogViewModel();
        }
    }
}
