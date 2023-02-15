using System;
using System.Threading.Tasks;
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
        
        public TextBoxType TextType { get; set; }
        
        public enum TextBoxType { Text, Password }
        
        public static readonly DependencyProperty BorderStyleProperty =
        DependencyProperty.Register("TextBoxType", typeof(TextBoxType), typeof(CustomTextBox));

        private bool _flagAnimation = false;

        SineEase easingFunction = new SineEase();

        public CustomTextBox()
        {
            InitializeComponent();
            this.DataContext = this;
            easingFunction.EasingMode = EasingMode.EaseOut;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TypeSelected();
        }

        private async void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            await Task.Delay(100);
            if (!_flagAnimation && String.IsNullOrWhiteSpace(ThisTextBox.Text) && ThisPasswordBox.Password == "")
            {
                _flagAnimation = true;
                double currentY = ThisTextBlock.Margin.Top;
                DoubleAnimation anim = new DoubleAnimation(currentY - 15, TimeSpan.FromSeconds(1));
                anim.EasingFunction = easingFunction;
                ThisTextBlock.BeginAnimation(FrameworkElement.MarginProperty, new ThicknessAnimation(new Thickness(0, currentY - 15, 0, 0), TimeSpan.FromSeconds(0.1)));
            }
        }

        private async void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            await Task.Delay(200);
            if (_flagAnimation && String.IsNullOrWhiteSpace(ThisTextBox.Text) && ThisPasswordBox.Password == "")
            {
                _flagAnimation = false;
                double currentY = ThisTextBlock.Margin.Top;
                double currentX = ThisTextBlock.Margin.Left;
                DoubleAnimation anim = new DoubleAnimation(currentY + 15, TimeSpan.FromSeconds(1));
                anim.EasingFunction = easingFunction;
                ThisTextBlock.BeginAnimation(FrameworkElement.MarginProperty, new ThicknessAnimation(new Thickness(currentX + 5, currentY + 15, 0, 0), TimeSpan.FromSeconds(0.1)));
            }
            
        }

        private void TypeSelected()
        {
            if (TextType == TextBoxType.Password)
            {
                ThisTextBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                ThisPasswordBox.Visibility = Visibility.Collapsed;
            }
        }
    }
}
