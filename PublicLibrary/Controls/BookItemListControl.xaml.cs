using System.Windows.Controls;

namespace PublicLibrary.Controls
{
    public partial class BookItemListControl : UserControl, IControl
    {
        private BookListViewModel _viewModel;
        public BookListViewModel ViewModel
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
            ViewModel = new BookListViewModel();
        }

        public void Reload()
        {
            ViewModel.Load();
        }
    }
}
