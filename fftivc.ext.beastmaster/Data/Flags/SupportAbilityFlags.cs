using System;

namespace fftivc.ext.beastmaster.Data.Flags
{
    [Flags]
    public enum SupportAbilityFlags1 : byte
    {
        EquipHeavyArmor     = 0x1 << 7,
        EquipShields        = 0x1 << 6,
        EquipSwords         = 0x1 << 5,
        EquipKatana         = 0x1 << 4,
        EquipCrossbows      = 0x1 << 3,
        EquipPolearms       = 0x1 << 2,
        EquipAxes           = 0x1 << 1,
        EquipGuns           = 0x1 << 0
    }

    [Flags]
    public enum SupportAbilityFlags2 : byte
    {
        HalveMP             = 0x1 << 7,
        JPBoost             = 0x1 << 6,
        EXPBoost            = 0x1 << 5,
        AttackBoost         = 0x1 << 4,
        DefenseBoost        = 0x1 << 3,
        MagickBoost         = 0x1 << 2,
        MagickDefenseBoost  = 0x1 << 1,
        Concentration       = 0x1 << 0
    }

    [Flags]
    public enum SupportAbilityFlags3 : byte
    {
        Tame                = 0x1 << 7,
        Poach               = 0x1 << 6,
        Brawler             = 0x1 << 5,
        BeastTongue         = 0x1 << 4,
        ThrowItems          = 0x1 << 3,
        Safeguard           = 0x1 << 2,
        Doublehand          = 0x1 << 1,
        DualWield           = 0x1 << 0
    }

    [Flags]
    public enum SupportAbilityFlags4 : byte
    {
        Beastmaster         = 0x1 << 7,
        EvasiveStance       = 0x1 << 6,
        Reequip             = 0x1 << 5,
        _Unused1            = 0x1 << 4,
        Swiftspell          = 0x1 << 3,
        NonCharge           = 0x1 << 2,
        _Unused2            = 0x1 << 1,
        _Unused3            = 0x1 << 0
    }
}
