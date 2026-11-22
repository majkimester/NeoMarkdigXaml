using System.Collections.Generic;

namespace Neo.Markdig.Xaml
{
	public sealed class MarkdownBookmark
	{
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

		public override string ToString() => Header;
	}
}
