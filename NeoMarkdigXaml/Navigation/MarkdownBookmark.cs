using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Neo.Markdig.Xaml
{
	public sealed class MarkdownBookmark : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (Equals(storage, value)) return false;
			storage = value;
			this.OnPropertyChanged(propertyName);
			return true;
		}

		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		public MarkdownBookmark(int level, string id, string header)
		{
			Level = level;
			Id = id;
			Header = header;
			Children = new List<MarkdownBookmark>();
		}

		public int Level { get; }
		public string Id { get; }
		public string Header { get; }
		public List<MarkdownBookmark> Children { get; }
		public bool IsSelected { get; set; }
		public bool IsExpanded { get; set; }

		public override string ToString() => Header;
	}
}
