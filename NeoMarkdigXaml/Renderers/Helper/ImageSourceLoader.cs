using System;
using System.Windows.Media;

namespace Neo.Markdig.Xaml.Renderers
{

	public sealed class ImageSourceLoader
	{
		public IExternalImageLoader BitmapSourceLoader { get; set; }
		public Uri Uri { get; set; }
		public int Width  {get; set; }
		public int Height { get; set; }

		public ImageSource Image {
			get {
				if (BitmapSourceLoader != null)
				{
					return BitmapSourceLoader.LoadBitmapImage(Uri, Width, Height);
				}
				return null;
			}
		}
	}
}
