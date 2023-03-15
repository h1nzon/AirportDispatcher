using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Input;

namespace AirportDispatcher.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SelectedButton.xaml
    /// </summary>
    public partial class SelectedButton : UserControl
    {

        public string Text { get; set; }
        public int ImageWidth { get; set; }
        public string ImageSource { get; set; }
        public bool IsSelected { get; set; }


        public SelectedButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Text))
                TextContent.Visibility = Visibility.Collapsed;
            if (!String.IsNullOrEmpty(ImageSource))
                ImageContent.Visibility = Visibility.Visible;
            ThisButton.Width = ActualWidth; 
            ThisButton.Height = ActualHeight;
            if(ImageWidth != 0)
                ImageContent.Width = ImageWidth; 
        }

        public delegate void MyButtonClickEventHandler(object sender, EventArgs e);
        public event MyButtonClickEventHandler Click;
        private bool _firstStart = true;

        #region Animation

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

        #endregion

        #region Events

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThisRadioButton.IsChecked = true;
            Click?.Invoke(this, e);
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

        #endregion

    }
}
