using System;

namespace Amoenus.PclTimer
{
    /// <summary>
    /// Interface for CountDownTimer
    /// </summary>
    /// <seealso cref="Amoenus.PclTimer.IPclTimer" />
    public interface ICountDownTimer : IPclTimer
    {
        /// <summary>
        ///     Occurs when countdown reaches zero.
        /// </summary>
        event EventHandler ReachedZero;
    }
}
