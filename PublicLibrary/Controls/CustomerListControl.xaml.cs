using System.Windows.Controls;

namespace PublicLibrary.Controls
{
    public partial class CustomerListControl : UserControl, IControl
    {
        private CustomerListViewModel _viewModel;
        public CustomerListViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                this.DataContext = _viewModel;
            }
        }

        public CustomerListControl()
        {
            InitializeComponent();
            ViewModel = new CustomerListViewModel();
        }

        public void Reload()
        {
            ViewModel.Load();
        }
    }
}
