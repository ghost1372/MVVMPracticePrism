using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVMPracticePrism.ViewModels
{
    public class MessageSenderViewModel : BindableBase
    {
        IEventAggregator _ea;

        private string _message = "Message to Send";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand SendCommand { get; private set; }

        public MessageSenderViewModel(IEventAggregator ea)
        {
            _ea = ea;
            SendCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            _ea.GetEvent<PubSubEvent<string>>().Publish(Message);
        }
    }
}
