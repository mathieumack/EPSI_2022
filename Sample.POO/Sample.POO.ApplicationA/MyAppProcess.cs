using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.POO.Core.abstractions;

namespace Sample.POO.ApplicationA
{
    public class MyAppProcess : BackgroundService
    {
        private readonly ILogger<MyAppProcess> logger;
        private readonly ITruckEventService truckEventService;
        private readonly IRequestStorageQuantityListenerService requestStorageQuantityListenerService;

        public MyAppProcess(ILogger<MyAppProcess> logger,
                            ITruckEventService truckEventService,
                            IRequestStorageQuantityListenerService requestStorageQuantityListenerService)
        {
            this.logger = logger;
            this.truckEventService = truckEventService;
            this.requestStorageQuantityListenerService = requestStorageQuantityListenerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await requestStorageQuantityListenerService.StartListener();

            // Next we will send truck notifications avery x seconds
            var random = new Random();
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                //Send a truck notification :
                if (i % 2 == 0)
                    await truckEventService.NewTruckArrived();
                else
                    await truckEventService.TruckLeaved();

                await Task.Delay(TimeSpan.FromSeconds(random.Next(2, 5)));
                i++;
            }
        }
    }
}
