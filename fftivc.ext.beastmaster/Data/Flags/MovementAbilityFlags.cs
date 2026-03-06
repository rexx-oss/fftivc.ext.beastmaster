using System;

namespace fftivc.ext.beastmaster.Data.Flags
{
    [Flags]
    public enum MovementAbilityFlags1 : byte
    {
        MovementPlus1       = 0x1 << 7,
        MovementPlus2       = 0x1 << 6,
        MovementPlus3       = 0x1 << 5,
        JumpPlus1           = 0x1 << 4,
        JumpPlus2           = 0x1 << 3,
        JumpPlus3           = 0x1 << 2,
        IgnoreElevation     = 0x1 << 1,
        Lifefont            = 0x1 << 0
    }

    [Flags]
    public enum MovementAbilityFlags2 : byte
    {
        Manafont            = 0x1 << 7,
        AccrueEXP           = 0x1 << 6,
        AccrueJP            = 0x1 << 5,
        CannotEnterWater    = 0x1 << 4,
        Teleport            = 0x1 << 3,
        MasterTeleportation = 0x1 << 2,
        IgnoreWeather       = 0x1 << 1,
        IgnoreTerrain       = 0x1 << 0
    }

    [Flags]
    public enum MovementAbilityFlags3 : byte
    {
        Waterwalking        = 0x1 << 7,
        Swim                = 0x1 << 6,
        Lavawalking         = 0x1 << 5,
        Waterbreathing      = 0x1 << 4,
        Levitate            = 0x1 << 3,
        Fly                 = 0x1 << 2,
        SilentWalk          = 0x1 << 1,
        TreasureHunter      = 0x1 << 0
    }
}
