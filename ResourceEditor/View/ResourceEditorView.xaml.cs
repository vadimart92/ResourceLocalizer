using System.Windows.Controls;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using ResourceEditor.VM;
using System.Linq;
using ResourceEditor.Data;

namespace ResourceEditor.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class ResourceEditorView : UserControl
	{
		public ResourceEditorView(ResourceEditorViewModel vm) {
			InitializeComponent();
			DataContext = vm;
		}

		private void RuItems_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
			var item = RuItems.SelectedItem as LocalizableStringVm;
			var enuItem = EnuItems.Items.OfType<LocalizableStringVm>().First(i => i.Name == item.Name);
			EnuItems.SelectedItem = enuItem;
			EnuItems.ScrollIntoView(enuItem);
		}
	}
}
