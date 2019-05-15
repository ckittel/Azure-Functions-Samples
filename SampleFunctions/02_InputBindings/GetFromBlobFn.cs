using System;
using System.IO;
using Microsoft.Azure.WebJobs;

namespace SampleFunctions.InputBindings
{
    public static class GetFromBlobFn
    {
        [FunctionName("Q_B_ReadBlobFile")]
        public static void Run(
            [QueueTrigger("toprocess", Connection = "QueueConn")]string myQueueItem,
            [Blob("input-files/{queueTrigger}", FileAccess.Read)] string fileContents)
        {
            // DO SOMETHING WITH THIS 
        }

        // So, Read -> ReadWrite?
        //[FunctionName("Q_B_ReadBlobFile_B")]
        //public static void Run(
        //    [QueueTrigger("toprocess", Connection = "QueueConn")]string myQueueItem,
        //    [Blob("input-files/{queueTrigger}", FileAccess.ReadWrite)] out string fileContents)
        //{
        //    fileContents = DateTime.UtcNow.ToString("u");
        //    // DO SOMETHING WITH THIS 
        //}
    }
}
