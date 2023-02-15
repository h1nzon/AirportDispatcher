﻿using AirportDispatcher.View.Pages;
using System.Windows;

namespace AirportDispatcher.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            AuthFrame.Navigate(new SignInPage());
        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            AuthFrame.Navigate(new SignInPage());
            LoginButton.VisibilityLine = Visibility.Visible;
            RegButton.VisibilityLine = Visibility.Hidden;
        }

        private void RegButton_Click(object sender, System.EventArgs e)
        {
            AuthFrame.Navigate(new SignUpPage());
            RegButton.VisibilityLine = Visibility.Visible;
            LoginButton.VisibilityLine = Visibility.Hidden;
        }
    }
}