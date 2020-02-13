using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace MVVMPracticePrism.ViewModels
{
    public class SendParametersViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "SendParameters";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _passText;
        public string PassText
        {
            get => _passText;
            set => SetProperty(ref _passText, value);
        }
        public DelegateCommand<string> NavigateCommand { get; private set; }

        public SendParametersViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigatePath)
        {
            NavigationParameters parameters = new NavigationParameters
            {
                { "person", PassText }
            };

            if (navigatePath != null)
            {
                _regionManager.RequestNavigate("ParameterRegion", navigatePath, parameters);
            }
        }
    }
}
