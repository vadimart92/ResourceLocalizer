using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Modularity;

namespace BuildTools.Common
{
	public interface IBuildToolsModule:IModule
	{
		string Name { get; set; }
		UserControl View { get; set; }
	}
}
