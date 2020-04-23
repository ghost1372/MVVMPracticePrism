using ModuleCodePractice.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleCodePractice
{
    public class ModuleCodePracticeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegionModuleCode", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}