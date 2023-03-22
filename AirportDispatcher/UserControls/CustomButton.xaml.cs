using System;
using System.Windows;
using System.Windows.Controls;

namespace AirportDispatcher.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CustomButton.xaml
    /// </summary>
    public partial class CustomButton : UserControl
    {
        public string Text { set; get; }

        public delegate void MyButtonClickEventHandler(object sender, EventArgs e);
        public event MyButtonClickEventHandler Click;

        private void ThisButton_Click(object sender, RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }

        public CustomButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
