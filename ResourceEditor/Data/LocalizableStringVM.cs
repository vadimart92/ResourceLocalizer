using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Prism.Mvvm;

namespace ResourceEditor.Data
{
	public class LocalizableStringVm:BindableBase
	{
		private string _value;
		public string Name { get; set; }
		public string Value {
			get
			{
				return _value;
			} 
			set
			{
				SetProperty(ref _value, value);
				IsEdited = true;
			}
		}

		public bool IsNew
		{
			get { return _isNew; }
			set
			{
				SetProperty(ref _isNew, value);
				UpdateColor();
			}
			
		}

		public bool IsEdited
		{
			get { return _isEdited; }
			set
			{
				SetProperty(ref _isEdited, value);
				UpdateColor();
			}
			
		}


		private SolidColorBrush _oldBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(0, 100, 150, 100));
		private SolidColorBrush _newBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(150, 100, 150, 100));
		private SolidColorBrush _editedBrush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(150, 220, 200, 80));
		private bool _isNew;
		private bool _isEdited;
		private Brush _color;

		void UpdateColor() {
			Color = IsNew ? (IsEdited ? _editedBrush : _newBrush) : _oldBrush;
		}

		public Brush Color
		{
			get { return _color; }
			set
			{
				if (_color != value) {
					SetProperty(ref _color, value);
				}
			}
		}
	}
}
