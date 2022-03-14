using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sample.POO.Core.abstractions;
using Sample.POO.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Sample.POO.Services.SendMessagesServices
{
    public class TruckEventService : ServiceBusClientSenderService, ITruckEventService
    {
        public TruckEventService(ServiceBusClient client,
                                    ILogger<ServiceBusClientSenderService> logger)
            : base(client, logger)
        {
        }

        /// <inheritdoc/>
        public async Task NewTruckArrived()
        {
            logger.LogInformation("Truc arrived.");
            var truckEvent = new TruckEvent()
            {
                EventType = "Arrived"
            };
            await base.SendMessage("truckevents", JsonConvert.SerializeObject(truckEvent));
        }

        /// <inheritdoc/>
        public async Task TruckLeaved()
        {
            logger.LogInformation("Truc leaves the factory.");
            var truckEvent = new TruckEvent()
            {
                EventType = "Leave"
            };
            await base.SendMessage("truckevents", JsonConvert.SerializeObject(truckEvent));
        }
    }
}
