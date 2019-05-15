using Microsoft.Azure.WebJobs;
using SampleFunctions.Data.Models;
using SendGrid.Helpers.Mail;

namespace SampleFunctions.OutputBindings
{
    public static class PushToSendGridFn
    {
        [FunctionName("Q_SendOrderMail_SG")]
        [return: SendGrid(ApiKey = "SendGridApiKey", To = "{CustomerEmail}", From = "order-processing@example.org")]
        public static SendGridMessage SendEmail([QueueTrigger("orders", Connection = "QueueConn")]Order order)
        {
            return new SendGridMessage()
            {
                Subject = $"Thanks for your order (#{order.OrderId})!",
                PlainTextContent = $"Thank you {order.CustomerName} for your order ({order.OrderId}).  We'll ship it soon.",
            };
        }
    }
    /// https://www.mailinator.com/
    /// 
    /// {
    ///    "orderId": "0001",
    ///    "customerName": "Sara",
    ///    "customerEmail": "fn-demo-01@mailinator.com"
    /// }
    /// 
}
