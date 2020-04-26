using Prism.Modularity;
using Prism.Mvvm;
using System;

namespace MVVMPracticePrism.ViewModels
{
    public class ModuleManualViewModel : BindableBase
    {
        public ModuleManualViewModel(IModuleCatalog moduleCatalog, IModuleManager moduleManager)
        {
            Type moduleAType = typeof(ModuleManualPractice.ModuleManualPracticeModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleAType.Name,
                ModuleType = moduleAType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });

            moduleManager.LoadModule(moduleAType.Name);
        }
    }
}
