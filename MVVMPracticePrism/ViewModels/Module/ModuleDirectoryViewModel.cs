using Prism.Modularity;
using Prism.Mvvm;
using System.Linq;

namespace MVVMPracticePrism.ViewModels
{
    public class ModuleDirectoryViewModel : BindableBase
    {
        public ModuleDirectoryViewModel(IModuleManager moduleManager, IModuleCatalog moduleCatalog)
        {
            ModuleCatalog directoryCatalog = new DirectoryModuleCatalog() { ModulePath = @"Modules" };

            directoryCatalog.Initialize();
            foreach (IModuleCatalogItem module in directoryCatalog.Items)
            {
                ModuleInfo mi = (ModuleInfo)module;
                moduleCatalog.AddModule(mi);
            }

            moduleManager.LoadModule(directoryCatalog.Modules.First().ModuleName);
        }
    }
}
