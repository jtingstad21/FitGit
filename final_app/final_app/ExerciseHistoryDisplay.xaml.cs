using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_app.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using final_app_Firebase;

namespace final_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseHistoryDisplay : ContentPage
    {
        FirebaseHelper helper = new FirebaseHelper();
        User CurrentUser = new User();
        public ExerciseHistoryDisplay(User CurrentUserval)
        {
            InitializeComponent();
            GetCurUser(CurrentUserval);
            foreach (Exercise ex in CurrentUser.ex_hist)
            {
                ContentView myContentView = new ContentView();
                StackLayout StackLayoutTop = new StackLayout();
                Label topLabel = new Label();

                StackLayout StackLayoutIntensity = new StackLayout();
                Label IntLabel1 = new Label();
                Label IntLabel2 = new Label();

                StackLayout StackLayoutCals = new StackLayout();
                Label CalLabel1 = new Label();
                Label CalLabel2 = new Label();

                StackLayout StackLayoutIntMins = new StackLayout();
                Label IntMinLabel1 = new Label();
                Label IntMinLabel2 = new Label();

                myContentView.BackgroundColor = Color.LightGray;
                StackLayoutIntensity.Orientation = StackOrientation.Horizontal;
                StackLayoutCals.Orientation = StackOrientation.Horizontal;
                StackLayoutIntMins.Orientation = StackOrientation.Horizontal;

                topLabel.Text = ex.Name;
                topLabel.FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label));
                topLabel.FontAttributes = FontAttributes.Bold;
                topLabel.HorizontalOptions = LayoutOptions.Center;

                IntLabel1.Text = "Intensity level: ";
                IntLabel1.Padding = new Thickness(5, 0, 0, 0);
                IntLabel1.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                IntLabel2.Text = ex.Intensity;
                IntLabel2.Padding = new Thickness(-5, 0, 0, 0);
                IntLabel2.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                CalLabel1.Text = "Calories burned: ";
                CalLabel1.Padding = new Thickness(5, 0, 0, 0);
                CalLabel1.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                CalLabel2.Text = ex.Calories(ex.MET, CurrentUser.Weight).ToString("0.00");
                CalLabel2.Padding = new Thickness(-5, 0, 0, 0);
                CalLabel2.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                IntMinLabel1.Text = "Intensity minutes gained: ";
                IntMinLabel1.Padding = new Thickness(5, 0, 0, 0);
                IntMinLabel1.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                IntMinLabel2.Text = ex.IntMins(0).ToString("0.00");
                IntMinLabel2.Padding = new Thickness(-5, 0, 0, 0);
                IntMinLabel2.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                StackLayoutIntensity.Children.Add(IntLabel1);
                StackLayoutIntensity.Children.Add(IntLabel2);

                StackLayoutCals.Children.Add(CalLabel1);
                StackLayoutCals.Children.Add(CalLabel2);

                StackLayoutIntMins.Children.Add(IntMinLabel1);
                StackLayoutIntMins.Children.Add(IntMinLabel2);

                StackLayoutTop.Children.Add(topLabel);
                StackLayoutTop.Children.Add(StackLayoutIntensity);
                StackLayoutTop.Children.Add(StackLayoutCals);
                StackLayoutTop.Children.Add(StackLayoutIntMins);

                myContentView.Content = StackLayoutTop;

                OverheadStacklayout.Children.Add(myContentView);
            }
            calcIntMins();
            calcCalTotal();
        }
        private async void GetCurUser(User user)
        {
            CurrentUser = await helper.getUser(user);
        }

        private async void calcIntMins()
        {
            CurrentUser = await helper.getUser(CurrentUser);
            double val = 0.0;
            foreach(Exercise ex in CurrentUser.ex_hist)
            {
                await DisplayAlert("Success", ex.intMinutes.ToString("0.00"), "Ok");
                val += ex.intMinutes;
            }
            TotINTMINS.Text = val.ToString("0.00");
        }


        private void calcCalTotal()
        {
            double val = 0.0;
            foreach (Exercise ex in CurrentUser.ex_hist)
            {
                val += ex.CaloriesVal;
            }
            TOtalCalVal.Text = val.ToString("0.00");
        }

        public async void ClearHistory(object sender, EventArgs e)
        {
            CurrentUser.ex_hist.Clear();
            OverheadStacklayout.Children.Clear();
            await helper.UpdateUser(CurrentUser.Password, CurrentUser.UserName, CurrentUser.DOB, CurrentUser.Weight, CurrentUser.ex_hist, CurrentUser.ex_list);
        }

        public async void DeleteAccount(object sender, EventArgs e)
        {
            await helper.DeleteUser(CurrentUser.UserName, CurrentUser.Password);
            await Navigation.PushAsync(new MainPage());
        }

        public async void Logout(object sender, EventArgs e)
        {
            CurrentUser = new User();
            await Navigation.PushAsync(new MainPage());
        }
    }
}