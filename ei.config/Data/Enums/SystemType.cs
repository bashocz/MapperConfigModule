using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public enum SystemType
    {
        [EnumDescription("Unknown system")]
        Unknown,
        [EnumDescription("Prober")]
        Prober,
        [EnumDescription("Inker")]
        Inker,
    }
}
