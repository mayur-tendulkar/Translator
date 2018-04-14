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
		public TranslatePage ()
		{
			InitializeComponent ();
            WelcomeText.Text = $"Welcome, {App.Current.Properties["username"] as string}";
        }

        private async void TranslateButtonClicked(object sender, EventArgs e)
        {
            TranslatedText.Text = await TranslateService.TranslateText(OriginalText.Text, "hi");
            App.TranslateHistory.Add(new TranslateHistory() { OriginalText = OriginalText.Text, TranslatedText = TranslatedText.Text });
            HistoryService.SaveHistoryAsync(App.TranslateHistory);
        }
    }
}