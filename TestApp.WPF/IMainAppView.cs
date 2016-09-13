using System;

namespace TestApp.WPF
{
    public interface IMainAppView
    {
        event EventHandler StartClicked;
        event EventHandler StopClicked;
        event EventHandler ResetClicked;

        string CurrentTimeText { get; }

        void UpdateCurrentTime(string formattedTimeString);
    }
}