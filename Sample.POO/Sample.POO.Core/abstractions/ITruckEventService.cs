using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.POO.Core.abstractions
{
    public interface ITruckEventService
    {
        /// <summary>
        /// Called when a new truck arrived
        /// </summary>
        /// <returns></returns>
        Task NewTruckArrived();

        /// <summary>
        /// Called when a truck leave the factory
        /// </summary>
        /// <returns></returns>
        Task TruckLeaved();
    }
}
