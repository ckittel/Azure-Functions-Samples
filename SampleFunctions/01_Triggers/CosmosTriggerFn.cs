using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace SampleFunctions.Triggers
{
    public static class CosmosTriggerFn
    {
        // Documentation Link: https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-cosmosdb-v2#trigger

        [FunctionName("C_OnContainerChange")]
        public static void OnContainerChange([CosmosDBTrigger(
            databaseName: "school",
            collectionName: "students",
            ConnectionStringSetting = "CosmosDbConn")]IReadOnlyList<Document> input
            , ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }
        }
    }
}
