using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sample.POO.Core.abstractions;
using Sample.POO.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Sample.POO.Services.ReceiveMessagesServices
{
    public class TruckEventListenerService : ServiceBusReceiverService, ITruckEventListenerService
    {
        private Action<TruckEvent> onEventReceived;

        public TruckEventListenerService(ServiceBusClient client, 
                                                        ILogger<ServiceBusReceiverService> logger)
            : base(client, logger)
        {
        }

        public async Task StartListener(Action<TruckEvent> onEventReceived)
        {
            this.onEventReceived = onEventReceived;
            await base.StartListener("truckevents", ProcessMessagesAsync, ProcessErrorAsync);
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
            var truckEvent = JsonConvert.DeserializeObject<TruckEvent>(request);

            // Complete message to remove it from service bus queue
            await args.CompleteMessageAsync(args.Message);

            // Call action as we have receive a new truck event
            onEventReceived(truckEvent);

            logger.LogInformation("End processing message.");
        }
    }
}
