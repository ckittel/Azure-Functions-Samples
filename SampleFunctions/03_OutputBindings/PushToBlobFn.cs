using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using SampleFunctions.Data.Models;
using System.IO;
using System.Threading.Tasks;

namespace SampleFunctions.OutputBindings
{
    public static class PushToBlobFn
    {
        // Shows digging into a property to use as a value to blob output

        [FunctionName("Q_AddToArchive_B")]
        public static void AddToArchive(
            [QueueTrigger("orders-archive", Connection = "QueueConn")]Order order,
            [Blob("order-archive/{orderId}.json", FileAccess.Write, Connection = "StorageAccountConn")] out string orderBlobText)
        {
            orderBlobText = JsonConvert.SerializeObject(order);
        }

        /// {
        ///    "orderId": "0001",
        ///    "customerName": "Abby",
        ///    "customerEmail": "anything@anything.com"
        /// }

        // If you need a bit more control...
        //[FunctionName("Q_AddToArchive_B")]
        //public static async Task AddToArchiveAsync(
        //    [QueueTrigger("orders-archive", Connection = "QueueConn")]Order order,
        //    [Blob("order-archive/{orderId}.json", FileAccess.ReadWrite, Connection = "StorageAccountConn")] CloudBlockBlob orderBlob)
        //{
        //    orderBlob.Properties.ContentType = "application/json";
        //    orderBlob.Properties.CacheControl = "public, max-age=31536000";
        //    orderBlob.Properties.ContentDisposition = "attachment";
        //    await orderBlob.UploadTextAsync(JsonConvert.SerializeObject(order));
        //}



    }
}
