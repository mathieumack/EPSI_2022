using Azure.Messaging.ServiceBus;
using System;
using System.Threading.Tasks;

namespace Sample.POO.Core.abstractions
{
    public interface IServiceBusReceiverService
    {
        /// <summary>
        /// Start a listener that will execute a code when a message will be received
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="onMessageReceived"></param>
        Task StartListener(string queueName,
                            Func<ProcessMessageEventArgs, Task> onMessageReceived,
                            Func<ProcessErrorEventArgs, Task> onProcessMessageErro);
    }
}
