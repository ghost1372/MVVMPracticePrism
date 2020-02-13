using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace MVVMPracticePrism.ViewModels
{
    public class ListBoxViewModel : BindableBase
    {
        public DelegateCommand<SelectionChangedEventArgs> SwitchItemCmd { get; private set; }

        private ObservableCollection<Person> _Items = new ObservableCollection<Person>();

        public ObservableCollection<Person> Items
        {
            get => _Items;
            set => SetProperty(ref _Items, value);
        }

        private string _SelectedText;
        public string SelectedText
        {
            get => _SelectedText;
            set => SetProperty(ref _SelectedText, value);
        }

        public ListBoxViewModel()
        {
            SwitchItemCmd = new DelegateCommand<SelectionChangedEventArgs>(Switch);

            for (int i = 0; i < 10; i++)
            {
                Items.Add(new Person { Name = $"Hello {i}", LName = "Bye!" });
            }
        }

        private void Switch(SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }

            if (e.AddedItems[0] is Person item)
            {
                SelectedText = item.Name;
            }
        }
    }
}
