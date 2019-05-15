using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using SampleFunctions.Data.Models;

namespace SampleFunctions.Triggers
{
    // Documentation Link: https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-queue#trigger
    // Can be one of CloudQueueMessage, string, byte[], or POCO (json only)
    // Poision queue support

    public static class QueueTriggerFn
    {
        [FunctionName("Q_OnNewQueueItem")]
        public static void OnNewQueueItem(
            [QueueTrigger("notification", Connection = "QueueConn")]string myQueueItem)
            //[QueueTrigger("notification", Connection = "QueueConn")]CloudQueueMessage myQueueItem)
            //[QueueTrigger("notification", Connection = "QueueConn")]Student student)
        {
            //throw new InvalidOperationException("fail!");
        }
    }
}
