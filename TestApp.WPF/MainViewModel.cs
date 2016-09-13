using System;
using Amoenus.PclTimer;
using System.Windows;

namespace TestApp.WPF
{
    public class MainViewModel : IDisposable
    {
        private IMainAppView _mainWindow;
        private TimeSpan _startTime;
        CountDownTimer _countDownTimer;

        public MainViewModel(IMainAppView mainWindow, TimeSpan startTime)
        {
            _mainWindow = mainWindow;
            _startTime = startTime;

            _countDownTimer = new CountDownTimer(startTime);

            SubscribeEvents();
            PopulateView();
        }

        private void PopulateView()
        {
            _mainWindow.UpdateCurrentTime(GetFormattedString());
        }

        public void Dispose()
        {
            UnsubscribeEvents();
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

        private void CountDownTimer_ReachedZero(object sender, EventArgs e)
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
            return $"{_countDownTimer.CurrentTime.Hours.ToString("00")}:{_countDownTimer.CurrentTime.Minutes.ToString("00")}:{_countDownTimer.CurrentTime.Seconds.ToString("00")}";
        }

    }
}
