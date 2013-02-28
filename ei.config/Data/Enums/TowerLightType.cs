using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    [Flags]
    public enum TowerLightType
    {
        [EnumDescription("Tower light off")]
        Off = 0x0000,
        [EnumDescription("Tower light controlled via prober")]
        ProberControlled,
        [EnumDescription("Tower light controlled via parallel port")]
        LptControlled,
    }
}
