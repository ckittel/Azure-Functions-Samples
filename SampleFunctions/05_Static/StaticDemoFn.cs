using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace SampleFunctions._05_Static
{
    public static class StaticDemoFn
    {
        /// DANGER:  While you CAN share state it is TRANSIENT and 
        /// will be removed when the role is restarted.  It is shared
        /// amungst all functions as well, so threading access issues 
        /// are possible.  Only use thread-safe code when doing this.
        
        public class CallCounter
        {
            public int Route1 = 0;
            public int Route2 = 0;
        }

        private readonly static CallCounter CallState = new CallCounter();
        
        [FunctionName("H_GetStaticState1")]
        public static CallCounter GetStaticState1(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "static/1")] HttpRequest req)
        {
            Interlocked.Increment(ref CallState.Route1);
            return CallState;
        }

        [FunctionName("H_GetStaticState2")]
        public static CallCounter GetStaticState2(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "static/2")] HttpRequest req)
        {
            Interlocked.Increment(ref CallState.Route2);
            return CallState;

        }
    }
}
