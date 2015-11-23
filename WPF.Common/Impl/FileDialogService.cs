using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using WPF.Common.Interfaces;

namespace WPF.Common.Impl
{
	public class FileDialogService:IFileDialogService
	{
		public string OpenFile(string filter = null) {
			var ofd = new OpenFileDialog() {
				Filter = filter
			};
			return (ofd.ShowDialog() ?? false) ? ofd.FileName : null;
		}
	}
}
