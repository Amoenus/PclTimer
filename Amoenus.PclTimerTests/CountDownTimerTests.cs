using System;
using System.Threading;
using Amoenus.PclTimer;
using NUnit.Framework;
using Shouldly;

namespace Amoenus.PclTimerTests
{
    [TestFixture]
    public class CountDownTimerTests
    {
        private const int ExpectedTicks = 2;

        [Test]
        [Category("Unit")]
        public void CountDownTimer_WhenProvidedWithTime_InitializesStopped()
        {
            // Arrange
            TimeSpan expectedSeconds = TimeSpan.FromSeconds(ExpectedTicks);

            // Act
            IPclTimer classUnderTest = new CountDownTimer(expectedSeconds);

            // Assert
            classUnderTest.CurrentTime.ShouldBe(expectedSeconds);
            classUnderTest.IsTimerRunning.ShouldBeFalse();
            classUnderTest.IsTimerStopped.ShouldBeTrue();
        }

        [Test]
        [Category("Unit")]
        public void CountDownTimer_WhenStarted_CountsDownAndFiresEvent()
        {
            // Arrange
            TimeSpan expectedSeconds = TimeSpan.FromSeconds(ExpectedTicks);
            int actualTicks = 0;

            IPclTimer classUnderTest = new CountDownTimer(expectedSeconds);
            classUnderTest.IntervalPassed += (o, e) => { actualTicks++; };

            // Act
            classUnderTest.Start();
            Thread.Sleep(TimeSpan.FromSeconds(ExpectedTicks * 2));

            // Assert
            classUnderTest.CurrentTime.ShouldBeLessThan(expectedSeconds);
            actualTicks.ShouldBeGreaterThan(ExpectedTicks);
        }
    }
}