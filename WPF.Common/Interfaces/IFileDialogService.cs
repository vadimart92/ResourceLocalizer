﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Common.Interfaces
{
	public interface IFileDialogService {
		string OpenFile(string filter);
	}
}
