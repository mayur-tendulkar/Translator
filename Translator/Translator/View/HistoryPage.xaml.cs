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
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                HistoryListView.ItemsSource = App.TranslateHistory;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error:", ex.Message, "Cancel");
            }
        }
    }
}