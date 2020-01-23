using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using final_app_Firebase;
using System.Collections.Generic;

namespace final_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage   // Defines signup page behavior
    {
        FirebaseHelper helper = new FirebaseHelper();
        string Username = "";
        string Password = "";
        string DateOfBirth = "";
        double Weight = 0.0;

        public SignUpPage() // Constructor
        {
            InitializeComponent();
        }

        private async void enter_clicked(object sender, EventArgs e)    // Defines functionality for button click
        {
            Username = uname_line.Text;
            Password = pw_again.Text;
            DateOfBirth = date_pick.Date.ToShortDateString().ToString();
            bool Exists = await helper.UserExists(Username);
            if (!Exists)
            {
                if (double.TryParse(weight_line.Text, out double weightVal))
                {
                    Weight = weightVal;
                    if (pw_line.Text == pw_again.Text)
                    {
                        if (pw_line.Text.Length > 7)
                        {
                            await helper.AddUser(Password, Username, DateOfBirth, Weight);
                            await DisplayAlert("Success", "You have been successfully added.", "Ok");
                            uname_line.Text = string.Empty;
                            pw_line.Text = string.Empty;
                            pw_again.Text = string.Empty;
                            weight_line.Text = string.Empty;
                            DOB_label.Text = string.Empty;
                            await Navigation.PushAsync(new SearchBrowsePage(await helper.getUser(Username)));
                        }
                        else
                        {
                            await DisplayAlert("Failed", "Password must be at least 8 characters.", "Ok");
                            uname_line.Text = string.Empty;
                            pw_line.Text = string.Empty;
                            pw_again.Text = string.Empty;
                            weight_line.Text = string.Empty;
                            DOB_label.Text = string.Empty;
                        }
                    }
                    else
                    {
                        await DisplayAlert("Password Invalid", "The passwords entered do not match each other and or are less than 8 characters.", "Ok");
                        pw_line.Text = string.Empty;
                        pw_again.Text = string.Empty;
                    }
                }
                else
                {
                    await DisplayAlert("Must Correctly Fill All Fields", "You have inputed your weight incorrectly", "Ok");
                    pw_line.Text = string.Empty;
                    pw_again.Text = string.Empty;
                    weight_line.Text = string.Empty;                
                }
            }
            else
            {
                uname_line.Text = string.Empty;
                pw_line.Text = string.Empty;
                pw_again.Text = string.Empty;
                weight_line.Text = string.Empty;
                await DisplayAlert("User Name Already Exists", "The username entered already exists.", "Ok");
            }
        }
    }
}