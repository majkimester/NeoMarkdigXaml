using System;
using System.Windows.Media;

namespace Neo.Markdig.Xaml.Renderers
{
	public interface IExternalImageLoader
	{
		ImageSource LoadBitmapImage(Uri uri, int width = 0, int height = 0);
	}
}
