using HandyControl.Controls;
using Prism.Mvvm;
using Prism.Regions;

namespace MVVMPracticePrism.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware
    {
        private string _title = "ViewA Item";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public ViewAViewModel()
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
