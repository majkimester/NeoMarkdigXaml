using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using Markdig;
using Neo.Markdig.Xaml;
using Neo.Markdig.Xaml.Renderers;

namespace NeoMarkdigXaml.Demo
{
    class TextToFlowDocumentMultiValueConverter : DependencyObject, IMultiValueConverter
    {
        // Reuse the pipeline instance to prevent rebuilding it on every keystroke/change
        private static readonly MarkdownPipeline TaskListPipeline = new MarkdownPipelineBuilder()
            .UseXamlSupportedExtensions()
            .Build();

        private static readonly IExternalImageLoader BitmapSourceLoader = new ExternalImageLoaderDefault();

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="values">Values produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0 || !(values[0] is string text))
            {
                return null;
            }

            Uri baseUri = null;

            if (values.Length > 1 && values[1] != null && values[1] != DependencyProperty.UnsetValue)
            {
                if (values[1] is Uri uri)
                {
                    baseUri = uri;
                }
                else if (values[1] is string path && !string.IsNullOrWhiteSpace(path))
                {
                    if (Directory.Exists(path) && !path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    {
                        path += Path.DirectorySeparatorChar;
                    }
                    Uri.TryCreate(path, UriKind.Absolute, out baseUri);
                }
            }

            // Fallback to the application's base directory if no second binding is supplied
            if (baseUri == null)
            {
                baseUri = new Uri(AppDomain.CurrentDomain.BaseDirectory, UriKind.Absolute);
            }

            return MarkdownXaml.ToFlowDocument(text, TaskListPipeline, baseUri, BitmapSourceLoader);
        }

        /// <summary>
        /// Converts a value. 
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetTypes">The types to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}