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
using System.ComponentModel;
using System.Reflection;
using System.Windows;

namespace Neo.Markdig.Xaml
{
	/// <summary></summary>
	public enum MarkdownXamlStyle
	{
		/// <summary>Resource Key for the DocumentStyle.</summary>
		Document,
		/// <summary>Resource Key for the CodeStyle.</summary>
		Code,
		/// <summary>Resource Key for the CodeBlockStyle.</summary>
		CodeBlock,
		/// <summary>Resource Key for the Heading1Style.</summary>
		Heading1,
		/// <summary>Resource Key for the Heading2Style.</summary>
		Heading2,
		/// <summary>Resource Key for the Heading3Style.</summary>
		Heading3,
		/// <summary>Resource Key for the Heading4Style.</summary>
		Heading4,
		/// <summary>Resource Key for the Heading5Style.</summary>
		Heading5,
		/// <summary>Resource Key for the Heading6Style.</summary>
		Heading6,
		/// <summary>Resource Key for the ImageStyle.</summary>
		Image,
		/// <summary>Resource Key for the InsertedStyle.</summary>
		Inserted,
		/// <summary>Resource Key for the MarkedStyle.</summary>
		Marked,
		/// <summary>Resource Key for the QuoteBlockStyle.</summary>
		QuoteBlock,
		/// <summary>Resource Key for the AlertBlockNoteStyle.</summary>
		AlertBlockNote,
		/// <summary>Resource Key for the AlertBlockTipStyle.</summary>
		AlertBlockTip,
		/// <summary>Resource Key for the AlertBlockImportanttyle.</summary>
		AlertBlockImportant,
		/// <summary>Resource Key for the AlertBlockWarningStyle.</summary>
		AlertBlockWarning,
		/// <summary>Resource Key for the AlertBlockCautionStyle.</summary>
		AlertBlockCaution,
		/// <summary>Resource Key for the AlertBlockHeaderNoteStyle.</summary>
		AlertBlockHeaderNote,
		/// <summary>Resource Key for the AlertBlockHeaderTipStyle.</summary>
		AlertBlockHeaderTip,
		/// <summary>Resource Key for the AlertBlockHeaderImportanttyle.</summary>
		AlertBlockHeaderImportant,
		/// <summary>Resource Key for the AlertBlockHeaderWarningStyle.</summary>
		AlertBlockHeaderWarning,
		/// <summary>Resource Key for the AlertBlockHeaderCautionStyle.</summary>
		AlertBlockHeaderCaution,
		/// <summary>Resource Key for the StrikeThroughStyle.</summary>
		StrikeThrough,
		/// <summary>Resource Key for the SubscriptStyle.</summary>
		Subscript,
		/// <summary>Resource Key for the SuperscriptStyle.</summary>
		Superscript,
		/// <summary>Resource Key for the TableStyle.</summary>
		Table,
		/// <summary>Resource Key for the TableCellStyle.</summary>
		TableCell,
		/// <summary>Resource Key for the TableHeaderStyle.</summary>
		TableHeader,
		/// <summary>Resource Key for the TaskListStyle.</summary>
		TaskList,
		/// <summary>Resource Key for the ThematicBreakStyle.</summary>
		ThematicBreak,
		/// <summary>Resource Key for the HyperlinkStyle.</summary>
		Hyperlink,
		/// <summary>Resource Key for the MathBlockStyle.</summary>
		MathBlock,
		/// <summary>Resource Key for the MathBlockFormulaStyle.</summary>
		MathBlockFormula,
		/// <summary>Resource Key for the MathInlineFormulaStyle.</summary>
		MathInlineFormula,
	} // enum MarkdownXamlStyle

	public static partial class MarkdownXaml
	{
		#region -- class StyleResourceKey----------------------------------------------

		private sealed class StyleResourceKey : ResourceKey
		{
			public StyleResourceKey(string key)
				=> Key = key;

			public override string ToString()
				=> "XamlStyle: " + Key;

			public override bool Equals(object obj)
				=> obj is StyleResourceKey srk ? Key.Equals(srk.Key) : base.Equals(obj);

			public override int GetHashCode()
				=> Assembly.GetHashCode() ^ Key.GetHashCode();

			public string Key { get; }
			public override Assembly Assembly => typeof(StyleResourceKey).Assembly;
		} // class StyleResourceKey

		#endregion

		/// <summary>Resource Key for the DocumentStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey DocumentStyleKey { get; } = new StyleResourceKey(nameof(DocumentStyleKey));

		/// <summary>Resource Key for the CodeStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey CodeStyleKey { get; } = new StyleResourceKey(nameof(CodeStyleKey));

		/// <summary>Resource Key for the CodeBlockStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey CodeBlockStyleKey { get; } = new StyleResourceKey(nameof(CodeBlockStyleKey));

		/// <summary>Resource Key for the Heading1Style.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey Heading1StyleKey { get; } = new StyleResourceKey(nameof(Heading1StyleKey));

		/// <summary>Resource Key for the Heading2Style.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey Heading2StyleKey { get; } = new StyleResourceKey(nameof(Heading2StyleKey));

		/// <summary>Resource Key for the Heading3Style.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey Heading3StyleKey { get; } = new StyleResourceKey(nameof(Heading3StyleKey));

		/// <summary>Resource Key for the Heading4Style.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey Heading4StyleKey { get; } = new StyleResourceKey(nameof(Heading4StyleKey));

		/// <summary>Resource Key for the Heading5Style.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey Heading5StyleKey { get; } = new StyleResourceKey(nameof(Heading5StyleKey));

		/// <summary>Resource Key for the Heading6Style.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey Heading6StyleKey { get; } = new StyleResourceKey(nameof(Heading6StyleKey));

		/// <summary>Resource Key for the ImageStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey ImageStyleKey { get; } = new StyleResourceKey(nameof(ImageStyleKey));

		/// <summary>Resource Key for the InsertedStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey InsertedStyleKey { get; } = new StyleResourceKey(nameof(InsertedStyleKey));

		/// <summary>Resource Key for the MarkedStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey MarkedStyleKey { get; } = new StyleResourceKey(nameof(MarkedStyleKey));

		/// <summary>Resource Key for the QuoteBlockStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey QuoteBlockStyleKey { get; } = new StyleResourceKey(nameof(QuoteBlockStyleKey));

		/// <summary>Resource Key for the AlertBlockNoteStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey AlertBlockNoteStyleKey { get; } = new StyleResourceKey(nameof(AlertBlockNoteStyleKey));

		/// <summary>Resource Key for the AlertBlockTipStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey AlertBlockTipStyleKey { get; } = new StyleResourceKey(nameof(AlertBlockTipStyleKey));

		/// <summary>Resource Key for the AlertBlockImportantStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey AlertBlockImportantStyleKey { get; } = new StyleResourceKey(nameof(AlertBlockImportantStyleKey));

		/// <summary>Resource Key for the AlertBlockWarningStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey AlertBlockWarningStyleKey { get; } = new StyleResourceKey(nameof(AlertBlockWarningStyleKey));

		/// <summary>Resource Key for the AlertBlockCautionStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey AlertBlockCautionStyleKey { get; } = new StyleResourceKey(nameof(AlertBlockCautionStyleKey));

		/// <summary>Resource Key for the AlertBlockHeaderNoteStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey AlertBlockHeaderNoteStyleKey { get; } = new StyleResourceKey(nameof(AlertBlockHeaderNoteStyleKey));

		/// <summary>Resource Key for the AlertBlockHeaderTipStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey AlertBlockHeaderTipStyleKey { get; } = new StyleResourceKey(nameof(AlertBlockHeaderTipStyleKey));

		/// <summary>Resource Key for the AlertBlockHeaderImportantStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey AlertBlockHeaderImportantStyleKey { get; } = new StyleResourceKey(nameof(AlertBlockHeaderImportantStyleKey));

		/// <summary>Resource Key for the AlertBlockHeaderWarningStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey AlertBlockHeaderWarningStyleKey { get; } = new StyleResourceKey(nameof(AlertBlockHeaderWarningStyleKey));

		/// <summary>Resource Key for the AlertBlockHeaderCautionStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey AlertBlockHeaderCautionStyleKey { get; } = new StyleResourceKey(nameof(AlertBlockHeaderCautionStyleKey));

		/// <summary>Resource Key for the StrikeThroughStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey StrikeThroughStyleKey { get; } = new StyleResourceKey(nameof(StrikeThroughStyleKey));

		/// <summary>Resource Key for the SubscriptStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey SubscriptStyleKey { get; } = new StyleResourceKey(nameof(SubscriptStyleKey));

		/// <summary>Resource Key for the SuperscriptStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey SuperscriptStyleKey { get; } = new StyleResourceKey(nameof(SuperscriptStyleKey));

		/// <summary>Resource Key for the TableStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey TableStyleKey { get; } = new StyleResourceKey(nameof(TableStyleKey));

		/// <summary>Resource Key for the TableCellStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey TableCellStyleKey { get; } = new StyleResourceKey(nameof(TableCellStyleKey));

		/// <summary>Resource Key for the TableHeaderStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey TableHeaderStyleKey { get; } = new StyleResourceKey(nameof(TableHeaderStyleKey));

		/// <summary>Resource Key for the TaskListStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey TaskListStyleKey { get; } = new StyleResourceKey(nameof(TaskListStyleKey));

		/// <summary>Resource Key for the ThematicBreakStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey ThematicBreakStyleKey { get; } = new StyleResourceKey(nameof(ThematicBreakStyleKey));

		/// <summary>Resource Key for the HyperlinkStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey HyperlinkStyleKey { get; } = new StyleResourceKey(nameof(HyperlinkStyleKey));

		/// <summary>Resource Key for the MathBlockStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey MathBlockStyleKey { get; } = new StyleResourceKey(nameof(MathBlockStyleKey));

		/// <summary>Resource Key for the MathBlockFormulaStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey MathBlockFormulaStyleKey { get; } = new StyleResourceKey(nameof(MathBlockFormulaStyleKey));

		/// <summary>Resource Key for the MathInlineFormulaStyle.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceKey MathInlineFormulaKey { get; } = new StyleResourceKey(nameof(MathInlineFormulaKey));

	} // classs MarkdownXaml
}
