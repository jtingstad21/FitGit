﻿using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace final_app
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }
        async void login_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        async void sign_up_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
