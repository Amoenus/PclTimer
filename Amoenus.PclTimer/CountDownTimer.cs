using System;

namespace Amoenus.PclTimer
{
    /// <summary>
    ///     Timer that counts up
    /// </summary>
    /// <seealso cref="Amoenus.PclTimer.BaseTimer" />
    public class CountDownTimer : BaseTimer
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CountDownTimer" /> class. Default tick interval is 1 second
        /// </summary>
        /// <param name="startTime">The start time.</param>
        public CountDownTimer(TimeSpan startTime) : base(startTime)
        {
        }

        /// <summary>
        ///     Occurs when countdown reaches zero.
        /// </summary>
        public event EventHandler ReachedZero;

        /// <summary>
        ///     Raises the countdown reached zero event.
        /// </summary>
        private void RaiseReachedZeroEvent()
        {
            ReachedZero?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Counts down the time and raises the IntervalPassed event.
        /// </summary>
        protected override void CountCurrent()
        {
            if (CurrentTime <= TimeSpan.Zero)
            {
                CurrentTime = TimeSpan.Zero;
                RaiseReachedZeroEvent();
                Stop();
            }
            CurrentTime = CurrentTime.Subtract(Interval);
            RaiseIntervalPassedEvent();
        }
    }
}