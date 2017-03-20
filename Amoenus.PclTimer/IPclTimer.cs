using System;

namespace Amoenus.PclTimer
{
    /// <summary>
    ///     PCL Timer Interface
    /// </summary>
    public interface IPclTimer
    {
        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        TimeSpan Interval { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance of a timer is currently stopped.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance of a timer is currently stopped; otherwise, <c>false</c>.
        /// </value>
        bool IsTimerStopped { get; }

        /// <summary>
        ///     Gets a value indicating whether this instance of a timer is currently running.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance of a timer is currently running; otherwise, <c>false</c>.
        /// </value>
        bool IsTimerRunning { get; }

        /// <summary>
        ///     Gets current count down time.
        /// </summary>
        /// <value>
        ///     The count down time.
        /// </value>
        TimeSpan CurrentTime { get; set; }

        /// <summary>
        ///     Starts the timer.
        ///     Please note that if invoked when current CountDownTime is at 0
        ///     ReachedZero Event will still be fired and the CountDownTime will remain at zero.
        /// </summary>
        void Start();

        /// <summary>
        ///     Pauses the timer.
        /// </summary>
        void Stop();

        /// <summary>
        ///     Stops and resets the timer to initial start time.
        /// </summary>
        void Reset();

        /// <summary>
        ///     Occurs on each tick between specified interval.
        /// </summary>
        event EventHandler IntervalPassed;
    }
}