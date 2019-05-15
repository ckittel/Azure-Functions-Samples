using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace SampleFunctions.Triggers
{
    // Documentation Link: https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-timer#attributes
    // Cron Expression: https://en.wikipedia.org/wiki/Cron#CRON_expression
    // Timer is from start time (example is every time that is div by 5)

    public static class TimerTriggerFn
    {
        [FunctionName("T_OnTick")]
        public static void OnTimerTick(
            [TimerTrigger("0 */5 * * * *" /*, handy for debug not great for prod RunOnStartup = true */)]TimerInfo myTimer
            , ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.UtcNow}\n" +
                               $"and next occurances will be at {myTimer.FormatNextOccurrences(5)}");
        }
    }
}
