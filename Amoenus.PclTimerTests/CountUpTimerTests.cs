using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Amoenus.PclTimer;
using NUnit.Framework;

namespace Amoenus.PclTimerTests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class CountUpTimerTests
    {
        [Test]
        [Category("Unit")]
        public void CountUpTimer_WhenStarted_CountsUpAndFiresEvent()
        {
            // Arrange
            const int ExpectedTicks = 2;
            TimeSpan startTime = TimeSpan.Zero;
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
            TimeSpan expectedSeconds = TimeSpan.FromSeconds(ExpectedTicks);

            // Act
            var classUnderTest = new CountUpTimer(expectedSeconds);

            // Assert
            Assert.That(classUnderTest.CurrentTime, Is.EqualTo(expectedSeconds));
            Assert.That(classUnderTest.IsTimerRunning, Is.False);
            Assert.That(classUnderTest.IsTimerStopped, Is.True);
        }
    }
}
