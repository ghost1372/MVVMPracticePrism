using MVVMPracticePrism.Views;
using Prism.Mvvm;
using Prism.Regions;

namespace MVVMPracticePrism.ViewModels
{
    public class TabControlViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "Prism";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public TabControlViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("TabRegion", typeof(Soon));
        }
    }
}
