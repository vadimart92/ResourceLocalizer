using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using ResourceEditor.BL;
using ResourceEditor.Data;
using WPF.Common.Interfaces;

namespace ResourceEditor.VM
{
	public class ResourceEditorViewModel: BindableBase
	{
		private ResourceLoader _resourceLoader;
		private IFileDialogService _fileDialogService;

		public DelegateCommand OpenFileCmd { get; private set; }
		public DelegateCommand CopyToRuCmd { get; private set; }
		public DelegateCommand SaveCmd { get; private set; }
		public ObservableCollection<LocalizableStringVm> EnuRows { get; protected set; }
		public ObservableCollection<LocalizableStringVm> RuRows { get; protected set; } 
		
        public ResourceEditorViewModel(IFileDialogService fileDialogService) {
	        _fileDialogService = fileDialogService;
			EnuRows = new ObservableCollection<LocalizableStringVm>();
			RuRows = new ObservableCollection<LocalizableStringVm>();
	        InitCommands();
        }

		private void InitCommands() {
			OpenFileCmd = new DelegateCommand(OpenFile);
			CopyToRuCmd = new DelegateCommand(CopyToRu);
			SaveCmd = new DelegateCommand(Save);
		}

		void OpenFile() {
			var fileName = _fileDialogService.OpenFile("xml resources|*.xml|All files|*.*");
			_resourceLoader = new ResourceLoader(fileName);
			EnuRows.Clear();
			RuRows.Clear();
			EnuRows.AddRange(_resourceLoader.GetLocalizableStrings(Culture.EN));
			RuRows.AddRange(_resourceLoader.GetLocalizableStrings(Culture.RU));
		}

		void CopyToRu() {
			int counter = 0;
			foreach (var enuRow in EnuRows) {
				if (RuRows.All(r=>r.Name != enuRow.Name)) {
					RuRows.Add(new LocalizableStringVm {
						Name = enuRow.Name,
						Value = enuRow.Value,
						IsNew = true,
						IsEdited = false
					});
					counter++;
				}
			}
			MessageBox.Show(String.Format("Copied: {0}", counter));
		}

		void Save() {
			_resourceLoader.SetLocalizableStrings(Culture.RU, RuRows.ToList());
			_resourceLoader.Save();
			MessageBox.Show("Success");
		}
	}
}
