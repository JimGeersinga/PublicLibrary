using System.Windows.Controls;

namespace PublicLibrary.Controls
{
    public partial class BookItemListControl : UserControl, IControl
    {
        private BookItemListViewModel _viewModel;
        public BookItemListViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                this.DataContext = _viewModel;
            }
        }

        public BookItemListControl()
        {
            InitializeComponent();
            ViewModel = new BookItemListViewModel();
        }

        public void Reload()
        {
            ViewModel.Load();
        }
    }
}
