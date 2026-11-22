using Neo.Markdig.Xaml;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NeoMarkdigXaml.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(NavigationCommands.GoToPage, (sender, e) => Process.Start((string)e.Parameter)));

            this.DataContext = new DemoViewModel
            {
                ImageBaseDir = AppDomain.CurrentDomain.BaseDirectory
            };
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            demoSource.Text = LoadSample();
        }

        private string LoadSample()
        {
            var subjectType = GetType();
            var subjectAssembly = subjectType.Assembly;
            using (Stream stream = subjectAssembly.GetManifestResourceStream(subjectType.FullName + ".md"))
            {
                if (stream is null)
                {
                    return string.Format(
                        CultureInfo.InvariantCulture,
                        "Could not find sample text *{0}*.md", 
                        subjectType.FullName);
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Manual preview markdown.
        /// </summary>
        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            ((DemoViewModel)this.DataContext).TextPreview = ((DemoViewModel)this.DataContext).TextMarkdown;
        }

        private void OpenHyperlink(object sender, ExecutedRoutedEventArgs e)
        {
            if (MarkdownNavigation.TryNavigateInternal(e.OriginalSource ?? sender, e.Parameter))
            {
                return;
            }

            Process.Start(e.Parameter.ToString());
        }

        private void ClickOnImage(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"URL: {e.Parameter}");
        }

        private void BookmarkTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (sender is TreeView treeView && treeView.SelectedItem is MarkdownBookmark bookmark)
            {
                MarkdownNavigation.TryNavigateInternal(TocDemoFlowDocunentViewer, "#" + bookmark.Id);
            }
        }
    }
}
