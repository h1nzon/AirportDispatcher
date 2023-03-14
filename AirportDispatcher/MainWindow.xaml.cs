using AirportDispatcher.View.Windows;
using System.Windows;

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
                _menuMinimal = true;
                MenuColumn.Width = new GridLength(2, GridUnitType.Star);
            }
            else
            {
                _menuMinimal = false;
                MenuColumn.Width = new GridLength(1, GridUnitType.Star);
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
