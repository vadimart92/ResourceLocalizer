using Prism.Modularity;
using Prism.Regions;
using ResourceEditor.View;

namespace ResourceEditor
{
	[Module(ModuleName = "ResourceEditor")]
	public class ResourceEditor : IModule
	{
		readonly IRegionManager _regionManager;

		public ResourceEditor(IRegionManager regionManager) {
			_regionManager = regionManager;
		}

		public void Initialize() {
			_regionManager.RegisterViewWithRegion("MainRegion", typeof(MainView));
		}

	}
}
