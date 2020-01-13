using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace RoundMenu
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GManu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch 
            {            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        Storyboard Storyboard;

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            Color Background = ((SolidColorBrush)btn.BorderBrush).Color;
            Storyboard = new Storyboard();
            Storyboard.Children.Add(SetAnimButton(Background, btn.Name));
            Storyboard.Children.Add(SetAnimCircle(Background));
            Storyboard.Begin(this);
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            Storyboard = new Storyboard();
            Storyboard.Children.Add(SetAnimButton(Color.FromRgb(113,110,110), btn.Name));
            Storyboard.Children.Add(SetAnimCircle(Color.FromArgb(150, 67, 67, 67)));
            Storyboard.Begin(this);
        }

        public ColorAnimation SetAnimButton(Color Color, string objName)
        {
            ColorAnimation anim = new ColorAnimation();
            anim.Duration = new Duration(TimeSpan.FromSeconds(0.2));
            anim.To = Color;
            Storyboard.SetTargetName(anim, objName);
            Storyboard.SetTargetProperty(anim, new PropertyPath("(Button.Background).(SolidColorBrush.Color)"));
            return anim;
        }

        public ColorAnimation SetAnimCircle(Color Color)
        {
            ColorAnimation anim = new ColorAnimation();
            anim.Duration = new Duration(TimeSpan.FromSeconds(0.2));
            anim.To = Color;
            Storyboard.SetTargetName(anim, "ColorCircle");
            Storyboard.SetTargetProperty(anim, new PropertyPath(GradientStop.ColorProperty));
            return anim;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            string message = "You can use it in some project!";
            MessageBox.Show(message);
        }
    }
}
