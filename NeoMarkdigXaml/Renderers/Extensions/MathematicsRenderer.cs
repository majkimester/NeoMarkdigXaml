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
using System.Windows;
using System.Windows.Documents;
using Markdig.Extensions.Mathematics;
using WpfMath.Controls;

namespace Neo.Markdig.Xaml.Renderers.Extensions
{

	#region -- class MathBlockRenderer -----------------------------------------------

	/// <summary> </summary>
	public class MathBlockRenderer : XamlObjectRenderer<MathBlock>
    {
		/// <summary></summary>
		/// <param name="renderer"></param>
		/// <param name="mathBlock"></param>
		protected override void Write(XamlMarkdownWriter renderer, MathBlock mathBlock)
        {
			string formula = mathBlock.Lines.ToString();

			renderer.WriteStartObject(typeof(Paragraph));
			renderer.WriteResourceMember(null, MarkdownXamlStyle.MathBlock);
			renderer.WriteStartItems(renderer.GetContentProperty(), false);

			renderer.WriteStartObject(typeof(InlineUIContainer));
			renderer.WriteStartMember(nameof(InlineUIContainer.Child));

			renderer.WriteStartObject(typeof(FormulaControl));
			renderer.WriteResourceMember(null, MarkdownXamlStyle.MathBlockFormula);
			renderer.WriteMember(FormulaControl.FormulaProperty, formula);
			renderer.WriteEndObject();

			renderer.WriteEndMember(); // </InlineUIContainer.Child>
			renderer.WriteEndObject(); // </InlineUIContainer>

			renderer.WriteEndItems();
			renderer.WriteEndObject();

		} // proc Write
	} // class MathBlockRenderer

	#endregion

	#region -- class MathInlineRenderer -----------------------------------------------

	/// <summary> </summary>
	public class MathInlineRenderer : XamlObjectRenderer<MathInline>
	{
		/// <summary></summary>
		/// <param name="renderer"></param>
		/// <param name="mathInline"></param>
		protected override void Write(XamlMarkdownWriter renderer, MathInline mathInline)
		{
			string formula = mathInline.Content.ToString();

			renderer.WriteStartObject(typeof(InlineUIContainer));
			renderer.WriteMember(InlineUIContainer.BaselineAlignmentProperty, BaselineAlignment.Center);
			renderer.WriteStartMember(nameof(InlineUIContainer.Child));

			renderer.WriteStartObject(typeof(FormulaControl));
			renderer.WriteResourceMember(null, MarkdownXamlStyle.MathInlineFormula);
			renderer.WriteMember(FormulaControl.FormulaProperty, formula);
			renderer.WriteEndObject();

			renderer.WriteEndMember(); // </InlineUIContainer.Child>
			renderer.WriteEndObject(); // </InlineUIContainer>
		} // proc Write
	} // class MathInlineRenderer

	#endregion
}
