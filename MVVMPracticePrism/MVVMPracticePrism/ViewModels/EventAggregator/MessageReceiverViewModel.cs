using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace MVVMPracticePrism.ViewModels
{
    public class MessageReceiverViewModel : BindableBase
    {
        private readonly IEventAggregator _ea;

        private ObservableCollection<string> _messages;
        public ObservableCollection<string> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        public MessageReceiverViewModel(IEventAggregator ea)
        {
            _ea = ea;
            Messages = new ObservableCollection<string>();

            _ea.GetEvent<PubSubEvent<string>>().Subscribe(MessageReceived);
        }

        private void MessageReceived(string message)
        {
            Messages.Add(message);
        }

    }
}
