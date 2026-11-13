using System;
using System.IO;
using System.Net;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Neo.Markdig.Xaml.Renderers
{
	public class ExternalImageLoaderDefault : IExternalImageLoader
	{
		/// <summary>
		/// Load bitmap image source and relese file.
		/// </summary>
		public ImageSource LoadBitmapImage(Uri uri, int width = 0, int height = 0)
		{
			if (uri == null || !uri.IsAbsoluteUri) return null;

			try
			{
				if (uri.IsFile)
				{
					// File is not held by this way
					using (var fs = new FileStream(uri.LocalPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
					{
						return Decode(fs, width, height);
					}
				}
				else if (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)
				{
					var request = WebRequest.Create(uri);
					request.Timeout = 15000;
					using (var response = request.GetResponse())
					using (var net = response.GetResponseStream())
					using (var ms = new MemoryStream())
					{
						net.CopyTo(ms);
						ms.Position = 0;
						return Decode(ms, width, height);
					}
				}
				else
				{
					// pack:// etc.
					return Decode(uri, width, height);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(uri + "\n" + ex);
				return null;
			}
		}

		private static ImageSource Decode(Stream stream, int width, int height)
		{
			var bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
			bitmapImage.StreamSource = stream;
			if (width > 0) bitmapImage.DecodePixelWidth = width;
			if (height > 0) bitmapImage.DecodePixelHeight = height;
			bitmapImage.EndInit();
			bitmapImage.Freeze();
			return bitmapImage;
		}

		private static ImageSource Decode(Uri uri, int width, int height)
		{
			var bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
			bitmapImage.UriSource = uri;
			if (width > 0) bitmapImage.DecodePixelWidth = width;
			if (height > 0) bitmapImage.DecodePixelHeight = height;
			bitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
			bitmapImage.EndInit();
			bitmapImage.Freeze();
			return bitmapImage;
		}
	}
}
