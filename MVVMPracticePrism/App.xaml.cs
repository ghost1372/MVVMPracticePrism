using HandyControl.Data;
using HandyControl.Tools;
using MVVMPracticePrism.Views;
using Prism.Ioc;
using System;
using System.Windows;

namespace MVVMPracticePrism
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ComboBox>();
            containerRegistry.RegisterForNavigation<TabControl>();
            containerRegistry.RegisterForNavigation<ListBox>();
            containerRegistry.RegisterForNavigation<Soon>();
            containerRegistry.RegisterForNavigation<SendParameters>();
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<EventAggregator>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigHelper.Instance.SetWindowDefaultStyle();
        }
        internal void UpdateSkin(SkinType skin)
        {
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri($"pack://application:,,,/HandyControl;component/Themes/Skin{skin.ToString()}.xaml")
            });
            Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/HandyControl;component/Themes/Theme.xaml")
            });
        }
    }
}
