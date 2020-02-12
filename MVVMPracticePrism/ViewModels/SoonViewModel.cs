using Prism.Mvvm;

namespace MVVMPracticePrism.ViewModels
{
    public class SoonViewModel : BindableBase
    {
        private string _title = "New Tab Item";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public SoonViewModel()
        {

        }
    }
}
