using NUnit.Framework;
using System;
using System.Threading;
using Amoenus.PclTimer;

namespace Amoenus.PclTimerTests
{
    [TestFixture]
    public class CountDownTimerTest
    {
        [Test]
        [Category("Unit")]
        public void CountDownTimer_WhenStarted_CountsDownAndFiresEvent()
        {
            // Arrange
            const int ExpectedTicks = 2;
            TimeSpan ExpectedSeconds = TimeSpan.FromSeconds(ExpectedTicks);
            int actualTicks = 0;

            var classUnderTest = new CountDownTimer(ExpectedSeconds);
            classUnderTest.IntervalPassed += (o, e) => { actualTicks++; };

            // Act
            classUnderTest.Start();
            Thread.Sleep(TimeSpan.FromSeconds(ExpectedTicks * 2));
            // Assert
            Assert.That(classUnderTest.CountDownTime, Is.LessThan(ExpectedSeconds));
            Assert.That(actualTicks, Is.GreaterThan(ExpectedTicks));
        }

        [Test]
        [Category("Unit")]
        public void CountDownTimer_WhenProvidedWithTime_InitialisesStopped()
        {
            // Arrange
            const int ExpectedTicks = 2;
            TimeSpan ExpectedSeconds = TimeSpan.FromSeconds(ExpectedTicks);

            // Act
            var classUnderTest = new CountDownTimer(ExpectedSeconds);

            // Assert
            Assert.That(classUnderTest.CountDownTime, Is.EqualTo(ExpectedSeconds));
            Assert.That(classUnderTest.IsTimerRunning, Is.False);
            Assert.That(classUnderTest.IsTimerStopped, Is.True);
        }
    }
}
