using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sample.POO.ApplicationB.ViewModels;
using Sample.POO.Core.abstractions;
using Sample.POO.Services.ReceiveMessagesServices;
using Sample.POO.Services.SendMessagesServices;
using System;
using System.Windows;

namespace Sample.POO.ApplicationB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(loggerBuilder =>
            {
                loggerBuilder.AddConsole();
            });

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
            services.AddSingleton<IRequestStorageQuantityService, RequestStorageQuantityService>();
            services.AddSingleton<ITruckEventListenerService, TruckEventListenerService>();
            services.AddSingleton<IStorageQuantityAnswerListenerService, StorageQuantityAnswerListenerService>();

            // Register viewmodels :
            services.AddTransient<SearchReferenceCommand>();
            services.AddTransient<MainWindowViewModel>();

            // Register main screen
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
