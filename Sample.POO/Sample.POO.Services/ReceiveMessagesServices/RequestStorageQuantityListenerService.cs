using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sample.POO.Core.abstractions;
using Sample.POO.Core.Domain;
using System.Threading.Tasks;

namespace Sample.POO.Services.ReceiveMessagesServices
{
    public class RequestStorageQuantityListenerService : ServiceBusReceiverService, IRequestStorageQuantityListenerService
    {
        private readonly ISendStorageQuantityService sendStorageQuantityService;

        public RequestStorageQuantityListenerService(ServiceBusClient client, 
                                                        ILogger<ServiceBusReceiverService> logger,
                                                        ISendStorageQuantityService sendStorageQuantityService)
            : base(client, logger)
        {
            this.sendStorageQuantityService = sendStorageQuantityService;
        }

        public async Task StartListener()
        {
            await base.StartListener("quantityrequests", ProcessMessagesAsync, ProcessErrorAsync);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Task ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            logger.LogError(arg.Exception, "Message handler encountered an exception");
            logger.LogDebug($"- ErrorSource: {arg.ErrorSource}");
            logger.LogDebug($"- Entity Path: {arg.EntityPath}");
            logger.LogDebug($"- FullyQualifiedNamespace: {arg.FullyQualifiedNamespace}");

            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual async Task ProcessMessagesAsync(ProcessMessageEventArgs args)
        {
            logger.LogInformation("Start processing new storage request.");

            var request = args.Message.Body.ToString();
            var requestQuantity = JsonConvert.DeserializeObject<StorageReferenceRequest>(request);

            // Complete message to remove it from Servicebus queue
            await args.CompleteMessageAsync(args.Message);

            // Send result
            await sendStorageQuantityService.SendStorageQuantity(requestQuantity);

            logger.LogInformation("End processing message.");
        }
    }
}
