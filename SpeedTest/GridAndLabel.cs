using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SpeedTest
{
	public class GridAndLabel : ContentPage
	{
		Label displayLabel;
		readonly string[] WeekDay = {"日", "月", "火", "水", "木", "金", "土"};
		public GridAndLabel (int months)
		{
			this.Title = "Grid カレンダー";
			DateTime today = DateTime.Today;
			DateTime date = new DateTime (today.Year, today.Month, 1);

			StackLayout callendarLayout = new StackLayout {
				Spacing = 0,
				Orientation = StackOrientation.Vertical,
			};

			for (int nn = 0; nn < months; nn++) {
				Grid grid = new Grid {
					VerticalOptions = LayoutOptions.Start,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					ColumnSpacing = 0,
					RowSpacing = 5,
					ColumnDefinitions = {
						new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
						new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
						new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
						new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
						new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
						new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
						new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					},
					RowDefinitions = 
					{
						new RowDefinition { Height = GridLength.Auto },
					}
				};

				for (int num = 0; num < 7; num++) {
					Color color;
					if(num == 0)
						color = Color.Red;
					else if(num == 6)
						color = Color.Blue;
					else
						color = Color.Default;

					displayLabel = new Label {
						Text = WeekDay [num],
						XAlign = TextAlignment.Center,
						TextColor = color,
					};

					grid.Children.Add (displayLabel, num, 0);
				}

				int before = (int)date.DayOfWeek;

				int days = DateTime.DaysInMonth (date.Year, date.Month);
				for (int num = 1; num <= days; num++) {
					Label label = new Label {
						Text = num.ToString (),
						XAlign = TextAlignment.Center,
						YAlign = TextAlignment.Center,
					};
					grid.Children.Add (label, (num - 1 + before) % 7, (num - 1 + before) / 7 + 1);
				}

				callendarLayout.Children.Add (new Label{
					Text = date.Year + "年" + date.Month + "月",
					HorizontalOptions = LayoutOptions.Center,
					FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label))
				});
				callendarLayout.Children.Add (grid);
				date = date.AddMonths (1);
			}

			this.Content = new ScrollView {
				Content = callendarLayout 
			};
		}
	}
}

