using Sample.POO.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Sample.POO.Core.abstractions
{
    public interface ITruckEventListenerService
    {
        /// <summary>
        /// Wait for storage listener events
        /// </summary>
        /// <param name="onEventReceived"></param>
        /// <returns></returns>
        Task StartListener(Action<TruckEvent> onEventReceived);
    }
}
