using System.Windows;

namespace Neo.Markdig.Xaml
{
	public static class MarkdownAttached
	{
		/// <summary>Heading identifier</summary>
		public static readonly DependencyProperty IdProperty =
			DependencyProperty.RegisterAttached("Id", typeof(string), typeof(MarkdownAttached));
		public static string GetId(DependencyObject dep) => (string)dep.GetValue(IdProperty);
		public static void SetId(DependencyObject dep, string value) => dep.SetValue(IdProperty, value);

		/// <summary>Heading level (1-6)</summary>
		public static readonly DependencyProperty LevelProperty =
			DependencyProperty.RegisterAttached("Level", typeof(int), typeof(MarkdownAttached), new PropertyMetadata(0));
		public static int GetLevel(DependencyObject dep) => (int)dep.GetValue(LevelProperty);
		public static void SetLevel(DependencyObject dep, int value) => dep.SetValue(LevelProperty, value);

		/// <summary>Heading text</summary>
		public static readonly DependencyProperty HeaderProperty =
			DependencyProperty.RegisterAttached("Header", typeof(string), typeof(MarkdownAttached));
		public static string GetHeader(DependencyObject dep) => (string)dep.GetValue(HeaderProperty);
		public static void SetHeader(DependencyObject dep, string value) => dep.SetValue(HeaderProperty, value);
	}
}
