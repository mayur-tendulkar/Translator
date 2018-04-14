using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Translator.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}
        private async void RegisterButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameEntry.Text))
                return;
            App.Current.Properties["username"] = UsernameEntry.Text;
            await App.Current.SavePropertiesAsync();
            Analytics.TrackEvent("User Registration",
                                new Dictionary<string, string> { { "Username", UsernameEntry.Text } });
            await Navigation.PushAsync(new HomePage());
        }
    }
}