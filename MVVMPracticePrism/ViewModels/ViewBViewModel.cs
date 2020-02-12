using HandyControl.Controls;
using Prism.Mvvm;
using Prism.Regions;

namespace MVVMPracticePrism.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        private string _title = "ViewB Item";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public ViewBViewModel()
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            string person = navigationContext.Parameters["person"] as string;
            if (!string.IsNullOrEmpty(person))
            {
                MessageBox.Show(person);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
