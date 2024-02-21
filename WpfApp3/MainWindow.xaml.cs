using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double[] margins = new double[] { 0, 0, 0, 0 };
        Random rnd = new Random();
        Random rnd2 = new Random();
        bool _timerStatus = true;
        DispatcherTimer _timer = null;

        public MainWindow()
        {
            InitializeComponent();
            margins[0] = btn.Margin.Top;
            margins[1] = btn.Margin.Left;
            btn.IsEnabled = true;
            _timer = new DispatcherTimer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            int sec = int.Parse(Seconds.Content.ToString());
            sec++;

            if (sec > 59)
            {
                sec = 0;
                Minutes.Content = int.Parse(Minutes.Content.ToString()) + 1;
            }
            Seconds.Content = sec.ToString();
        }

        private void ButtonHover_Click(object sender, MouseEventArgs e)
        {

            int num = rnd.Next(-300, 300);
            int num2 = rnd2.Next(-300, 300);
            btn.Margin = new Thickness(margins[0] + num, margins[1] + num2, 0, 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label.Content = "You've clicked the button!";
            if (_timerStatus)
                _timer.Stop();
            btn.IsEnabled = false;
        }
    }
}
