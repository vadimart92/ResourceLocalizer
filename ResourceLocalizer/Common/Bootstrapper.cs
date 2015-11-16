using System.Windows;
using BuildTools.View;
using BuildTools.VM;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace BuildTools.Common
{
	public class Bootstrapper : UnityBootstrapper
	{
		protected override DependencyObject CreateShell() {
			return Container.Resolve<MainWindow>();
		}
		
		protected override void InitializeShell() {
			base.InitializeShell();
			var shell = (Window) Shell;
			shell.DataContext = Container.Resolve<MainVindowVM>();
            Application.Current.MainWindow = shell;
			Application.Current.MainWindow.Show();
		}


		protected override IModuleCatalog CreateModuleCatalog() {
			return new DirectoryModuleCatalog { ModulePath = "Modules" };
		}

		protected override void ConfigureServiceLocator() {
			base.ConfigureServiceLocator();
			ServiceLocator.SetLocatorProvider(() => new UnityServiceLocatorAdapter(Container));
		}

		protected override void ConfigureContainer() {
			base.ConfigureContainer();
			Container.RegisterType<MainVindowVM>();
		}
	}
}
