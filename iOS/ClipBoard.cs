using System;
using Xamarin.Forms;
using EvolveDemo.iOS;
using UIKit;
using Foundation;

[assembly: Dependency (typeof(ClipBoard))]
namespace EvolveDemo.iOS
{
	public class ClipBoard : IClipBoard
	{
		public void SetClipBoardFromText(string text)
		{
			UIPasteboard.General.SetValue(new NSString(text), MobileCoreServices.UTType.Text);
		}
	}
}

