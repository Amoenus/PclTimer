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

namespace TestApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainAppView
    {
        private TimeSpan _currentTime;

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel viewModel = new MainViewModel(this, TimeSpan.FromSeconds(5));
        }

        public string CurrentTimeText
        {
            get
            {
                return lblCurrentTime.Content.ToString();
            }
            private set
            {
                lblCurrentTime.Content = value;
            }
        }

        public event EventHandler ResetClicked;
        public event EventHandler StartClicked;
        public event EventHandler StopClicked;

        public void UpdateCurrentTime(string formattedTimeString)
        {
            lblCurrentTime.Content = formattedTimeString;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            StartClicked?.Invoke(sender, e);
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            StopClicked?.Invoke(sender, e);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetClicked?.Invoke(sender, e);
        }
    }
}
