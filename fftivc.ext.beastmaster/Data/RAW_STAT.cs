using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace fftivc.ext.beastmaster.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly unsafe struct RAW_STAT : IEquatable<RAW_STAT>, IComparable<RAW_STAT>
    {
        private const uint _maxValue = 0x00FFFFFF;
        
        public static readonly RAW_STAT MaxValue = new (0xFF, 0xFF, 0xFF);
        public static readonly RAW_STAT MinValue = new (0x00, 0x00, 0x00);

        private readonly byte _b0;
        private readonly byte _b1;
        private readonly byte _b2;

        public static implicit operator uint(RAW_STAT self) => self.Value;
        public static implicit operator RAW_STAT(ushort u16) => new(u16);

        public RAW_STAT(byte b0, byte b1, byte b2)
        {
            _b0 = b0;
            _b1 = b1;
            _b2 = b2;
        }

        public RAW_STAT(uint value)
        {
            if (value > _maxValue)
                throw new ArgumentOutOfRangeException(nameof(value),
                    value,
                    $"Value {value:N0} must be between 0 and {_maxValue:N0} (inclusive).");

            _b0 = (byte)((value) & 0xFF);
            _b1 = (byte)((value >> 8) & 0xFF);
            _b2 = (byte)((value >> 16) & 0xFF);
        }

        public unsafe byte* Byte0 
        { 
            get 
            {
                fixed (byte* pByte0 = &_b0)
                    return pByte0; 
            }
        }

        public uint Value => (uint)(_b0 | (_b1 << 8) | (_b2 << 16));

        public override string ToString() => Value.ToString();
        public override int GetHashCode()
            => (_b0 | (_b1 << 8) | (_b2 << 16));

        public override bool Equals([NotNullWhen(true)] object obj)
            => obj is RAW_STAT other && Equals(other);

        public bool Equals(RAW_STAT other)
            => Value.Equals(other.Value);

        public int CompareTo(RAW_STAT other)
            => Value.CompareTo(other.Value);

        public static int Compare(RAW_STAT left, RAW_STAT right)
            => left.Value.CompareTo(right.Value);

        public static bool operator == (RAW_STAT left, RAW_STAT right)
            => left.Equals(right);

        public static bool operator != (RAW_STAT left, RAW_STAT right)
            => !left.Equals(right);

        public static bool operator > (RAW_STAT left, RAW_STAT right)
            => Compare(left, right) > 0;

        public static bool operator >= (RAW_STAT left, RAW_STAT right)
            => Compare(left, right) >= 0;

        public static bool operator < (RAW_STAT left, RAW_STAT right)
            => Compare(left, right) < 0;

        public static bool operator <= (RAW_STAT left, RAW_STAT right)
            => Compare(left, right) <= 0;
    }
}
