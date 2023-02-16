using System.Windows.Controls;

namespace AirportDispatcher.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CustomButton.xaml
    /// </summary>
    public partial class CustomButton : UserControl
    {
        public string Text { set; get; }
        public CustomButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        /*private Storyboard backgroundAnimation;*/

        private void ThisButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void ThisButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        /*private void AnimationStart()
        {
            backgroundAnimation = new Storyboard();
            backgroundAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            backgroundAnimation.AutoReverse = true;
            FrameworkElement element = ThisButton;
            ColorAnimation animation = new ColorAnimation();
            animation.From = Colors.LightGray;
            animation.To = Colors.DarkGray;
            animation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            animation.AutoReverse = true;

            Storyboard.SetTargetProperty(animation, new PropertyPath("(Button.Background).(SolidColorBrush.Color)"));
            backgroundAnimation.Children.Add(animation);
            backgroundAnimation.Begin(element, true);
        }*/
    }
}
