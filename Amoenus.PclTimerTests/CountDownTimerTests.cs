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
        [Test]
        [Category("Unit")]
        public void CountDownTimer_WhenProvidedWithTime_InitializesStopped()
        {
            // Arrange
            const int expectedTicks = 2;
            TimeSpan expectedSeconds = TimeSpan.FromSeconds(expectedTicks);

            // Act
            var classUnderTest = new CountDownTimer(expectedSeconds);

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
            const int expectedTicks = 2;
            TimeSpan expectedSeconds = TimeSpan.FromSeconds(expectedTicks);
            int actualTicks = 0;

            var classUnderTest = new CountDownTimer(expectedSeconds);
            classUnderTest.IntervalPassed += (o, e) => { actualTicks++; };

            // Act
            classUnderTest.Start();
            Thread.Sleep(TimeSpan.FromSeconds(expectedTicks * 2));

            // Assert
            classUnderTest.CurrentTime.ShouldBeLessThan(expectedSeconds);
            actualTicks.ShouldBeGreaterThan(expectedTicks);
        }
    }
}