using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sample.POO.Core.abstractions;
using Sample.POO.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Sample.POO.Services.SendMessagesServices
{
    public class SendStorageQuantityService : ServiceBusClientSenderService, ISendStorageQuantityService
    {
        private readonly Random random = new Random();

        public SendStorageQuantityService(ServiceBusClient client,
                                                ILogger<ServiceBusClientSenderService> logger)
            : base(client, logger)
        {
        }

        /// <inheritdoc/>
        public async Task SendStorageQuantity(StorageReferenceRequest storageReference)
        {
            var quantity = new StorageReferenceResponse()
            {
                Reference = storageReference.Reference,
                Quantity = random.Next(10, 2000)
            };
            await base.SendMessage("quantityanswers", JsonConvert.SerializeObject(quantity));
        }
    }
}
