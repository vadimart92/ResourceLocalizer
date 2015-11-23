using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Terrasoft.Common;
using ResourceEditor.Data;

namespace ResourceEditor.BL
{
	public class ResourceLoader
	{
		private readonly ResourcePackage _enuResourcePackage;
		private readonly ResourcePackage _ruResourcePackage;
		private string _enuResourceFileName;
		private string _ruResourceFileName;

		public ResourceLoader(string fileName) {
			_enuResourceFileName = fileName;
			InitRuFileName();
			_enuResourcePackage = new ResourcePackage(CultureInfo.GetCultureInfo("en-US"));
			using (var stream = new FileStream(fileName, FileMode.Open)) {
				using (var reader = new XmlResourceReader(stream)) {
					reader.ReadToDescendant("Resources");
					_enuResourcePackage.ReadXml(reader);
				}
			}
			_ruResourcePackage = new ResourcePackage(CultureInfo.GetCultureInfo("ru-RU"));
			using (var stream = new FileStream(_ruResourceFileName, FileMode.Open)) {
				using (var reader = new XmlResourceReader(stream)) {
					reader.ReadToDescendant("Resources");
					_ruResourcePackage.ReadXml(reader);
				}
			}
		}

		void InitRuFileName() {
			var fi = new FileInfo(_enuResourceFileName);
			_ruResourceFileName = Path.Combine(fi.DirectoryName, "resource.ru-RU.xml");
		}

		public void Save() {
			using (var writer = new XmlResourceWriter(_enuResourceFileName, Encoding.UTF8)) {
				_enuResourcePackage.SaveToStream(writer);
			}
			using (var writer = new XmlResourceWriter(_ruResourceFileName, Encoding.UTF8)) {
				_ruResourcePackage.SaveToStream(writer);
			}
		}

		public List<LocalizableStringVm> GetLocalizableStrings(Culture culture) {
			var package = culture == Culture.EN ? _enuResourcePackage : _ruResourcePackage;
			var strings = from stringItem in package.RootGroup.Items
				select new LocalizableStringVm {
					Name = stringItem.Name,
					Value = stringItem.StringValue
				};
			return strings.ToList();
		}

		public void SetLocalizableStrings(Culture culture, List<LocalizableStringVm> strings) {
			var package = culture == Culture.EN ? _enuResourcePackage : _ruResourcePackage;
			foreach (var stringVm in strings.Where(s=>s.IsEdited || s.IsNew)) {
				var existItem = package.RootGroup.Items.FirstOrDefault(i => i.Name == stringVm.Name);
				if (existItem != null) {
					existItem.StringValue = stringVm.Value;
				} else {
					package.RootGroup.Items.Add(new ResourceItem {
						Name = stringVm.Name,
						StringValue = stringVm.Value
					});
				}
			}
		}
	}
}
