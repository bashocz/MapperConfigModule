using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public enum DrawPropertyType
    {
        WaferBackground = 0,
        WaferCircle = 1,
        WaferGrid = 2,
        NullDie = 3,
        SkipDie = 4,
        EdgeDie = 5,
        SampleDie = 6,
        UntestedDie = 7,
        GoodDie = 8,
        FailDie = 9,
        SelectedDie = 10,
        SelectedSite = 11,
        FirstSite = 12,
        OtherSite = 13,
        MapperVersion = 14,
        ProberId = 15,
        TesterId = 16,
        ProbingMode = 17,
        DefaultGoodDie = 18,
        DefaultFailDie = 19,
        InkFixedEdgeDie = 20,
        InkRadialEdgeDie = 21,
    }
}
