using System;
using System.Threading.Tasks;

namespace Amoenus.PclTimer
{
    public abstract class BaseTimer
    {
        /// <summary>
        ///     The interval between ticks
        /// </summary>
        private readonly TimeSpan _interval;

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
        
        protected BaseTimer(TimeSpan startTime)
        {
            _interval = TimeSpan.FromSeconds(1);
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
        public TimeSpan Interval => _interval;

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
                RunTimer();
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
        private async void RunTimer()
        {
            while (_timerRunning)
            {
                await Task.Delay(_interval);

                if (_timerRunning)
                    CountCurrent();
            }
        }

        protected abstract void CountCurrent();
    }
}