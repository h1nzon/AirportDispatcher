using AirportDispatcher.UserControls;
using AirportDispatcher.View.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AirportDispatcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _menuMinimal = false;

        public MainWindow()
        {
            InitializeComponent();

            // Переход на авторизацию
            if (!Properties.Settings.Default.isLogin)
            {
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Close();
            }
        }

        #region ButtonEvents
        private void MinimalMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_menuMinimal)
            {
                List<SelectedButton> radioButtons = MenuApplication.Children.OfType<SelectedButton>().ToList();
                radioButtons = radioButtons.Where(r => (bool)r.IsChecked).ToList();
                _menuMinimal = true;
                MenuColumn.Width = new GridLength(2, GridUnitType.Star);
                radioButtons[0].ReloadElement();
            }
            else
            {
                List<SelectedButton> radioButtons = MenuApplication.Children.OfType<SelectedButton>().ToList();
                radioButtons = radioButtons.Where(r => (bool)r.IsChecked).ToList();
                _menuMinimal = false;
                MenuColumn.Width = new GridLength(1, GridUnitType.Star);
                radioButtons[0].ReloadElement();
            }
        }
        private void ApplicationClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ApplicationBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion
    }
}
