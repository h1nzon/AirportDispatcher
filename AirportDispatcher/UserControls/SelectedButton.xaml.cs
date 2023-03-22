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
        public bool IsChecked { get; set; }
        public string GroupName = "ButtonSelected";
        public bool FirstStart = true;

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

        #region Animation

        private void LineAnimationEnabled()
        {
            if (!(bool)ThisRadioButton.IsChecked || FirstStart)
            {
                FirstStart = false;
                DoubleAnimation animation = new DoubleAnimation
                {
                    From = LineSelected.ActualWidth,
                    To = ActualWidth,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                LineSelected.BeginAnimation(Line.X2Property, animation);
            }
        }

        public void LineAnimationFalse()
        {
            if (!(bool)ThisRadioButton.IsChecked)
            {
                LineSelected.Visibility = Visibility.Visible;
                DoubleAnimation animation = new DoubleAnimation
                {
                    From = LineSelected.ActualWidth,
                    To = 0,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                LineSelected.BeginAnimation(Line.X2Property, animation);
            }
        }

        #endregion

        #region Events
        public void ReloadElement()
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = LineSelected.ActualWidth,
                To = ActualWidth * 2,
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            LineSelected.BeginAnimation(Line.X2Property, animation);
        }

        public delegate void MyButtonClickEventHandler(object sender, EventArgs e);
        public event MyButtonClickEventHandler Click;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThisRadioButton.IsChecked = true;
            Click?.Invoke(this, e);
        }

        private void ThisButton_AnimationEnabled(object sender, EventArgs e)
        {
            LineAnimationEnabled();
        }

        private void ThisButton_AnimationFalse(object sender, EventArgs e)
        {
            LineAnimationFalse();
        }

        #endregion
    }
}
