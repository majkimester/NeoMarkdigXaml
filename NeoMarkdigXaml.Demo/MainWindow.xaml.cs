using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows;
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

            this.DataContext = new DemoViewModel();
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

        private void OpenHyperlink(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Process.Start(e.Parameter.ToString());
        }

        private void ClickOnImage(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"URL: {e.Parameter}");
        }
    }
}
