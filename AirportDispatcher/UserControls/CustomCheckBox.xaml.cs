using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows;

namespace AirportDispatcher.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CustomCheckBox.xaml
    /// </summary>
    public partial class CustomCheckBox : UserControl
    {
        public string Text { get; set; }
        public CustomCheckBox()
        {
            InitializeComponent();
        }

        private void Animation()
        {
            if ((bool)StatusCheckBox.IsChecked)
            {
                DoubleAnimation translateXAnimation = new DoubleAnimation
                {
                    From = 0,
                    To = 15,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };

                ColorAnimation colorAnimation = new ColorAnimation
                {
                    From = Color.FromArgb(0, 139, 215, 249),
                    To = Color.FromArgb(255, 139, 215, 249),
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(translateXAnimation);
                storyboard.Children.Add(colorAnimation);

                PropertyPath propertyTranslate = new PropertyPath("(FrameworkElement.RenderTransform).(TranslateTransform.X)");
                PropertyPath propertyColor = new PropertyPath("(Rectangle.Fill).(SolidColorBrush.Color)");

                Storyboard.SetTargetProperty(translateXAnimation, propertyTranslate);
                Storyboard.SetTarget(translateXAnimation, SliderEllipse);
                Storyboard.SetTargetProperty(colorAnimation, propertyColor);
                Storyboard.SetTarget(colorAnimation, StatusBar);
                SliderEllipse.RenderTransform = new TranslateTransform(0, 0);
                storyboard.Begin();
            }
            else if (!(bool)StatusCheckBox.IsChecked)
            {
                DoubleAnimation translateXAnimation = new DoubleAnimation
                {
                    From = 15,
                    To = 0,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };

                ColorAnimation colorAnimation = new ColorAnimation
                {
                    From = Color.FromArgb(255, 139, 215, 249),
                    To = Color.FromArgb(0, 139, 215, 249),
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(translateXAnimation);
                storyboard.Children.Add(colorAnimation);

                PropertyPath propertyTranslate = new PropertyPath("(FrameworkElement.RenderTransform).(TranslateTransform.X)");
                PropertyPath propertyColor = new PropertyPath("(Rectangle.Fill).(SolidColorBrush.Color)");

                Storyboard.SetTargetProperty(translateXAnimation, propertyTranslate);
                Storyboard.SetTarget(translateXAnimation, SliderEllipse);
                Storyboard.SetTargetProperty(colorAnimation, propertyColor);
                Storyboard.SetTarget(colorAnimation, StatusBar);
                SliderEllipse.RenderTransform = new TranslateTransform(0, 0);
                storyboard.Begin();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StatusCheckBox.IsChecked = !StatusCheckBox.IsChecked;
            Animation();
        }
    }
}
