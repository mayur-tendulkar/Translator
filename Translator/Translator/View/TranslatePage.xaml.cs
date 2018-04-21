using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
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
            try
            {
                TranslatedText.Text = await TranslateService.TranslateText(OriginalText.Text, "fr");
                App.TranslateHistory.Add(new TranslateHistory() { OriginalText = OriginalText.Text, TranslatedText = TranslatedText.Text });
                HistoryService.SaveHistoryAsync(App.TranslateHistory);
                Analytics.TrackEvent("Translation Service",
                                   new Dictionary<string, string> { { username, OriginalText.Text } });
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string> { { username, ex.Message } });
                await DisplayAlert("Error!", ex.Message, "Cancel");
            }
            

        }

        private async void LogOffButtonClicked(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            await Navigation.PushAsync(new LoginPage());
        }
    }
}