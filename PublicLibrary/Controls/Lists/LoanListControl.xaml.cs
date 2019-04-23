using System.Windows.Controls;

namespace PublicLibrary.Controls
{
    public partial class LoanListControl : UserControl, IControl
    {
        private LoanListViewModel _viewModel;
        public LoanListViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                this.DataContext = _viewModel;
            }
        }

        public LoanListControl()
        {
            InitializeComponent();
            ViewModel = new LoanListViewModel();
        }

        public void Reload()
        {
            ViewModel.Load();
        }
    }
}
