using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public enum FileFormat
    {
        [EnumDescription("No file")]
        NoFile = 0x00,
        [EnumDescription("Wafer map file in SECSII format")]
        Secs = 0x01,
        [EnumDescription("Wafer map file in xml format")]
        Xml = 0x02,
        [EnumDescription("Wafer map file in zipped xml format")]
        Zip = 0x04,
    }
}
