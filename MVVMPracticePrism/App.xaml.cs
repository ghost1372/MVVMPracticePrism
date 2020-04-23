using HandyControl.Data;
using HandyControl.Tools;
using MVVMPracticePrism.ViewModels;
using MVVMPracticePrism.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Windows;

namespace MVVMPracticePrism
{
    public partial class App
    {
        protected override Window CreateShell()
        {
           return ShowSplashScreen(true);
        }

        internal Window ShowSplashScreen(bool ShowSplashScreen)
        {
            if (ShowSplashScreen)
            {
                SplashShell splash = new SplashShell();
                splash.Show();

                MainWindow shell = new MainWindow();
                shell.Dispatcher.BeginInvoke((Action)delegate {
                    shell.Show();
                    splash.Close();
                });
                return shell;
            }
            else
            {
                return Container.Resolve<MainWindow>();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();

            containerRegistry.RegisterForNavigation<ComboBox>();
            containerRegistry.RegisterForNavigation<TabControl>();
            containerRegistry.RegisterForNavigation<ListBox>();
            containerRegistry.RegisterForNavigation<Soon>();
            containerRegistry.RegisterForNavigation<SendParameters>();
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<EventAggregator>();
            containerRegistry.RegisterForNavigation<CustomRequest>();
            containerRegistry.RegisterForNavigation<RegionLifetime>();
            containerRegistry.RegisterForNavigation<ModuleCode>();
            containerRegistry.RegisterForNavigation<ModuleDirectory>();
            containerRegistry.RegisterForNavigation<ModuleManual>();
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
