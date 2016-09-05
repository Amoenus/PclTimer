using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoenus.PclTimer
{
    public class CountUpTimer : BaseTimer
    {
        public CountUpTimer(TimeSpan startTime): base(startTime)
        {
        }

        /// <summary>
        /// Counts up the time and raises the IntervalPassed event.
        /// </summary>
        protected override void CountCurrent()
        {
            CurrentTime = CurrentTime.Add(Interval);
            RaiseIntervalPassedEvent();
        }
    }
}
