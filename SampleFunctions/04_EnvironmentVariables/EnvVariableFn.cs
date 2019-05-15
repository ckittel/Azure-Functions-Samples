using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace SampleFunctions.EnvironmentVariables
{
    public static class EnvVariableFn
    {
        [FunctionName("H_GetCfgValue")]
        public static string GetCfgValue(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "configValue")] HttpRequest req)
        {
            var cfgValue = Environment.GetEnvironmentVariable("MyConfigValue");
            return cfgValue;
        }
    }
}
