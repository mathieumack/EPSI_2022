using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Sample.POO.Core.abstractions;
using System;
using System.Threading.Tasks;

namespace Sample.POO.Services
{
    public class ServiceBusReceiverService : IServiceBusReceiverService
    {
        private readonly ServiceBusClient client;
        private ServiceBusProcessor processor;
        protected readonly ILogger<ServiceBusReceiverService> logger;

        public ServiceBusReceiverService(ServiceBusClient client,
                                            ILogger<ServiceBusReceiverService> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task StartListener(string queueName, 
                                        Func<ProcessMessageEventArgs, Task> onMessageReceived,
                                        Func<ProcessErrorEventArgs, Task> onProcessMessageError)
        {
            var serviceBusProcessorOptions = new ServiceBusProcessorOptions
            {
                MaxConcurrentCalls = 1,
                AutoCompleteMessages = false
            };

            processor = client.CreateProcessor(queueName, serviceBusProcessorOptions);
            processor.ProcessMessageAsync += onMessageReceived;
            processor.ProcessErrorAsync += onProcessMessageError;
            await processor.StartProcessingAsync();
        }
    }
}
