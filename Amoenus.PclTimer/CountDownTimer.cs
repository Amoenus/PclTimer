using System;
using System.Threading.Tasks;

namespace Amoenus.PclTimer
{
    public class CountDownTimer
    {
        /// <summary>
        /// Occurs on each tick between specified interval.
        /// </summary>
        public event EventHandler IntervalPassed;

        /// <summary>
        /// The interval between ticks
        /// </summary>
        private TimeSpan _interval;

        /// <summary>
        /// The current time of the count down
        /// </summary>
        private TimeSpan _startTime;

        /// <summary>
        /// The current time of the count down
        /// </summary>
        private TimeSpan _countDownTime;

        /// <summary>
        /// Gets current count down time.
        /// </summary>
        /// <value>
        /// The count down time.
        /// </value>
        public TimeSpan CountDownTime
        {
            get { return _countDownTime; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance of a timer is currently stopped.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance of a timer is currently stopped; otherwise, <c>false</c>.
        /// </value>
        public bool IsTimerStopped
        {
            get { return !_timerRunning; }
        }

        /// <summary>
        ///  Gets a value indicating whether this instance of a timer is currently running.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance of a timer is currently running; otherwise, <c>false</c>.
        /// </value>
        public bool IsTimerRunning
        {
            get { return _timerRunning; }
        }

        /// <summary>
        /// Denotes whether the timer is running or not
        /// </summary>
        private bool _timerRunning;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountDownTimer"/> class. Default tick interval is 1 second
        /// </summary>
        /// <param name="startTime">The start time.</param>
        public CountDownTimer(TimeSpan startTime)
        {
            _interval = TimeSpan.FromSeconds(1);
            _startTime = startTime;
            _countDownTime = _startTime;
        }

        /// <summary>
        /// Raises the interval passed event.
        /// </summary>
        private void RaiseIntervalPassedEvent()
        {
            IntervalPassed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Starts the timer.
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
        /// Pauses the timer.
        /// </summary>
        public void Stop()
        {
            _timerRunning = false;
        }

        /// <summary>
        /// Stops and resets the timer to initial start time.
        /// </summary>
        public void Reset()
        {
            Stop();
            _countDownTime = _startTime;
        }

        /// <summary>
        /// Timer loop that invokes IntervalPassed event and 
        /// </summary>
        private async void RunTimer()
        {
            while (_timerRunning)
            {
                await Task.Delay(_interval);

                if (_timerRunning)
                {
                    CountDown();
                }
            }
        }

        /// <summary>
        /// Counts down the time and raises the IntervalPassed event.
        /// </summary>
        private void CountDown()
        {
            if (_countDownTime <= TimeSpan.Zero)
            {
                Stop();
            }
            _countDownTime = _countDownTime.Subtract(_interval);
            RaiseIntervalPassedEvent();
        }
    }
}
