using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SampleFunctions.Triggers
{
    public static class BlobTriggerFn
    {
        // Documentation Link: https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob#trigger
        // Can be one of Stream, TextReader, string, Byte[], CloudBlockBlob

        [FunctionName("B_OnNewFile")]
        public static void OnNewFile(
            [BlobTrigger("input-files/{name}", Connection = "StorageAccountConn")]Stream myBlob
            //[BlobTrigger("input-files/{name}", Connection = "StorageAccountConn")]CloudBlockBlob myBlob
            //[BlobTrigger("input-files/{name}.txt", Connection = "StorageAccountConn")]string smallFileContents
            , string name)
        {
            // Breakpoint
        }

        // EventGrid -- a better way to trigger from blob!
        // If time, bounce out to portal to set this up
    }
}
