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
            AppCenter.Start("android=38e0c132-122e-4b6d-95e6-91f4faf94a6b;" +
                               "uwp=0f9ed7a0-cdd2-4cc1-b9a9-ebbcd372050d;" +
                               "ios=11e3ed1c-a42a-4f36-b7d7-fdd9e4dde8f2",
                typeof(Analytics), typeof(Crashes));
            await Crashes.SetEnabledAsync(true);
            
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
