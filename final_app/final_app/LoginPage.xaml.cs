using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Firebase.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace final_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public FirebaseClient myfirebase = new FirebaseClient("https://fitgit-e60fb.firebaseio.com/");

        public LoginPage()
        {
            InitializeComponent();
        }
        public void btn_clicked(object sender, EventArgs e)
        {
            // Connect to database and validate user credentials
            myfirebase 


        }
    }
}