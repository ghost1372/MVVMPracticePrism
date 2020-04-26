using Core;
using HandyControl.Data;
using HandyControl.Tools;
using Prism.Ioc;
using Prism.Modularity;
using PrismDynamicModule.ViewModels;
using PrismDynamicModule.Views;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;

namespace PrismDynamicModule
{
    public partial class App
    {
        private const string MODULES_PATH = @".\modules";
        private ObservableCollection<ModuleModel> moduleCollection = null;
        protected override Window CreateShell()
        {
            MainWindow shell = Container.Resolve<MainWindow>();
            if (moduleCollection != null)
            {
                MainWindowViewModel.Instance.DataService.AddRange(moduleCollection);
            }
            return shell;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
        internal void UpdateSkin(SkinType skin)
        {
            ResourceHelper.GetTheme("HandyTheme", Resources).Skin = skin;
            Current.MainWindow?.OnApplyTemplate();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = MODULES_PATH };
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            DirectoryModuleCatalog directoryCatalog = (DirectoryModuleCatalog)moduleCatalog;
            directoryCatalog.Initialize();

            moduleCollection = new ObservableCollection<ModuleModel>();
            TypeFilter typeFilter = new TypeFilter(InterfaceFilter);

            foreach (IModuleCatalogItem item in directoryCatalog.Items)
            {
                ModuleInfo mi = (ModuleInfo)item;
                // in .NetFrameWork we dont need to replace
                Assembly asm = Assembly.LoadFrom(mi.Ref.Replace(@"file:///", ""));

                foreach (Type t in asm.GetTypes())
                {
                    Type[] myInterfaces = t.FindInterfaces(typeFilter, typeof(IModuleService).ToString());

                    if (myInterfaces.Length > 0)
                    {
                        IModuleService moduleService = (IModuleService)asm.CreateInstance(t.FullName);
                        ModuleModel module = moduleService.GetModule();
                        moduleCollection.Add(module);
                    }
                }
            }
        }

        private bool InterfaceFilter(Type typeObj, object criteriaObj)
        {
            return typeObj.ToString() == criteriaObj.ToString();
        }
    }
}
