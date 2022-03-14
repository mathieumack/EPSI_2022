using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Sample.POO.ApplicationC
{
    public static class MyFunction
    {
        [FunctionName("MyFunction")]
        public static void Run([ServiceBusTrigger("myqueue", Connection = "ServiceBusCnnString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
