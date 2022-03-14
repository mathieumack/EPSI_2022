using System;
using System.Threading.Tasks;

namespace Sample.POO.Core.abstractions
{
    public interface IServiceBusClientSenderService
    {
        /// <summary>
        /// Send a message on a queue
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="messageBody"></param>
        /// <returns></returns>
        Task SendMessage(string queueName, string messageBody);
    }
}
