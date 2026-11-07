using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NeoMarkdigXaml.Demo
{
    class DemoViewModel : INotifyPropertyChanged
    {

        #region Properties

        /// <summary>
        /// Auto preview markdown when TRUE.
        /// </summary>
        public bool IsLive
        {
            get { return isLive; }
            set { SetField(ref isLive, value); }
        }
        private bool isLive = true;

        /// <summary>
        /// Text for the editor.
        /// </summary>
        public string TextMarkdown
        {
            get { return textMarkdown; }
            set
            {
                SetField(ref textMarkdown, value);
                if (IsLive) TextPreview = textMarkdown;
            }
        }
        private string textMarkdown = "";

        /// <summary>
        /// Text to preview.
        /// </summary>
        public string TextPreview
        {
            get { return textPreview; }
            set { SetField(ref textPreview, value); }
        }
        private string textPreview = "";

        /// <summary>
        /// Image base dir.
        /// </summary>
        public string ImageBaseDir
        {
            get { return imageBaseDir; }
            set { SetField(ref imageBaseDir, value); }
        }
        private string imageBaseDir = "";

        #endregion Properties

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion PropertyChanged
    }
}
