using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.Helper;
using Translator.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Translator.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TranslatePage : ContentPage
	{
        string username;
		public TranslatePage ()
		{
			InitializeComponent ();
            username = App.Current.Properties["username"] as string;
            WelcomeText.Text = $"Welcome, {username}";
        }

        private async void TranslateButtonClicked(object sender, EventArgs e)
        {
            TranslatedText.Text = await TranslateService.TranslateText(OriginalText.Text, "hi");
            App.TranslateHistory.Add(new TranslateHistory() { OriginalText = OriginalText.Text, TranslatedText = TranslatedText.Text });
            HistoryService.SaveHistoryAsync(App.TranslateHistory);
            Analytics.TrackEvent("Translation Service",
                               new Dictionary<string, string> { { username, OriginalText.Text } });

        }

        private async void LogOffButtonClicked(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            await Navigation.PushAsync(new LoginPage());
        }
    }
}