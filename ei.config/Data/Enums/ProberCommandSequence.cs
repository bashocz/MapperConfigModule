using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public enum ProberCommandSequence
    {
        [EnumDescription("Profile, align")]
        ProfileAlign = 0,
        [EnumDescription("Align, profile")]
        AlignProfile,
        [EnumDescription("Align, profile, align")]
        AlignProfileAlign,
    }
}
