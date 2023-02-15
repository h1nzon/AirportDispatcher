using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AirportDispatcher.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CustomTextBox.xaml
    /// </summary>
    public partial class CustomTextBox : UserControl
    {
        public string Header { get; set; }
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
            ThisTextBox.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            ThisPasswordBox.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            easingFunction.EasingMode = EasingMode.EaseOut;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TypeSelected();
        }

        /// <summary>
        /// Событие для анимации CustomTextBox 
        /// </summary>
        private async void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            await Task.Delay(100);
            if (!_flagAnimation && String.IsNullOrWhiteSpace(ThisTextBox.Text) && ThisPasswordBox.Password == "")
            {
                _flagAnimation = true;

                DoubleAnimation translateYAnimation = new DoubleAnimation
                {
                    From = 0,
                    To = -18,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                DoubleAnimation fontSizeAnimation = new DoubleAnimation
                {
                    From = 12,
                    To = 15,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(translateYAnimation);
                storyboard.Children.Add(fontSizeAnimation);
                FrameworkElement element = ThisTextBlock;
                PropertyPath propertyPath = new PropertyPath("(FrameworkElement.RenderTransform).(TranslateTransform.Y)");
                Storyboard.SetTargetProperty(translateYAnimation, propertyPath);
                Storyboard.SetTargetProperty(fontSizeAnimation, new PropertyPath(TextBlock.FontSizeProperty));
                ThisTextBlock.RenderTransform = new TranslateTransform(0, 0);
                storyboard.Begin(element);

                await Task.Delay(500);

                ThisTextBox.CaretBrush = null;
                ThisPasswordBox.CaretBrush = null;
            }
        }

        /// <summary>
        /// Событие для анимации CustomTextBox 
        /// </summary>
        private async void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            await Task.Delay(200);
            if (_flagAnimation && String.IsNullOrWhiteSpace(ThisTextBox.Text) && ThisPasswordBox.Password == "")
            {
                _flagAnimation = false;

                ThisTextBox.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                ThisPasswordBox.CaretBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

                DoubleAnimation translateYAnimation = new DoubleAnimation
                {
                    From = -18,
                    To = 0,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                DoubleAnimation fontSizeAnimation = new DoubleAnimation
                {
                    From = 15,
                    To = 12,
                    Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(translateYAnimation);
                storyboard.Children.Add(fontSizeAnimation);
                FrameworkElement element = ThisTextBlock;
                PropertyPath propertyPath = new PropertyPath("(FrameworkElement.RenderTransform).(TranslateTransform.Y)");
                Storyboard.SetTargetProperty(translateYAnimation, propertyPath);
                Storyboard.SetTargetProperty(fontSizeAnimation, new PropertyPath(TextBlock.FontSizeProperty));
                ThisTextBlock.RenderTransform = new TranslateTransform(0, 0);
                storyboard.Begin(element);
            }
        }

        /// <summary>
        /// Проверка выбранного типа TextBox
        /// </summary>
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
