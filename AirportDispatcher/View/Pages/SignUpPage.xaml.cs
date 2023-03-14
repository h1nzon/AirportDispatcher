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
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void PasswordTextBox_TextChange(object sender, RoutedEventArgs e)
        {
            CheckValidationPassword();
        }

        private void CheckValidationPassword()
        {
            bool isUpper = false;
            bool isLower = false;
            bool isNumber = false;
            bool goodLength = false;

            PasswordProgress.Value = 0;

            if(PasswordTextBox.Password.Length > 5)
                goodLength = true;

            // Проверка букв строки
            foreach (char c in PasswordTextBox.Password)
            {
                if (Char.IsUpper(c))
                    isUpper = true;
                if (Char.IsLower(c))
                    isLower = true;
                if (Char.IsNumber(c))
                    isNumber = true;
            }

            if (goodLength)
                PasswordProgress.Value += 25;
            if (isUpper)
                PasswordProgress.Value += 25;
            if (isLower)
                PasswordProgress.Value += 25;
            if (isNumber)
                PasswordProgress.Value += 25;

            if (PasswordProgress.Value != 100)
                PasswordProgress.Foreground = Brushes.Red;
            else
                PasswordProgress.Foreground = Brushes.Green;

        }
    }
}
