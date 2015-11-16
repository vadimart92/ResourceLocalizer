using Prism.Mvvm;
using WPF.Common.Interfaces;

namespace ResourceEditor.VM
{
	public class MainVM:BindableBase {



		private IFileDialogService _fileDialogService;
        public MainVM(IFileDialogService fileDialogService) {
	        _fileDialogService = fileDialogService;
        }
	}
}
