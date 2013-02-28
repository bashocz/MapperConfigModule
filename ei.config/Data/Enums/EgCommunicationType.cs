using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Determines possible types of connection between Mapper and EG prober.
    /// </summary>
    public enum EgCommunicationType
    {
        /// <summary>
        /// Communication type is unknown.
        /// </summary>
        None = 0,

        /// <summary>
        /// Communication over serial port.
        /// </summary>
        Serial = 1,

        /// <summary>
        /// Communication over GPIB.
        /// </summary>
        GPIB = 2,
    }
}
