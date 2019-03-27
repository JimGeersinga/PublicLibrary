using GalaSoft.MvvmLight;

namespace PublicLibrary.ViewModels
{
    public class OkDialogViewModel : ViewModelBase
    {
        private string _content;
        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                RaisePropertyChanged();
            }
        }

        public OkDialogViewModel(string content = null)
        {
            Content = content;
        }
    }
}
