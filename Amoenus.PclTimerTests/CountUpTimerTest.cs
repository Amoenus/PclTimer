using NUnit.Framework;
using System;
using System.Threading;
using Amoenus.PclTimer;

namespace CookWareTests
{
    [TestFixture]
    public class CountUpTimerTest
    {
        [Test]
        [Category("Unit")]
        public void CountUpTimer_WhenStarted_CountsUpAndFiresEvent()
        {
            // Arrange
            const int ExpectedTicks = 2;
            TimeSpan startTime = TimeSpan.Zero;
            TimeSpan ExpectedSeconds = TimeSpan.FromSeconds(ExpectedTicks);
            int actualTicks = 0;

            var classUnderTest = new CountUpTimer(startTime);
            classUnderTest.IntervalPassed += (o, e) => { actualTicks++; };

            // Act
            classUnderTest.Start();
            Thread.Sleep(TimeSpan.FromSeconds(ExpectedTicks * 2));
            // Assert
            Assert.That(classUnderTest.CurrentTime, Is.GreaterThan(startTime));
            Assert.That(actualTicks, Is.GreaterThan(ExpectedTicks));
        }

        [Test]
        [Category("Unit")]
        public void CountUpTimer_WhenProvidedWithTime_InitialisesStopped()
        {
            // Arrange
            const int ExpectedTicks = 2;
            TimeSpan ExpectedSeconds = TimeSpan.FromSeconds(ExpectedTicks);

            // Act
            var classUnderTest = new CountUpTimer(ExpectedSeconds);

            // Assert
            Assert.That(classUnderTest.CurrentTime, Is.EqualTo(ExpectedSeconds));
            Assert.That(classUnderTest.IsTimerRunning, Is.False);
            Assert.That(classUnderTest.IsTimerStopped, Is.True);
        }
    }
}
