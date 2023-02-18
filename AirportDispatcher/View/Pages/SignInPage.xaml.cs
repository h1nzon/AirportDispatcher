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
            // Заглушка на авторизацию.
            MessageBox.Show("Авторизация");
        }
    }
}
