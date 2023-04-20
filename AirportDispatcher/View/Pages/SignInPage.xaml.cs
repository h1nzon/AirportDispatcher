using AirportDispatcher.Classes;
using AirportDispatcher.Properties;
using AirportDispatcher.View.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AirportDispatcher.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, System.EventArgs e)
        {
            if(AuthenticationClass.AuthenticateUser(LoginUser.Text, UserPassword.Password))
            {
                Properties.Settings.Default.isLogin = true;
                MainWindow mainWindow = new MainWindow();
                Window parentWindow = Window.GetWindow(this);
                mainWindow.Show();
                parentWindow.Close();
            }
            else
            {
                MessageBox.Show("Не удалось :(");
            }
        }
    }
}
