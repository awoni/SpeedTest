using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace SpeedTest
{
	public class WebViewPage : ContentPage
	{
		const string header = @"
			<html><header>
			<style type='text/css'>  
			table{
				width:100%
			}
			h3{
				text-align:center
			}
			td{
				text-align:center
			}
			.red{
				color:#FF0000
			}
			.blue{
				color:#0000FF
			}
			</style> 
			</header><body>";

		readonly string[] WeekDay = {"日", "月", "火", "水", "木", "金", "土"};

		public WebViewPage ()
		{
			this.Title = "WebViewカレンダー";
			DateTime today = DateTime.Today;
			DateTime date = new DateTime (today.Year, today.Month, 1);

			StringBuilder html = new StringBuilder ();
			html.Append (header);

			for (int nn = 0; nn < 12; nn++) {
				html.Append ("<h3>" + date.Year + "年" + date.Month + "月" + "</h3>");

				html.Append ("<Table><tr>");
				for (int num = 0; num < 7; num++) {
					if(num == 0)
						html.Append ("<td class='red'>");
					else if(num == 6)
						html.Append ("<td class='blue'>");
					else
						html.Append ("<td>");
					html.Append (WeekDay [num] + "</td>");
				}

				html.Append ("</tr><tr>");
				int before = (int)date.DayOfWeek;
				for (int num = 0; num < before; num++) {
					html.Append ("<td></td>");
				}

				int days = DateTime.DaysInMonth (date.Year, date.Month);
				string monthid = date.Year.ToString ("0000") + date.Month.ToString ("00");
				for (int num = 1; num <= days; num++) {
					html.Append ("<td><span id='" + monthid + num.ToString("00") + "'");
					if((num + before) % 7 == 1)
						html.Append (" class='red'");
					else if((num + before) % 7 == 0)
						html.Append (" class='blue'");
					html.Append (">" + num + "</span></td>");
					if((num + before) % 7 == 0 && num != days)
						html.Append ("</tr><tr>");
				}			
				html.Append ("</tr>");
				html.Append ("</table>");

				date = date.AddMonths (1);
			}
			html.Append ("</body></html>");
			var browser = new WebView();
			var htmlSource = new HtmlWebViewSource ();
			htmlSource.Html = html.ToString(); 
			browser.Source = htmlSource;

			this.Content = browser;  
		}
	}
}

