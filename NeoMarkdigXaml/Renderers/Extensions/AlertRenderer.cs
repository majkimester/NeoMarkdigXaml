#region -- copyright --
//
// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
// 
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.
//
#endregion
using System;
using System.Windows.Documents;
using Markdig.Extensions.Alerts;
using Markdig.Helpers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace Neo.Markdig.Xaml.Renderers.Extensions
{
	#region -- class AlertBlockRenderer -----------------------------------------------

	/// <summary> </summary>
	public class AlertBlockRenderer : XamlObjectRenderer<AlertBlock>
    {
        /// <summary></summary>
        /// <param name="renderer"></param>
        /// <param name="alertBlock"></param>
        protected override void Write(XamlMarkdownWriter renderer, AlertBlock alertBlock)
		{
			if (alertBlock == null)
				throw new ArgumentNullException(nameof(alertBlock));

			renderer.WriteStartObject(typeof(Section));
			switch (alertBlock.Kind.ToString().ToLowerInvariant())
			{
				case "note":
					renderer.WriteResourceMember(null, MarkdownXamlStyle.AlertBlockNote);
					break;

				case "tip":
					renderer.WriteResourceMember(null, MarkdownXamlStyle.AlertBlockTip);
					break;

				case "important":
					renderer.WriteResourceMember(null, MarkdownXamlStyle.AlertBlockImportant);
					break;

				case "warning":
					renderer.WriteResourceMember(null, MarkdownXamlStyle.AlertBlockWarning);
					break;

				case "caution":
					renderer.WriteResourceMember(null, MarkdownXamlStyle.AlertBlockCaution);
					break;

				default:
					break;
			}

			// Insert Alert header before rendering
			if (alertBlock.Count > 0 && alertBlock[0] is ParagraphBlock p && p.Inline != null)
			{
				var header = new AlertHeaderInline { Kind = alertBlock.Kind };
				var lineBreak = new LineBreakInline { IsHard = true };

				var first = p.Inline.FirstChild;
				if (first != null)
				{
					first.InsertBefore(lineBreak);
					lineBreak.InsertBefore(header);
				}
				else
				{
					// Empty paragraph
					p.Inline.AppendChild(header);
				}
			}

			renderer.WriteItems(alertBlock);
			renderer.WriteEndObject();
		} // proc Write
	} // class AlertBlockRenderer

	#endregion

	#region -- class AlertHeaderInlineRenderer -----------------------------------------------

	public class AlertHeaderInlineRenderer : XamlObjectRenderer<AlertHeaderInline>
	{
		protected override void Write(XamlMarkdownWriter renderer, AlertHeaderInline headerInline)
		{
			renderer.WriteStartObject(typeof(Run));
			switch (headerInline.Kind.ToString().ToLowerInvariant())
			{
				case "note":
					renderer.WriteResourceMember(null, MarkdownXamlStyle.AlertBlockHeaderNote);
					break;

				case "tip":
					renderer.WriteResourceMember(null, MarkdownXamlStyle.AlertBlockHeaderTip);
					break;

				case "important":
					renderer.WriteResourceMember(null, MarkdownXamlStyle.AlertBlockHeaderImportant);
					break;

				case "warning":
					renderer.WriteResourceMember(null, MarkdownXamlStyle.AlertBlockHeaderWarning);
					break;

				case "caution":
					renderer.WriteResourceMember(null, MarkdownXamlStyle.AlertBlockHeaderCaution);
					break;

				default:
					break;
			}
			renderer.WriteEndObject();
		} // proc Write
	} // proc class AlertHeaderInlineRenderer

	#endregion

	#region -- class AlertHeaderInline  ------------------------------------------------------

	public sealed class AlertHeaderInline : LeafInline
	{
		public StringSlice Kind { get; set; }
	}

	#endregion
}
