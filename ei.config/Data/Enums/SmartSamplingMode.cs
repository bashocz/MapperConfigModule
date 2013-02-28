using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public enum SmartSamplingMode
    {
        [EnumDescription("Standard mode")]
        Standard = 0,
        [EnumDescription("SBN mode")]
        Sbn,
        [EnumDescription("OSPI mode")]
        Ospi,
    }
}