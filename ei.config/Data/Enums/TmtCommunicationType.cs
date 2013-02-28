using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Determines possible types of connection between Eagle tester and a prober.
    /// </summary>
    public enum TmtCommunicationType
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
        /// Communication over TCP/IP.
        /// </summary>
        TCPIP = 2,
    }
}
