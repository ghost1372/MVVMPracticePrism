using ModuleDirectoryPractice.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ModuleDirectoryPractice
{
    public class ModuleDirectoryPracticeModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegionModuleDirectory", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}