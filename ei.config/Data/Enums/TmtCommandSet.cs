using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Determines command set Eagle tester uses to communicate with a prober.
    /// </summary>
    public enum TmtCommandSet
    {
        /// <summary>
        /// Command set is unknown.
        /// </summary>
        None = 0,

        /// <summary>
        /// Electroglas Enhanced Mode command set. Applies for EG2001X and EG4090X probers.
        /// </summary>
        EG = 1,

        /// <summary>
        /// ETI command set. Applies for GSI probers.
        /// </summary>
        ETI = 2,

        
    }
}
