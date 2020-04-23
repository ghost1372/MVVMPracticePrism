using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVMPracticePrism.ViewModels
{
    public class ModuleManualViewModel : BindableBase
    {
        public ModuleManualViewModel(IModuleCatalog moduleCatalog, IModuleManager moduleManager)
        {
            var moduleAType = typeof(ModuleManualPractice.ModuleManualPracticeModule);
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
