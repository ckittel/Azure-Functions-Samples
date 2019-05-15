using FluentAssertions;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleFunctions.Triggers;

namespace SampleFunctions.Tests
{
    [TestClass]
    public class TimerTriggerFnTests
    {
        [TestMethod]
        public void When_TimerTriggerFires_Then_LogHappens()
        {
            // Arrange
            var logger = TestFactory.CreateLogger();
            var timerInfo = new TimerInfo(TestFactory.CreateTimerSchedule(5), new ScheduleStatus());

            // Act
            TimerTriggerFn.OnTimerTick(timerInfo, logger);

            // Assert
            logger.Logs.Should().HaveCount(1);
            logger.Logs[0].Should().Match("C# Timer trigger function executed at: *\nand next occurances will be at *");
        }
    }
}
