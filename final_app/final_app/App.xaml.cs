using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final_app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            MainPage.BackgroundColor = Xamarin.Forms.Color.LightSlateGray;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
