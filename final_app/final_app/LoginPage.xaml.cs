using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using final_app_Firebase;

namespace final_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage    // Defines login page behavior
    {
        FirebaseHelper helper = new FirebaseHelper();
        string UserName = "";
        string Password = "";
        public LoginPage()  // Constructor
        {
            InitializeComponent();
        }
        public async void btn_clicked(object sender, EventArgs e)   // Defines behavior on button click
        {
            UserName = uname_line.Text;
            Password = pw_line.Text;
            if((await helper.isCorrectpWUn(UserName, Password)))
            {
                
                await Navigation.PushAsync(new SearchBrowsePage(await helper.getUser(UserName)));
                await DisplayAlert("Welcome Back", "Welcome Back to FitGit " + UserName + "!\nAll of your previous data has been reloaded.", "Continue");
            }
            else
            {
                uname_line.Text = string.Empty;
                pw_line.Text = string.Empty;
                await DisplayAlert("Incorrect Username or Password", "You have entered either an invalid username or invalid password for the username.", "Ok");
            }
           
        }
    }
}