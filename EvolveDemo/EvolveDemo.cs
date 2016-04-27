using System;

using Xamarin.Forms;
using Microsoft.Identity.Client;

namespace EvolveDemo
{
	public class App : Application
	{
		public static PublicClientApplication pca { get; set; }

		public App ()
		{
			pca = new PublicClientApplication ("34a4ed61-4103-46b7-90ba-af373d5c2af9");

			// The root page of your application
			MainPage = new LoginPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

