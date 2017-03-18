using System;
using System.Threading;
using Amoenus.PclTimer;
using NUnit.Framework;

namespace Amoenus.PclTimerTests
{
    [TestFixture]
    public class CountUpTimerTests
    {
        [Test]
        [Category("Unit")]
        public void CountUpTimer_WhenProvidedWithTime_InitializesStopped()
        {
            // Arrange
            const int expectedTicks = 2;
            TimeSpan expectedSeconds = TimeSpan.FromSeconds(expectedTicks);

            // Act
            var classUnderTest = new CountUpTimer(expectedSeconds);

            // Assert
            Assert.That(classUnderTest.CurrentTime, Is.EqualTo(expectedSeconds));
            Assert.That(classUnderTest.IsTimerRunning, Is.False);
            Assert.That(classUnderTest.IsTimerStopped, Is.True);
        }

        [Test]
        [Category("Unit")]
        public void CountUpTimer_WhenStarted_CountsUpAndFiresEvent()
        {
            // Arrange
            const int expectedTicks = 2;
            TimeSpan startTime = TimeSpan.Zero;
            int actualTicks = 0;

            var classUnderTest = new CountUpTimer(startTime);
            classUnderTest.IntervalPassed += (o, e) => { actualTicks++; };

            // Act
            classUnderTest.Start();
            Thread.Sleep(TimeSpan.FromSeconds(expectedTicks * 2));
            // Assert
            Assert.That(classUnderTest.CurrentTime, Is.GreaterThan(startTime));
            Assert.That(actualTicks, Is.GreaterThan(expectedTicks));
        }
    }
}