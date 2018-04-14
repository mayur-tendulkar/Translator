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
            AppCenter.Start("android=117db4ea-2d5e-4934-8e3a-0eb80da6ceaf;" +
                               "uwp=2fcc3ede-d9b5-409f-afb5-93c3294b00b7;" +
                               "ios=da424c94-d41d-40c0-bb35-354c09cb2c28",
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
