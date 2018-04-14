using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using Translator.Helper;
using Translator.Model;
using Translator.View;
using Xamarin.Forms;

namespace Translator
{
    public partial class App : Application
	{
        public static List<TranslateHistory> TranslateHistory { get; set; }
        public App ()
		{
			InitializeComponent();

            if (App.Current.Properties.ContainsKey("username"))
                MainPage = new NavigationPage(new HomePage());
            else
                MainPage = new NavigationPage(new LoginPage());
        }

		protected override async void OnStart ()
		{
            TranslateHistory = await HistoryService.ReadHistoryAsync();
            AppCenter.Start("{platform-specific-code}",
                typeof(Analytics), typeof(Crashes));
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
