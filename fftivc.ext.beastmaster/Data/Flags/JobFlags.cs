using System;

namespace fftivc.ext.beastmaster.Data.Flags
{
    [Flags]
    public enum JobFlags1
    {
        Squire          = 1 << 7,
        Chemist         = 1 << 6,
        Knight          = 1 << 5,
        Archer          = 1 << 4,
        WhiteMage       = 1 << 3,
        BlackMage       = 1 << 2,
        Monk            = 1 << 1,
        Thief           = 1 << 0
    }

    [Flags]
    public enum JobFlags2
    {
        Mystic          = 1 << 7,
        TimeMage        = 1 << 6,
        Geomancer       = 1 << 5,
        Dragoon         = 1 << 4,
        Orator          = 1 << 3,
        Summoner        = 1 << 2,
        Samurai         = 1 << 1,
        Ninja           = 1 << 0
    }

    [Flags]
    public enum JobFlags3
    {
        Arithmetician   = 1 << 7,
        Dancer          = 1 << 6,
        Bard            = 1 << 5,
        Mime            = 1 << 4,
        _Unused1        = 1 << 3,
        _Unused2        = 1 << 2,
        _Unused3        = 1 << 1,
        _Unused4        = 1 << 0,
    }
}
