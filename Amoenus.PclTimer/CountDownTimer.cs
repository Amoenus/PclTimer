using System;
using System.Threading.Tasks;

namespace Amoenus.PclTimer
{
    public class CountDownTimer : BaseTimer
    {
        /// <summary>
        /// Occurs when countdown reaches zero.
        /// </summary>
        public event EventHandler ReachedZero;


        /// <summary>
        /// Initializes a new instance of the <see cref="CountDownTimer" /> class. Default tick interval is 1 second
        /// </summary>
        /// <param name="startTime">The start time.</param>
        public CountDownTimer(TimeSpan startTime) : base(startTime)
        {
        }

        /// <summary>
        /// Raises the coundown reached zero event.
        /// </summary>
        private void RaiseReachedZeroEvent()
        {
            ReachedZero?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Counts down the time and raises the IntervalPassed event.
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
