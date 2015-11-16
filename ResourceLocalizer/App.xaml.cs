using System.Windows;
using BuildTools.Common;

namespace BuildTools
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {

		public Bootstrapper Bootstrapper { get; set; }

		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);
			Bootstrapper = new Bootstrapper();
			Bootstrapper.Run();
		}
	}
}
