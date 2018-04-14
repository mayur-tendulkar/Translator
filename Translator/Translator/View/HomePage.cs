using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Translator.View
{
    public class HomePage : TabbedPage
    {

        public HomePage()
        {
            this.Children.Add(new TranslatePage());
            this.Children.Add(new HistoryPage());
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var prevPage = Navigation.NavigationStack[0];
            if (prevPage.Title == "Register")
            {
                Navigation.RemovePage(prevPage);
            }

        }
    }
}
