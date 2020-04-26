
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
namespace MVVMPracticePrism.ViewModels
{
    public class CustomRequestViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private readonly IDialogService _dialogService;
        public DelegateCommand OpenCommand { get; set; }
        public CustomRequestViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            OpenCommand = new DelegateCommand(ShowDialog);
        }
        private void ShowDialog()
        {
            string message = "This is a message that should be shown in the dialog.";
            //using the dialog service as-is
            _dialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), r =>
            {
                if (r.Result == ButtonResult.None)
                {
                    Title = "Result is None";
                }
                else if (r.Result == ButtonResult.OK)
                {
                    Title = "Result is OK";
                }
                else if (r.Result == ButtonResult.Cancel)
                {
                    Title = "Result is Cancel";
                }
                else
                {
                    Title = "I Don't know what you did!?";
                }
            });
        }
    }
}
