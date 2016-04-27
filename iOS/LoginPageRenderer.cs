using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using EvolveDemo;
using EvolveDemo.iOS;
using Microsoft.Identity.Client;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace EvolveDemo.iOS
{
	public class LoginPageRenderer : PageRenderer
	{
		LoginPage page;
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);
			page = e.NewElement as LoginPage;
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			page.platformParameters = new PlatformParameters(this);
		}
	}
}

