using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using final_app.Models;
using final_app_Firebase;

namespace final_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBrowsePage : ContentPage
    {
        FirebaseHelper helper = new FirebaseHelper();
        User CurrentUser = new User();
        public SearchBrowsePage(User CurUserName)
        {
            InitializeComponent();
            CurrentUser = CurUserName;
            foreach (Exercise ex in CurrentUser.ex_list)
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

                Button addEx = new Button();

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

                IntMinLabel1.Text = "Intensity minutes: ";
                IntMinLabel1.Padding = new Thickness(5, 0, 0, 0);
                IntMinLabel1.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                IntMinLabel2.Text = ex.IntMins(0).ToString("0.00");
                IntMinLabel2.Padding = new Thickness(-5, 0, 0, 0);
                IntMinLabel2.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                addEx.Text = "Add to exercise list";
                addEx.Clicked += AddCalories;
                addEx.BackgroundColor = Color.Green;
                addEx.VerticalOptions = LayoutOptions.End;
                addEx.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                addEx.CommandParameter = ex;

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
                StackLayoutTop.Children.Add(addEx);

                myContentView.Content = StackLayoutTop;

                OverheadStacklayout.Children.Add(myContentView);
            }
        }

        public async void MinutesChanged(object sender, TextChangedEventArgs e)
        {
            string newMin = e.NewTextValue;
            if(double.TryParse(newMin, out double newtime))
            {
                foreach (Exercise ex in CurrentUser.ex_list)
                {
                    ex.ExerciseTime = newtime;
                }
                setCalories();
                setIntensityMinutes();
            }
            else if(newMin != string.Empty)
            {
                await DisplayAlert("Integers Only", "Integers can only be placed in this field!", "Ok");
                ExerciseTime.Text = string.Empty;
            }   
        }

        public void setCalories()
        {
            int i = 0;
            foreach (ContentView CV in OverheadStacklayout.Children)
            {
                StackLayout slOne = CV.Content as StackLayout;
                StackLayout calLayout = slOne.Children[2] as StackLayout;
                Label CalValue = calLayout.Children[1] as Label;
                CalValue.Text = CurrentUser.ex_list[i].Calories(CurrentUser.ex_list[i].ExerciseTime, CurrentUser.Weight).ToString("0.00");
                i++;
            }
        }

        public void setIntensityMinutes()
        {
            int i = 0;
            foreach (ContentView CV in OverheadStacklayout.Children)
            {
                StackLayout slOne = CV.Content as StackLayout;
                StackLayout calLayout = slOne.Children[3] as StackLayout;
                Label CalValue = calLayout.Children[1] as Label;
                CalValue.Text = CurrentUser.ex_list[i].IntMins(CurrentUser.ex_list[i].ExerciseTime).ToString("0.00");
                i++;
            }
        }

        public async void ExerciseHistoryPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExerciseHistoryDisplay(CurrentUser));
        }

        public void AddCalories(object sender, EventArgs e)
        {
            var button = sender as Button;
            double.TryParse(TotalCal.Text, out double numBurnt);
            CurrentUser.ex_list.IndexOf(button.CommandParameter as Exercise);
            Exercise exe = button.CommandParameter as Exercise;
            double.TryParse(ExerciseTime.Text, out double time);
            numBurnt += exe.Calories(time, CurrentUser.Weight);
            TotalCal.Text = numBurnt.ToString("0.00");
            CurrentUser.ex_hist.Add(exe);
        }

        

        public void setIntensityLvl(object sender, EventArgs e)
        {
            var button = sender as Button;

            foreach (ContentView CV in OverheadStacklayout.Children)
            {    
                StackLayout slOne = CV.Content as StackLayout;
                StackLayout IntensityLayout = slOne.Children[1] as StackLayout;
                Label IntensityValue = IntensityLayout.Children[1] as Label;
                IntensityValue.Text = button.CommandParameter.ToString();
            }

            foreach(Exercise ex in CurrentUser.ex_list)
            {
                ex.Intensity = button.CommandParameter.ToString();
                double.TryParse(ExerciseTime.Text, out double time);
                ex.CaloriesVal = ex.Calories(time, CurrentUser.Weight);
            }

            setIntensityMinutes();
            setCalories();
        }
    }
}