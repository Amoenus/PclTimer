using System;

namespace Amoenus.PclTimer
{
    /// <summary>
    /// The normal timer that counts "up" from start time
    /// </summary>
    /// <seealso cref="BaseTimer" />
    public class CountUpTimer : BaseTimer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountUpTimer"/> class.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        public CountUpTimer(TimeSpan startTime): base(startTime)
        {
        }

        /// <summary>
        /// Counts up the time and raises the IntervalPassed event.
        /// </summary>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        protected override void CountCurrent()
        {
            CurrentTime = CurrentTime.Add(Interval);

            RaiseIntervalPassedEvent();
        }
    }
}
