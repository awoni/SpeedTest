using System;
using Xamarin.Forms;

namespace SpeedTest
{
	public class SpeedTestPage : ContentPage
	{
		public SpeedTestPage ()
		{
			this.Title = "XFスピードテスト";

			Button gridButton = new Button{
				Text = "Gridカレンダー"
			};
			gridButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new GridAndLabel(12));
			};

			Button grid3Button = new Button{
				Text = "Gridカレンダー3ヶ月"
			};
			grid3Button.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new GridAndLabel(3));
			};


			Button webviewButton = new Button{
				Text = "WebViewカレンダー"
			};
			webviewButton.Clicked += async (object sender, EventArgs e) => {
				await Navigation.PushAsync(new WebViewPage());
			};


			this.Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				Children = {
					gridButton,
					grid3Button,
					webviewButton,
				}
			};
		}
	}
}

