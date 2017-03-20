using System;
using System.Threading;
using Amoenus.PclTimer;
using NUnit.Framework;
using Shouldly;

namespace Amoenus.PclTimerTests
{
    [TestFixture]
    public class CountUpTimerTests
    {
        private const int ExpectedTicks = 2;

        [Test]
        [Category("Unit")]
        public void CountUpTimer_WhenProvidedWithTime_InitializesStopped()
        {
            // Arrange
            TimeSpan expectedSeconds = TimeSpan.FromSeconds(ExpectedTicks);

            // Act
            IPclTimer classUnderTest = new CountUpTimer(expectedSeconds);

            // Assert
            classUnderTest.CurrentTime.ShouldBe(expectedSeconds);
            classUnderTest.IsTimerRunning.ShouldBeFalse();
            classUnderTest.IsTimerStopped.ShouldBeTrue();
        }

        [Test]
        [Category("Unit")]
        public void CountUpTimer_WhenStarted_CountsUpAndFiresEvent()
        {
            // Arrange
            TimeSpan startTime = TimeSpan.Zero;
            int actualTicks = 0;

            IPclTimer classUnderTest = new CountUpTimer(startTime);
            classUnderTest.IntervalPassed += (o, e) => { actualTicks++; };

            // Act
            classUnderTest.Start();
            Thread.Sleep(TimeSpan.FromSeconds(ExpectedTicks * 2));

            // Assert
            classUnderTest.CurrentTime.ShouldBeGreaterThan(startTime);
            actualTicks.ShouldBeGreaterThan(ExpectedTicks);
        }
    }
}