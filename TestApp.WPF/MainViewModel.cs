using System;
using System.Windows;
using Amoenus.PclTimer;

namespace TestApp.WPF
{
    /// <summary>
    /// Apps main view model
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class MainViewModel : IDisposable
    {
        private readonly CountDownTimer _countDownTimer;
        private readonly IMainAppView _mainWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="mainWindow">The main window.</param>
        /// <param name="startTime">The start time.</param>
        public MainViewModel(IMainAppView mainWindow, TimeSpan startTime)
        {
            _mainWindow = mainWindow;

            _countDownTimer = new CountDownTimer(startTime);

            SubscribeEvents();
            PopulateView();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, 
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            UnsubscribeEvents();
        }

        private void PopulateView()
        {
            _mainWindow.UpdateCurrentTime(GetFormattedString());
        }

        private void UnsubscribeEvents()
        {
            _mainWindow.StartClicked -= MainWindow_StartClicked;
            _mainWindow.StopClicked -= MainWindow_StopClicked;
            _mainWindow.ResetClicked -= MainWindow_ResetClicked;
            _countDownTimer.IntervalPassed -= CountDownTimer_IntervalPassed;
            _countDownTimer.ReachedZero -= CountDownTimer_ReachedZero;
        }

        private void SubscribeEvents()
        {
            _mainWindow.StartClicked += MainWindow_StartClicked;
            _mainWindow.StopClicked += MainWindow_StopClicked;
            _mainWindow.ResetClicked += MainWindow_ResetClicked;
            _countDownTimer.IntervalPassed += CountDownTimer_IntervalPassed;
            _countDownTimer.ReachedZero += CountDownTimer_ReachedZero;
        }

        private static void CountDownTimer_ReachedZero(object sender, EventArgs e)
        {
            MessageBox.Show("Zero reached");
        }

        private void CountDownTimer_IntervalPassed(object sender, EventArgs e)
        {
            _mainWindow.UpdateCurrentTime(GetFormattedString());
        }

        private void MainWindow_ResetClicked(object sender, EventArgs e)
        {
            _countDownTimer.Reset();
            _mainWindow.UpdateCurrentTime(GetFormattedString());
        }

        private void MainWindow_StopClicked(object sender, EventArgs e)
        {
            _countDownTimer.Stop();
        }

        private void MainWindow_StartClicked(object sender, EventArgs e)
        {
            _countDownTimer.Start();
        }

        private string GetFormattedString()
        {
            return
                $"{_countDownTimer.CurrentTime.Hours:00}:" +
                $"{_countDownTimer.CurrentTime.Minutes:00}:" +
                $"{_countDownTimer.CurrentTime.Seconds:00}";
        }
    }
}