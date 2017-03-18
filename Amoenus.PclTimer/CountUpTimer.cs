using System;

namespace Amoenus.PclTimer
{
    /// <summary>
    ///     Timer that counts down
    /// </summary>
    /// <seealso cref="Amoenus.PclTimer.BaseTimer" />
    public class CountUpTimer : BaseTimer
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CountUpTimer" /> class. Default tick interval is 1 second
        /// </summary>
        /// <param name="startTime">The start time.</param>
        public CountUpTimer(TimeSpan startTime) : base(startTime)
        {
        }

        /// <summary>
        ///     Counts up the time and raises the IntervalPassed event.
        /// </summary>
        protected override void CountCurrent()
        {
            CurrentTime = CurrentTime.Add(Interval);
            RaiseIntervalPassedEvent();
        }
    }
}