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
        public ExerciseHistoryDisplay(User CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
            foreach (Exercise ex in this.CurrentUser.ex_hist)
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



        }
    }
}