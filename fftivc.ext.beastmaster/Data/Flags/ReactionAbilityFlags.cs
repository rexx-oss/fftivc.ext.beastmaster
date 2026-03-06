using System;

namespace fftivc.ext.beastmaster.Data.Flags
{
    [Flags]
    public enum ReactionAbilityFlags1 : byte
    {
        StrengthSurge   = 0x1 << 7,
        MagickSurge     = 0x1 << 6,
        SpeedSurge      = 0x1 << 5,
        Vanish          = 0x1 << 4,
        Vigilance       = 0x1 << 3,
        Dragonheart     = 0x1 << 2,
        Regenerate      = 0x1 << 1,
        BraverySurge    = 0x1 << 0
    }

    [Flags]
    public enum ReactionAbilityFlags2 : byte
    {
        FaithSurge = 0x1 << 7,
        CriticalRecoverHP = 0x1 << 6,
        CriticalRecoverMP = 0x1 << 5,
        CriticalQuick = 0x1 << 4,
        Bonecrusher = 0x1 << 3,
        MagickCounter = 0x1 << 2,
        CounterTackle = 0x1 << 1,
        NaturesWrath = 0x1 << 0
    }

    [Flags]
    public enum ReactionAbilityFlags3 : byte
    {
        AbsorbMP = 0x1 << 7,
        GilSnapper = 0x1 << 6,
        Reflect = 0x1 << 5,
        AutoPotion = 0x1 << 4,
        Counter = 0x1 << 3,
        _Unused = 0x1 << 2,
        CupOfLife = 0x1 << 1,
        ManaShield = 0x1 << 0
    }

    [Flags]
    public enum ReactionAbilityFlags4 : byte
    {
        Soulbind = 0x1 << 7,
        Parry = 0x1 << 6,
        Earplugs = 0x1 << 5,
        Reflexes = 0x1 << 4,
        StickyFingers = 0x1 << 3,
        Shirahadori = 0x1 << 2,
        ArchersBane = 0x1 << 1,
        FirstStrike = 0x1 << 0
    }
}
