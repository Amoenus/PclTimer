using NUnit.Framework;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Amoenus.PclTimer;

namespace Amoenus.PclTimerTests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class CountDownTimerTests
    {
        [Test]
        [Category("Unit")]
        public void CountDownTimer_WhenStarted_CountsDownAndFiresEvent()
        {
            // Arrange
            const int expectedTicks = 2;
            TimeSpan expectedSeconds = TimeSpan.FromSeconds(expectedTicks);
            var actualTicks = 0;

            var classUnderTest = new CountDownTimer(expectedSeconds);
            classUnderTest.IntervalPassed += (o, e) => { actualTicks++; };

            // Act
            classUnderTest.Start();
            Thread.Sleep(TimeSpan.FromSeconds(expectedTicks * 2));
            // Assert
            Assert.That(classUnderTest.CurrentTime, Is.LessThan(expectedSeconds));
            Assert.That(actualTicks, Is.GreaterThan(expectedTicks));
        }

        [Test]
        [Category("Unit")]
        public void CountDownTimer_WhenProvidedWithTime_InitialisesStopped()
        {
            // Arrange
            const int expectedTicks = 2;
            TimeSpan expectedSeconds = TimeSpan.FromSeconds(expectedTicks);

            // Act
            var classUnderTest = new CountDownTimer(expectedSeconds);

            // Assert
            Assert.That(classUnderTest.CurrentTime, Is.EqualTo(expectedSeconds));
            Assert.That(classUnderTest.IsTimerRunning, Is.False);
            Assert.That(classUnderTest.IsTimerStopped, Is.True);
        }
    }
}
