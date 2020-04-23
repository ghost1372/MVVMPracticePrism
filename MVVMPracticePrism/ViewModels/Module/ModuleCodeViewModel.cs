using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVMPracticePrism.ViewModels
{
    public class ModuleCodeViewModel : BindableBase
    {
        public ModuleCodeViewModel(IModuleCatalog moduleCatalog, IModuleManager moduleManager)
        {
            var moduleAType = typeof(ModuleCodePractice.ModuleCodePracticeModule);

            moduleCatalog.AddModule<ModuleCodePractice.ModuleCodePracticeModule>();
            moduleManager.LoadModule(moduleAType.Name);
        }
        
    }
}
