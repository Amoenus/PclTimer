using System;
using System.Windows;

namespace TestApp.WPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainAppView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainViewModel(this, TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// Gets the current time text.
        /// </summary>
        /// <value>
        /// The current time text.
        /// </value>
        public string CurrentTimeText => lblCurrentTime.Content.ToString();

        /// <summary>
        ///     Occurs when [reset clicked].
        /// </summary>
        public event EventHandler ResetClicked;

        /// <summary>
        ///     Occurs when [start clicked].
        /// </summary>
        public event EventHandler StartClicked;

        /// <summary>
        ///     Occurs when [stop clicked].
        /// </summary>
        public event EventHandler StopClicked;

        /// <summary>
        ///     Updates the current time.
        /// </summary>
        /// <param name="formattedTimeString">The formatted time string.</param>
        public void UpdateCurrentTime(string formattedTimeString)
        {
            lblCurrentTime.Content = formattedTimeString;
        }

        private void BtnStartClick(object sender, RoutedEventArgs e)
        {
            StartClicked?.Invoke(sender, e);
        }

        private void BtnStopClick(object sender, RoutedEventArgs e)
        {
            StopClicked?.Invoke(sender, e);
        }

        private void BtnResetClick(object sender, RoutedEventArgs e)
        {
            ResetClicked?.Invoke(sender, e);
        }
    }
}