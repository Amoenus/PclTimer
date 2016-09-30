using System;
using System.Windows;

namespace TestApp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IMainAppView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public MainWindow()
        {
            InitializeComponent();
            TimeSpan startTime = TimeSpan.FromSeconds(5);
            new MainViewModel(this, startTime);
        }

        public string CurrentTimeText => LblCurrentTime.Content.ToString();

        public event EventHandler ResetClicked;
        public event EventHandler StartClicked;
        public event EventHandler StopClicked;

        public void UpdateCurrentTime(string formattedTimeString)
        {
            LblCurrentTime.Content = formattedTimeString;
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
