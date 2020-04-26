using Core;
using System;

namespace Module.Second
{
    public class ModuleService : IModuleService
    {
        public ModuleModel GetModule()
        {
            Type moduleAType = typeof(SecondModule);
            ModuleModel module = new ModuleModel
            {
                DisplayName = "Module Two",
                ModuleName = moduleAType.Name,
                DefaultView = typeof(Views.ViewA)
            };
            return module;
        }
    }
}
