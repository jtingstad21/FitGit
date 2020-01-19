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
    public partial class SignUpPage : ContentPage
    {
        public FirebaseClient myfirebase = new FirebaseClient("https://fitgit-e60fb.firebaseio.com/");

        public SignUpPage()
        {
            InitializeComponent();
        }
        public void enter_clicked(object sender, EventArgs e)
        {
            // Connect to database, make sure username is not taken
        }
    }
}