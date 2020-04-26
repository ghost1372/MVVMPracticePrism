using Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace PrismDynamicModule.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<SelectionChangedEventArgs> SwitchItemCmd { get; private set; }

        public static MainWindowViewModel Instance;

        private ObservableCollection<ModuleModel> _dataService = new ObservableCollection<ModuleModel>();
        public ObservableCollection<ModuleModel> DataService
        {
            get => _dataService;
            set => SetProperty(ref _dataService, value);
        }

        private string _title = "Prism Application";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public IRegionManager region;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            region = regionManager;
            Instance = this;
            SwitchItemCmd = new DelegateCommand<SelectionChangedEventArgs>(Switch);
        }

        private void Switch(SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }

            if (e.AddedItems[0] is ModuleModel item)
            {

                //Clear last module
                foreach (object view in region.Regions["RegionModule"].Views)
                {
                    region.Regions["RegionModule"].Remove(view);
                }

                // register module
                region.RegisterViewWithRegion("RegionModule", item.DefaultView);
            }
        }
    }
}
