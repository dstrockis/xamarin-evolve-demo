using System;

using Xamarin.Forms;
using Microsoft.Identity.Client;

namespace EvolveDemo
{
	public class LoginPage : ContentPage
	{
		Label displayName;
		Label token;
		Button copyBtn;

		public IPlatformParameters platformParameters { get; set; }

		public LoginPage ()
		{
			displayName = new Label ();
			token = new Label 
			{
				LineBreakMode = LineBreakMode.TailTruncation
			};
			var loginBtn = new Button {
				Text = "Log In",
			};
			var logoutBtn = new Button {
				Text = "Log Out",
			};
			var editProfileBtn = new Button {
				Text = "Edit Profile",
			};
			copyBtn = new Button {
				Text = "Copy Token",
				IsVisible = false,
			};

			loginBtn.Clicked += OnLoginClicked;
			logoutBtn.Clicked += OnLogoutClicked;
			editProfileBtn.Clicked += OnEditProfileClicked;
			copyBtn.Clicked += OnCopyClicked;

			Content = new StackLayout { 
				Padding = new Thickness(20),
				Children = {
					loginBtn,
					logoutBtn,
					editProfileBtn,
					displayName,
					token,
					copyBtn
				}
			};
		}

		private async void OnLoginClicked(object sender, EventArgs e) 
		{
			try {

				// Perform the OAuth request & get a token
				AuthenticationResult ar = await App.pca.AcquireTokenAsync (
					new string[] {"34a4ed61-4103-46b7-90ba-af373d5c2af9"}, "",   
					UiOptions.ForceLogin, null, null, 
					"https://login.microsoftonline.com/fabrikamb2c.onmicrosoft.com/", "b2c_1_susi");

				// Display the successful results
				displayName.Text = ar.User.Name;
				token.Text = ar.Token;
				copyBtn.IsVisible = true;

			}

			// Handle failed auth requests
			catch (MsalException ex) {
				token.Text = ex.Message;
				copyBtn.IsVisible = false;
			}
		}

		private void OnLogoutClicked(object sender, EventArgs e) 
		{
			App.pca.UserTokenCache.Clear ("34a4ed61-4103-46b7-90ba-af373d5c2af9");
			displayName.Text = string.Empty;
			token.Text = string.Empty;
			copyBtn.IsVisible = false;
		}

		private async void OnEditProfileClicked(object sender, EventArgs e) 
		{
			try {

				// Perform the OAuth request & get a token
				AuthenticationResult ar = await App.pca.AcquireTokenAsync (
					new string[] {"34a4ed61-4103-46b7-90ba-af373d5c2af9"}, "",   
					UiOptions.SelectAccount, null, null, 
					"https://login.microsoftonline.com/fabrikamb2c.onmicrosoft.com/", "b2c_1_edit_profile");

				// Display the successful results
				displayName.Text = ar.User.Name;
				token.Text = ar.Token;
				copyBtn.IsVisible = true;

			}

			// Handle failed auth requests
			catch (MsalException ex) {
				token.Text = ex.Message;
				copyBtn.IsVisible = false;
			}
		}

		protected override void OnAppearing ()
		{
			App.pca.PlatformParameters = platformParameters;
			base.OnAppearing ();
		}
		
		private void OnCopyClicked(object sender, EventArgs e)
		{
			DependencyService.Get<IClipBoard> ().SetClipBoardFromText (token.Text);
		}
	}

	// Used for copy from app
	public interface IClipBoard
	{
		void SetClipBoardFromText(string text);
	}
}


