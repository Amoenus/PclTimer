using System;
using System.Threading.Tasks;

namespace Amoenus.PclTimer
{
    /// <summary>
    /// Base implementation shared by Up and Down timers
    /// </summary>
    /// <seealso cref="Amoenus.PclTimer.IPclTimer" />
    public abstract class BaseTimer : IPclTimer
    {
        /// <summary>
        ///     The current time of the count down
        /// </summary>
        private readonly TimeSpan _startTime;

        /// <summary>
        ///     The current time of the count down
        /// </summary>
        private TimeSpan _currentTime;

        /// <summary>
        ///     Denotes whether the timer is running or not
        /// </summary>
        private bool _timerRunning;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTimer"/> class.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        protected BaseTimer(TimeSpan startTime)
        {
            Interval = TimeSpan.FromSeconds(1);
            _startTime = startTime;
            _currentTime = _startTime;
        }

        /// <summary>
        ///     Gets current count down time.
        /// </summary>
        /// <value>
        ///     The count down time.
        /// </value>
        public TimeSpan CurrentTime
        {
            get { return _currentTime; }
            set { _currentTime = value >= TimeSpan.Zero ? value : TimeSpan.Zero; }
        }

        /// <summary>
        ///     Gets the interval between ticks.
        /// </summary>
        /// <value>
        ///     The interval.
        /// </value>
        public TimeSpan Interval { get; set; }

        /// <summary>
        ///     Gets a value indicating whether this instance of a timer is currently stopped.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance of a timer is currently stopped; otherwise, <c>false</c>.
        /// </value>
        public bool IsTimerStopped => !_timerRunning;

        /// <summary>
        ///     Gets a value indicating whether this instance of a timer is currently running.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance of a timer is currently running; otherwise, <c>false</c>.
        /// </value>
        public bool IsTimerRunning => _timerRunning;

        /// <summary>
        ///     Occurs on each tick between specified interval.
        /// </summary>
        public event EventHandler IntervalPassed;

        /// <summary>
        /// Raises the interval passed event.
        /// </summary>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected void RaiseIntervalPassedEvent()
        {
            IntervalPassed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Starts the timer.
        ///     Please note that if invoked when current CountDownTime is at 0
        ///     ReachedZero Event will still be fired and the CountDownTime will remain at zero.
        /// </summary>
        public void Start()
        {
            if (IsTimerStopped)
            {
                _timerRunning = true;
                RunTimerAsync();
            }
        }

        /// <summary>
        ///     Pauses the timer.
        /// </summary>
        public void Stop()
        {
            _timerRunning = false;
        }

        /// <summary>
        ///     Stops and resets the timer to initial start time.
        /// </summary>
        public void Reset()
        {
            Stop();
            _currentTime = _startTime;
        }

        /// <summary>
        ///     Timer loop that invokes IntervalPassed event and
        /// </summary>
        private async void RunTimerAsync()
        {
            while (_timerRunning)
            {
                await Task.Delay(Interval).ConfigureAwait(true);

                if (_timerRunning)
                    CountCurrent();
            }
        }

        /// <summary>
        /// Counts the current time.
        /// </summary>
        protected abstract void CountCurrent();
    }
}