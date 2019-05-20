using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SampleFunctions.Di
{
    // https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection

    public class ExampleWithDiFn
    {
        private readonly IMyClass _myClass;

        public ExampleWithDiFn(IMyClass myClass)
        {
            _myClass = myClass;
        }

        [FunctionName("H_ExampleWithDiFn")]
        public string GetMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "dimessage")] HttpRequest req,
            ILogger log)
        {
            return _myClass.GetMessage();
        }
    }
}
