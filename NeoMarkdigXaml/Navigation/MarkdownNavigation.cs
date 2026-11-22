using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Neo.Markdig.Xaml
{
	public static class MarkdownNavigation
	{
		/// <summary>
		/// Find Paragraph by MarkdownAttached.Id
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public static Paragraph FindById(FlowDocument doc, string id)
			=> Descendants(doc.Blocks).OfType<Paragraph>()
				.FirstOrDefault(p => String.Equals(MarkdownAttached.GetId(p), id, StringComparison.Ordinal));

		private static IEnumerable<Block> Descendants(IEnumerable<Block> blocks)
		{
			foreach (var b in blocks)
			{
				yield return b;
				IEnumerable<Block> children = null;
				if (b is Section s) children = s.Blocks;
				else if (b is List l) children = l.ListItems.SelectMany(i => i.Blocks);
				else if (b is Table t) children = t.RowGroups.SelectMany(g => g.Rows)
												   .SelectMany(r => r.Cells).SelectMany(c => c.Blocks);
				if (children != null)
					foreach (var c in Descendants(children))
						yield return c;
			}
		}

		/// <summary>
		/// Scrolls to the heading with the given id.
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="paragraph"></param>
		/// <returns></returns>
		public static bool ScrollTo(FlowDocument doc, Paragraph paragraph)
		{
			paragraph.BringIntoView();
			return true;
		}

		private static void ScrollToTop(FlowDocumentScrollViewer viewer, Paragraph paragraph)
		{
			var sv = viewer.Template?.FindName("PART_ContentHost", viewer) as ScrollViewer;
			if (sv != null)
			{
				sv.ScrollToEnd();
				sv.UpdateLayout();
			}

			paragraph.BringIntoView();
		}

		/// <summary>
		/// Handles internal links (#id). Returns true if the link was handled.
		/// </summary>
		/// <param name="source">e.OriginalSource (the Hyperlink) or the viewer/document.</param>
		/// <param name="parameter">e.Parameter of the command.</param>
		public static bool TryNavigateInternal(object source, object parameter)
		{
			var target = parameter is Uri uri ? uri.OriginalString : parameter?.ToString();
			if (String.IsNullOrEmpty(target) || target[0] != '#')
				return false;

			var doc = GetDocument(source);
			if (doc == null)
				return false;

			var id = Uri.UnescapeDataString(target.Substring(1));

			var paragraph = FindById(doc, id);
			if (paragraph != null)
			{
				if (doc.Parent is FlowDocumentScrollViewer viewer)
					ScrollToTop(viewer, paragraph);
				else
					ScrollTo(doc, paragraph);
			}

			return true;
		}

		private static FlowDocument GetDocument(object source)
		{
			switch (source)
			{
				case FlowDocument d:
					return d;
				case FlowDocumentScrollViewer sv:
					return sv.Document;
				case FlowDocumentReader r:
					return r.Document;
				case FlowDocumentPageViewer pv:
					return pv.Document as FlowDocument;
				case DependencyObject dep:
					// walk up the logical tree: Hyperlink -> Paragraph -> ... -> FlowDocument
					while (dep != null)
					{
						if (dep is FlowDocument fd)
							return fd;
						dep = LogicalTreeHelper.GetParent(dep);
					}
					return null;
				default:
					return null;
			}
		}

		/// <summary>
		/// Collects all headings of the document as a tree, usable as ItemsSource.
		/// </summary>
		/// <param name="doc"></param>
		/// <returns></returns>
		public static List<MarkdownBookmark> GetBookmarks(FlowDocument doc)
		{
			var roots = new List<MarkdownBookmark>();
			if (doc == null)
				return roots;

			var stack = new Stack<MarkdownBookmark>();

			// Descendants returns the blocks in document order
			foreach (var p in Descendants(doc.Blocks).OfType<Paragraph>())
			{
				var level = MarkdownAttached.GetLevel(p);
				if (level <= 0)
					continue;   // not a heading

				var bookmark = new MarkdownBookmark(level, MarkdownAttached.GetId(p), MarkdownAttached.GetHeader(p));

				// leave all branches that are on the same or a deeper level
				while (stack.Count > 0 && stack.Peek().Level >= level)
					stack.Pop();

				if (stack.Count == 0)
					roots.Add(bookmark);
				else
					stack.Peek().Children.Add(bookmark);

				stack.Push(bookmark);
			}

			return roots;
		}
	}
}
