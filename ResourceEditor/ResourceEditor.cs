using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using Prism.Modularity;
using Prism.Regions;
using ResourceEditor.View;
using ResourceEditor.VM;
using WPF.Common.Impl;
using WPF.Common.Interfaces;

namespace ResourceEditor
{
	[Module(ModuleName = "ResourceEditor")]
	public class ResourceEditor : IModule
	{
		readonly IRegionManager _regionManager;
		private readonly IUnityContainer _unityContainer;

		public ResourceEditor(IRegionManager regionManager, IUnityContainer unityContainer) {
			_regionManager = regionManager;
			_unityContainer = unityContainer;
		}

		public void Initialize() {
			_unityContainer.RegisterType<IFileDialogService, FileDialogService>();
			_unityContainer.RegisterType<View.ResourceEditorView>();
			_unityContainer.RegisterType<VM.ResourceEditorViewModel>();
			_regionManager.RegisterViewWithRegion("MainRegion", () => _unityContainer.Resolve<View.ResourceEditorView>());
		}

	}
}
