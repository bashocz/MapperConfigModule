using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public enum InkingMode
    {
        [EnumDescription("Standard inking mode")]
        Standard = 0,
        [EnumDescription("Inking according to control map")]
        ControlMap,
        [EnumDescription("Inking in manual step")]
        ManualStep,
        [EnumDescription("External inking mode")]
        External,
    }
}