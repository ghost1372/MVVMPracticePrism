using ModuleManualPractice.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleManualPractice
{
    public class ModuleManualPracticeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegionModuleManual", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}