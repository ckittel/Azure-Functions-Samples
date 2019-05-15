using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;

namespace SampleFunctions.OutputBindings
{
    public static class PushToQueueFn
    {
        [FunctionName("H_AddMessageToQueue_Q")]
        [return: Queue("messages", Connection = "QueueConn")]
        public static Msg AddToQueue(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "messages")] string message)
        {
            return new Msg
            {
                Text = message,
                CreatedAt = DateTime.UtcNow
            };
        }

        public class Msg
        {
            public DateTimeOffset CreatedAt { get; set; }
            public string Text { get; set; }
        }
    }
}
