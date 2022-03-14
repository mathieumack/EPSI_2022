using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sample.POO.Core.abstractions;
using Sample.POO.Core.Domain;
using System.Threading.Tasks;

namespace Sample.POO.Services.SendMessagesServices
{
    public class RequestStorageQuantityService : ServiceBusClientSenderService, IRequestStorageQuantityService
    {
        public RequestStorageQuantityService(ServiceBusClient client, 
                                                ILogger<ServiceBusClientSenderService> logger) 
            : base(client, logger)
        {
        }

        /// <inheritdoc/>
        public async Task RequestForQuantity(StorageReferenceRequest storageReference)
        {
            await base.SendMessage("quantityrequests", JsonConvert.SerializeObject(storageReference));
        }
    }
}
