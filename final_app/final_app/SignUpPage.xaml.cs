using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using final_app_Firebase;

namespace final_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        FirebaseHelper helper = new FirebaseHelper();
        string Username = "";
        string Password = "";
        string DateOfBirth = "";
        double Weight = 0.0;
        public SignUpPage()
        {
            InitializeComponent();            
        }

        private async void enter_clicked(object sender, EventArgs e)
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
                        //deal with exercise list
                        await helper.AddUser(Password, Username, DateOfBirth, Weight);
                        uname_line.Text = string.Empty;
                        pw_line.Text = string.Empty;
                        pw_again.Text = string.Empty;
                        weight_line.Text = string.Empty;
                        DOB_label.Text = string.Empty;
                        await DisplayAlert("Success", "You have been successfully added.", "Ok");
                        await Navigation.PushAsync(new SearchBrowsePage());
                    }
                    else
                    {
                        await DisplayAlert("Passwords Do Not Match", "The passwords entered do not match each other.", "Ok");
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