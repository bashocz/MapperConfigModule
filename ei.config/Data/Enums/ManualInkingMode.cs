using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public enum ManualInkingMode
    {
        [EnumDescription("All dice")]
        AllDice = 0,
        [EnumDescription("Failed dice")]
        FailedDice,
        [EnumDescription("Passed dice")]
        PassedDice,
    }
}