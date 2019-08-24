﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using XamForms.Controls;

namespace CalendarDemo
{
	public class App : Application
    {
		Calendar calendar;
		CalendarVM _vm;

		public App()
        {
			calendar = new Calendar
			{
				MaxDate = DateTime.Now.AddDays(30),
				MinDate = DateTime.Now.AddDays(-1),
				//DisableDatesLimitToMaxMinRange = true,
				MultiSelectDates = false,
				DisableAllDates = false,
				WeekdaysShow = true,
				ShowNumberOfWeek = true,
                //BorderWidth = 1,
                //BorderColor = Color.Transparent,
                //OuterBorderWidth = 0,
                //SelectedBorderWidth = 1,
				ShowNumOfMonths = 1,
				EnableTitleMonthYearView = true,
				WeekdaysTextColor = Color.Teal,
				StartDay = DayOfWeek.Monday,
				SelectedTextColor = Color.Fuchsia,
				SpecialDates = new List<SpecialDate>{
					new SpecialDate(DateTime.Now.AddDays(2)) { BackgroundColor = Color.Green, TextColor = Color.Accent, BorderColor = Color.Lime, BorderWidth=8, Selectable = true },
					new SpecialDate(DateTime.Now.AddDays(3))
					{
						BackgroundColor = Color.Green,
						TextColor = Color.Blue,
						Selectable = true,
						BackgroundPattern = new BackgroundPattern(1)
						{
							Pattern = new List<Pattern>
							{
								new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Red},
								new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Purple},
								new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Green},
								new Pattern{ WidthPercent = 1f, HightPercent = 0.25f, Color = Color.Yellow,Text = "Test", TextColor=Color.DarkBlue, TextSize=11, TextAlign=TextAlign.Middle}
							}
						}
					},
					new SpecialDate(DateTime.Now.AddDays(4))
					{
						Selectable = true,
						BackgroundImage = ImageSource.FromFile("icon.png") as FileImageSource
					}
				}
			};
			/*
			var white_row = new Pattern { WidthPercent = 1f, HightPercent = 0.04f, Color = Color.Transparent };
			var white_col = new Pattern { WidthPercent = 0.04f, HightPercent = 1f, Color = Color.Transparent };


			calendar.SpecialDates = new List<SpecialDate>{
					new SpecialDate(DateTime.Now.AddDays(3))
					{
						BackgroundColor = Color.White,
						TextColor = Color.Black,
						Selectable = true,
						BackgroundPattern = new BackgroundPattern(7)
					{
						Pattern = new List<Pattern>
							{
							new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Red, Text = "X", TextColor=Color.White, TextSize=11, TextAlign=TextAlign.Middle},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Gold, Text = "Y", TextColor=Color.White, TextSize=11, TextAlign=TextAlign.Middle},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Green, Text = "Z", TextColor=Color.White, TextSize=11, TextAlign=TextAlign.Middle},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Purple,Text = "Q", TextColor=Color.White, TextSize=11, TextAlign=TextAlign.Middle},

								white_row,white_row,white_row,white_row,white_row,white_row,white_row,

								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Blue},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Chocolate},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Cyan},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Fuchsia},

								white_row,white_row,white_row,white_row,white_row,white_row,white_row,

								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Crimson},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Aquamarine},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.OrangeRed},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.DarkOrchid},

								white_row,white_row,white_row,white_row,white_row,white_row,white_row,

								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Black},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.DeepSkyBlue},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.DarkGoldenrod},
								white_col,
								new Pattern{ WidthPercent = 0.22f, HightPercent = 0.22f, Color = Color.Firebrick},
							}
						}
					}
			};*/
					
			calendar.DateClicked += (sender, e) => {
				System.Diagnostics.Debug.WriteLine( calendar.SelectedDates);
			};
			_vm = new CalendarVM();
			var c2 = new CalendarXamlView();
			//calendar.SetBinding(Calendar.DateCommandProperty, nameof(_vm.DateChosen));
			//calendar.SetBinding(Calendar.SpecialDatesProperty, nameof(_vm.Attendances));
			c2.BindingContext = _vm;

            // The root page of your application
            MainPage = new ContentPage
            {
				BackgroundColor= Color.White,
				Content = new ScrollView {
					Content = new StackLayout {
						Padding = new Thickness(5, Device.RuntimePlatform == Device.iOS ? 25 : 5, 5, 5),
							Children = {
							calendar//,c2
						}
					}
                }
            };
		}

        protected override void OnStart()
        {
			// Handle when your app starts
			//calendar.SpecialDates.Add(new SpecialDate(DateTime.Now.AddDays(5)) { BackgroundColor = Color.Fuchsia, TextColor = Color.Accent, BorderColor = Color.Maroon, BorderWidth = 8 });
			//calendar.SpecialDates.Add(new SpecialDate(DateTime.Now.AddDays(6)) { BackgroundColor = Color.Fuchsia, TextColor = Color.Accent, BorderColor = Color.Maroon, BorderWidth = 8 });
			//calendar.RaiseSpecialDatesChanged();

			var dates = new List<SpecialDate>();

			var specialDate = new SpecialDate(new DateTime(2017, 04, 26));
			specialDate.BackgroundColor = Color.Green;
			specialDate.TextColor = Color.White;

			dates.Add(specialDate);

			_vm.Attendances = new ObservableCollection<SpecialDate>(dates);
			calendar.SelectedDate = (DateTime.Now);

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Ob resumes
        }
    }
}
