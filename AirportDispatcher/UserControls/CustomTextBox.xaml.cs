using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AirportDispatcher.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
        public string Text { get; set; }

        private bool _flagAnimation = false;

        SineEase easingFunction = new SineEase();


        public CustomTextBox()
        {
            InitializeComponent();
            this.DataContext = this;
            easingFunction.EasingMode = EasingMode.EaseOut;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!_flagAnimation)
            {
                _flagAnimation = true;
                double currentY = ThisTextBox.Margin.Top;
                DoubleAnimation anim = new DoubleAnimation(currentY - 15, TimeSpan.FromSeconds(1));
                anim.EasingFunction = easingFunction;
                ThisTextBox.BeginAnimation(FrameworkElement.MarginProperty, new ThicknessAnimation(new Thickness(0, currentY - 15, 0, 0), TimeSpan.FromSeconds(0.1)));
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (_flagAnimation)
            {
                _flagAnimation = false;
                double currentY = ThisTextBox.Margin.Top;
                double currentX = ThisTextBox.Margin.Left;
                DoubleAnimation anim = new DoubleAnimation(currentY + 15, TimeSpan.FromSeconds(1));
                anim.EasingFunction = easingFunction;
                ThisTextBox.BeginAnimation(FrameworkElement.MarginProperty, new ThicknessAnimation(new Thickness(currentX + 5, currentY + 15, 0, 0), TimeSpan.FromSeconds(0.1)));
            }
            
        }
    }
}
