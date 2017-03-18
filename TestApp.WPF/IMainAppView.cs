using System;

namespace TestApp.WPF
{
    /// <summary>
    ///     Apps main view
    /// </summary>
    public interface IMainAppView
    {
        /// <summary>
        ///     Gets the current time text.
        /// </summary>
        /// <value>
        ///     The current time text.
        /// </value>
        string CurrentTimeText { get; }

        /// <summary>
        ///     Occurs when [start clicked].
        /// </summary>
        event EventHandler StartClicked;

        /// <summary>
        ///     Occurs when [stop clicked].
        /// </summary>
        event EventHandler StopClicked;

        /// <summary>
        ///     Occurs when [reset clicked].
        /// </summary>
        event EventHandler ResetClicked;

        /// <summary>
        ///     Updates the current time.
        /// </summary>
        /// <param name="formattedTimeString">The formatted time string.</param>
        void UpdateCurrentTime(string formattedTimeString);
    }
}