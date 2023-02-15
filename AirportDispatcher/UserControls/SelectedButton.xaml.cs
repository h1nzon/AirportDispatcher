using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Documents;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace AirportDispatcher.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SelectedButton.xaml
    /// </summary>
    public partial class SelectedButton : UserControl
    {

        public string Text { get; set; }
        public bool IsSelected { get; set; }

        public SelectedButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public delegate void MyButtonClickEventHandler(object sender, EventArgs e);
        public event MyButtonClickEventHandler Click;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThisRadioButton.IsChecked = true;
            if (Click != null)
            {
                Click(this, e);
            }
        }

        private void ThisButton_MouseEnter(object sender, MouseEventArgs e)
        {
            LineAnimationEnabled();
        }

        private void ThisButton_MouseLeave(object sender, MouseEventArgs e)
        {
            LineAnimationFalse();
        }

        private void ThisRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            LineAnimationEnabled();
        }

        private void ThisRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LineAnimationFalse();
        }

        private bool _firstStart = true;
        private void LineAnimationEnabled()
        {
            if (!(bool)ThisRadioButton.IsChecked || _firstStart)
            {
                _firstStart = false;
                DoubleAnimation animation = new DoubleAnimation
                {
                    From = 0,
                    To = ActualWidth,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                LineSelected.BeginAnimation(Line.X2Property, animation);
            }
        }

        private void LineAnimationFalse()
        {
            if (!(bool)ThisRadioButton.IsChecked)
            {
                LineSelected.Visibility = Visibility.Visible;
                DoubleAnimation animation = new DoubleAnimation
                {
                    From = ActualWidth,
                    To = 0,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                LineSelected.BeginAnimation(Line.X2Property, animation);
            }
        }
    }
}
