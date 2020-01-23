using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using final_app.Models;
using final_app_Firebase;

namespace final_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBrowsePage : ContentPage // Contains exercise info and displays it
    {
        FirebaseHelper helper = new FirebaseHelper();
        User CurrentUser = new User();
        List<Exercise> holder = new List<Exercise>();
        public SearchBrowsePage(User CurUserName)
        {
            helperFunc(CurUserName);
            InitializeComponent();
        }

        public async void helperFunc(User user) // Allows you to call thread inside constructor
        {
            CurrentUser = await helper.getUser(user);
            if (CurrentUser.ex_hist.Count > 0)
            {
                holder = CurrentUser.ex_hist;
            }
            for (int i = 0; i < CurrentUser.ex_list.Count; i++)
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

                topLabel.Text = CurrentUser.ex_list[i].Name;
                topLabel.FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label));
                topLabel.FontAttributes = FontAttributes.Bold;
                topLabel.HorizontalOptions = LayoutOptions.Center;

                IntLabel1.Text = "Intensity level: ";
                IntLabel1.Padding = new Thickness(5, 0, 0, 0);
                IntLabel1.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                IntLabel2.Text = CurrentUser.ex_list[i].Intensity;
                IntLabel2.Padding = new Thickness(-5, 0, 0, 0);
                IntLabel2.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                CalLabel1.Text = "Calories burned: ";
                CalLabel1.Padding = new Thickness(5, 0, 0, 0);
                CalLabel1.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                CalLabel2.Text = CurrentUser.ex_list[i].Calories(CurrentUser.ex_list[i].MET, CurrentUser.Weight).ToString("0.00");
                CalLabel2.Padding = new Thickness(-5, 0, 0, 0);
                CalLabel2.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                IntMinLabel1.Text = "Intensity minutes: ";
                IntMinLabel1.Padding = new Thickness(5, 0, 0, 0);
                IntMinLabel1.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                IntMinLabel2.Text = CurrentUser.ex_list[i].IntMins(0).ToString("0.00");
                IntMinLabel2.Padding = new Thickness(-5, 0, 0, 0);
                IntMinLabel2.FontSize = Device.GetNamedSize(NamedSize.Body, typeof(Label));

                addEx.Text = "Add to exercise list";
                addEx.TextColor = Color.Linen;
                addEx.Clicked += AddCalories;
                addEx.BackgroundColor = Color.MidnightBlue;
                addEx.VerticalOptions = LayoutOptions.End;
                addEx.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                addEx.CommandParameter = CurrentUser.ex_list[i];

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
                
                OverheadStacklayoutm.Children.Add(myContentView);
            }
            fakeBTNClikEVnt(CurrentUser.ex_list[0].Intensity);
        }

        private async void fakeBTNClikEVnt(string val)  // Necessary for auto population of data
        {
            CurrentUser = await helper.getUser(CurrentUser);
            foreach (ContentView CV in OverheadStacklayoutm.Children)
            {
                StackLayout slOne = CV.Content as StackLayout;
                StackLayout IntensityLayout = slOne.Children[1] as StackLayout;
                Label IntensityValue = IntensityLayout.Children[1] as Label;
                IntensityValue.Text = val;
            }

            foreach (Exercise ex in CurrentUser.ex_list)
            {
                ex.Intensity = val;
                ex.CaloriesVal = ex.Calories(ex.ExerciseTime, CurrentUser.Weight);
            }

            setIntensityMinutes();
            setCalories();
            await helper.UpdateUser(CurrentUser.Password, CurrentUser.UserName, CurrentUser.DOB, CurrentUser.Weight, CurrentUser.ex_hist, CurrentUser.ex_list);
        }

        public async void MinutesChanged(object sender, TextChangedEventArgs e) // Gets number of minutes from user entry line
        {
            CurrentUser = await helper.getUser(CurrentUser);
            string newMin = e.NewTextValue;
            if(double.TryParse(newMin, out double newtime))
            {
                for(int i = 0; i < CurrentUser.ex_list.Count; i++)
                {
                    CurrentUser.ex_list[i].ExerciseTime = newtime;
                }
                setCalories();
                setIntensityMinutes();
            }
            else if(newMin != string.Empty)
            {
                await DisplayAlert("Integers Only", "Integers can only be placed in this field!", "Ok");
                ExerciseTime.Text = string.Empty;
            }

            await helper.UpdateUser(CurrentUser.Password, CurrentUser.UserName, CurrentUser.DOB, CurrentUser.Weight, CurrentUser.ex_hist, CurrentUser.ex_list);
        }

        public void setCalories()   // Changes the number of calories outputted on the screen under each exercise
        {
            int i = 0;
            foreach (ContentView CV in OverheadStacklayoutm.Children)
            {
                StackLayout slOne = CV.Content as StackLayout;
                StackLayout calLayout = slOne.Children[2] as StackLayout;
                Label CalValue = calLayout.Children[1] as Label;
                CalValue.Text = CurrentUser.ex_list[i].Calories(CurrentUser.ex_list[i].ExerciseTime, CurrentUser.Weight).ToString("0.00");
                i++;
            }
        }

        public void setIntensityMinutes()   // Changes intensity minutes based on user entry
        {
            int i = 0;
            foreach (ContentView CV in OverheadStacklayoutm.Children)
            {
                StackLayout slOne = CV.Content as StackLayout;
                StackLayout calLayout = slOne.Children[3] as StackLayout;
                Label CalValue = calLayout.Children[1] as Label;
                CalValue.Text = CurrentUser.ex_list[i].IntMins(CurrentUser.ex_list[i].ExerciseTime).ToString("0.00");
                i++;
            }
        }

        public async void AddCalories(object sender, EventArgs e)   // Adds calories to bottom total calories bar
        {

            var button = sender as Button;
            double.TryParse(TotalCal.Text, out double numBurnt);
            Exercise exe = button.CommandParameter as Exercise;
            double.TryParse(ExerciseTime.Text, out double time);
            numBurnt += exe.Calories(time, CurrentUser.Weight);
            TotalCal.Text = numBurnt.ToString("0.00");
            holder.Add(CurrentUser.ex_list.Find(x => x.Name == exe.Name));
            await helper.UpdateUser(CurrentUser.Password, CurrentUser.UserName, CurrentUser.DOB, CurrentUser.Weight, holder, CurrentUser.ex_list);
            CurrentUser.ex_hist = (await helper.getUser(CurrentUser.UserName)).ex_hist;
            await helper.UpdateUser(CurrentUser.Password, CurrentUser.UserName, CurrentUser.DOB, CurrentUser.Weight, CurrentUser.ex_hist, CurrentUser.ex_list);
        }

        public async void setIntensityLvl(object sender, EventArgs e)   // Allows user to pick high, medium, or low intensity buttons
        {
            CurrentUser = await helper.getUser(CurrentUser);
            var button = sender as Button;
            foreach (ContentView CV in OverheadStacklayoutm.Children)
            {
                StackLayout slOne = CV.Content as StackLayout;
                StackLayout IntensityLayout = slOne.Children[1] as StackLayout;
                Label IntensityValue = IntensityLayout.Children[1] as Label;
                IntensityValue.Text = button.CommandParameter.ToString();
            }

            foreach (Exercise ex in CurrentUser.ex_list)
            {
                ex.Intensity = button.CommandParameter.ToString();
                ex.CaloriesVal = ex.Calories(ex.ExerciseTime, CurrentUser.Weight);
            }

            setIntensityMinutes();
            setCalories();
            await helper.UpdateUser(CurrentUser.Password, CurrentUser.UserName, CurrentUser.DOB, CurrentUser.Weight, CurrentUser.ex_hist, CurrentUser.ex_list);
        }

        public async void ExerciseHistoryPage(object sender, EventArgs e)   // Navigates to exercies history page
        {
            await Navigation.PushAsync(new ExerciseHistoryDisplay(CurrentUser));
        }

        public async void DeleteAccount(object sender, EventArgs e) // Deletes user account
        {
            await helper.DeleteUser(CurrentUser.UserName, CurrentUser.Password);
            await Navigation.PushAsync(new MainPage());
        }

        public async void Logout(object sender, EventArgs e)    // Logs out user
        {
            CurrentUser = new User();
            await Navigation.PushAsync(new MainPage());
        }

        public void SearchTextChanged(object sender, TextChangedEventArgs e)    // Updates the search results to the screen based on user input
        {
            OverheadStacklayoutm.Children.Clear();

            foreach (Exercise ex in CurrentUser.ex_list)
            {

                string name = ex.Name.ToLower();
                if (name.Contains(e.NewTextValue.ToLower() ))
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
                    addEx.TextColor = Color.Linen;
                    addEx.Clicked += AddCalories;
                    addEx.BackgroundColor = Color.MidnightBlue;
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

                    OverheadStacklayoutm.Children.Add(myContentView);
                }
            }
        }
    }
}