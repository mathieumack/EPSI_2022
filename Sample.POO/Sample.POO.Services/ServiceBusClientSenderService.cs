using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Sample.POO.Core.abstractions;
using System;
using System.Threading.Tasks;

namespace Sample.POO.Services
{
    public abstract class ServiceBusClientSenderService : IServiceBusClientSenderService
    {
        private readonly ServiceBusClient client;
        protected readonly ILogger<ServiceBusClientSenderService> logger;

        public ServiceBusClientSenderService(ServiceBusClient client, 
                                        ILogger<ServiceBusClientSenderService> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        /// <inheritdoc/>
        public async Task SendMessage(string queueName, string messageBody)
        {
            try
            {
                logger.LogInformation($"Send message to queue {queueName}.");

                var sender = client.CreateSender(queueName);

                var message = new ServiceBusMessage(messageBody);
                message.ContentType = "application/json";

                await sender.SendMessageAsync(message);

                logger.LogInformation($"Message created on queue {queueName}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
