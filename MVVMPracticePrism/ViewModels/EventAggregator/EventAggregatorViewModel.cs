using MVVMPracticePrism.Views;
using Prism.Mvvm;
using Prism.Regions;

namespace MVVMPracticePrism.ViewModels
{
    public class EventAggregatorViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public EventAggregatorViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("SendRegion", typeof(MessageSender));
            _regionManager.RegisterViewWithRegion("ReceiverRegion", typeof(MessageReceiver));
        }
    }
}
