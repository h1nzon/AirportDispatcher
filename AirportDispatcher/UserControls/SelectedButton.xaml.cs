using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;

namespace AirportDispatcher.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SelectedButton.xaml
    /// </summary>
    public partial class SelectedButton : UserControl
    {
        public string Text { get; set; }
        public Visibility VisibilityLine 
        {
            get { return LineSelected.Visibility; } 
            set { LineSelected.Visibility = value; } 
        }

        public SelectedButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public delegate void MyButtonClickEventHandler(object sender, EventArgs e);
        public event MyButtonClickEventHandler Click;

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }
    }
}
