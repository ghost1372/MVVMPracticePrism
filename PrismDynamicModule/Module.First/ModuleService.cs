using Core;
using System;

namespace Module.First
{
    public class ModuleService : IModuleService
    {
        public ModuleModel GetModule()
        {
            Type moduleAType = typeof(FirstModule);
            ModuleModel module = new ModuleModel
            {
                DisplayName = "Module One",
                ModuleName = moduleAType.Name,
                DefaultView = typeof(Views.ViewA)
            };
            return module;
        }
    }
}
