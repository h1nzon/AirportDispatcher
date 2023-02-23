using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirportDispatcher.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        private bool _isUpper = false;

        public SignUpPage()
        {
            InitializeComponent();
        }

        private void PasswordTextBox_TextChange(object sender, RoutedEventArgs e)
        {
            var password = PasswordTextBox.Password;
            if (password != null)
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (char.IsUpper(password[i]))
                        _isUpper = true;
                    else
                        _isUpper = false;
                }
            }
            if (PasswordTextBox.Password.Length > 6)
            {
                PasswordProgress.Value += 10;
            }
            
        }
    }
}
