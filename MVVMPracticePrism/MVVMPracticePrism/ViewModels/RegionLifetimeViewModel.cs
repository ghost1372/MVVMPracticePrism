using Prism.Mvvm;
using Prism.Regions;

namespace MVVMPracticePrism.ViewModels
{
    public class RegionLifetimeViewModel : BindableBase, IRegionMemberLifetime
    {
        public bool KeepAlive => false;

        public RegionLifetimeViewModel()
        {

        }
    }
}
