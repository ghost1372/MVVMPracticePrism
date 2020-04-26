using Prism.Modularity;
using Prism.Mvvm;
using System;

namespace MVVMPracticePrism.ViewModels
{
    public class ModuleCodeViewModel : BindableBase
    {
        public ModuleCodeViewModel(IModuleCatalog moduleCatalog, IModuleManager moduleManager)
        {
            Type moduleAType = typeof(ModuleCodePractice.ModuleCodePracticeModule);

            moduleCatalog.AddModule<ModuleCodePractice.ModuleCodePracticeModule>();
            moduleManager.LoadModule(moduleAType.Name);
        }

    }
}
