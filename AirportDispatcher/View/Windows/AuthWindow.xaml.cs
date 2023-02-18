using AirportDispatcher.View.Pages;
using System.Windows;
using System.Windows.Media;

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

        #region Button Events

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            AuthFrame.Navigate(new SignInPage());
        }

        private void RegButton_Click(object sender, System.EventArgs e)
        {
            AuthFrame.Navigate(new SignUpPage());
        }

        #endregion

        #region Application Events

        private void ApplicationBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ApplicationClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
