
// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.POO.ApplicationA;
using Sample.POO.Core.abstractions;
using Sample.POO.Services.ReceiveMessagesServices;
using Sample.POO.Services.SendMessagesServices;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = new HostBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true);
                config.AddEnvironmentVariables();

                if (args != null)
                {
                    config.AddCommandLine(args);
                }
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddOptions();

                // Init a servicebus client :
                services.AddSingleton(serviceProvider =>
                {
                    var sbOptions = new ServiceBusClientOptions()
                    {
                        RetryOptions = new ServiceBusRetryOptions()
                        {
                            Mode = ServiceBusRetryMode.Exponential,
                            Delay = TimeSpan.FromSeconds(10),
                            MaxRetries = 5
                        }
                    };

                    var connectionString = "Put your servicebus accesskey key here";

                    var client = new ServiceBusClient(connectionString,
                                                        sbOptions);
                    return client;
                });

                // Register business services :
                services.AddSingleton<ISendStorageQuantityService, SendStorageQuantityService>();
                services.AddSingleton<IRequestStorageQuantityListenerService, RequestStorageQuantityListenerService>();
                services.AddSingleton<ITruckEventService, TruckEventService>();

                // Register background task (my app)
                services.AddSingleton<IHostedService, MyAppProcess>();
            })
            .ConfigureLogging((hostingContext, logging) => {
                logging.AddConsole();
            });

        await builder.RunConsoleAsync();
    }
}
