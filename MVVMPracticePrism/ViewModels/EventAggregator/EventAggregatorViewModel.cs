using MVVMPracticePrism.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

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
