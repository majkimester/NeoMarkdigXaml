using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;

using Neo.Markdig.Xaml;

namespace NeoMarkdigXaml.Demo
{
    class FlowDocumentToBookmarksValueConverter : DependencyObject, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is FlowDocument document)
            {
                return MarkdownNavigation.GetBookmarks(document);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}