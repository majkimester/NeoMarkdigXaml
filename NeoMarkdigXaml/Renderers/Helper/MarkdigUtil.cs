using System.Text;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace Neo.Markdig.Xaml
{
	public static class MarkdigUtil
	{
		public static string GetPlainText(LeafBlock block)
		{
			var sb = new StringBuilder();
			if (block.Inline != null)
				AppendText(sb, block.Inline);
			return sb.ToString();
		}

		private static void AppendText(StringBuilder sb, ContainerInline container)
		{
			foreach (var inline in container)
			{
				switch (inline)
				{
					case LiteralInline literal:
						sb.Append(literal.Content.ToString());
						break;

					case CodeInline code:
						sb.Append(code.Content);
						break;

					case LineBreakInline _:
						sb.Append(' ');
						break;

					case ContainerInline child:   // emphasis, links, etc.
						AppendText(sb, child);
						break;
				}
			}
		}
	}
}
