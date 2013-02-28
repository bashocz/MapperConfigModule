using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    [Flags]
    public enum ConfigType
    {
        [EnumDescription("None of configuration")]
        None = 0x0000,
        [EnumDescription("Mapper configuration")]
        Mapper = 0x0001,
        [EnumDescription("User configuration")]
        User = 0x0002,
        [EnumDescription("Mapper and user configuration")]
        MapperUser = Mapper | User,
        [EnumDescription("Lot configuration")]
        Lot = 0x0004,
        [EnumDescription("User and lot configuration")]
        UserLot = User | Lot,
        [EnumDescription("Mapper, user and lot configuration")]
        MapperUserLot = Mapper | User | Lot,
        [EnumDescription("All configuration")]
        All = 0xFFFF,
    }
}
