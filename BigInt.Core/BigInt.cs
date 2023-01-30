using BigInt.Core.Models;

using System;
using System.Drawing;

namespace BigInt.Core
{
    public sealed class BigInt : IComparable<BigInt>, ICloneable
    {
        internal Data Data { get; set; }

        public byte[] GetBits => Data.Bits;
        public bool IsNegative => Data.Signed;
        public int GetSize => Data.Size;

        public override string ToString()
        {
            return IsNegative ? "-" + string.Join("", GetBits.Select(x => (char)x).Reverse()) : string.Join("", GetBits.Select(x => (char)x).Reverse());
        }

        public BigInt(long source) => Data = CreateFromLong(source);

        public BigInt(int source) => Data = CreateFromInt(source);

        public BigInt(uint source) => Data = CreateFromUInt(source);

        public BigInt(ulong source) => Data = CreateFromULong(source);

        internal BigInt(Data source) => Data = source;

        public BigInt(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException(nameof(source));
            var signed = false;
            if (source.First() is '-')
            {
                signed = true;
                source = source[1..];
            }
            if (source.First() is '+')
            {
                source = source[1..];
            }
            source = string.Join("", source.SkipWhile(x => x == '0'));
            if (!source.All(x => char.IsDigit(x)))
                throw new ArgumentException("Incorrect format", nameof(source));
            Data = source != "" ? CreateFromString(source, signed) : CreateFromNumber(0, false);
        }

        private Data CreateFromNumber(ulong source, bool signed)
        {
            var bits = source.ToString().ToCharArray().Select(c => (byte)c).Reverse().ToArray();
            return new Data(bits, bits.Length, signed);
        }

        private Data CreateFromString(string source, bool signed)
        {
            var bits = source.ToCharArray().Select(c => (byte)c).Reverse().ToArray();
            return new Data(bits, bits.Length, signed);
        }

        private Data CreateFromInt(int source)
        {
            var signed = source < 0;
            if (signed)
                source *= -1;
            return CreateFromNumber((ulong)source, signed);
        }

        private Data CreateFromLong(long source)
        {
            var signed = source < 0;
            if (signed)
                source *= -1;
            return CreateFromNumber((ulong)source, signed);
        }

        private Data CreateFromUInt(uint source) => CreateFromNumber(source, false);

        private Data CreateFromULong(ulong source) => CreateFromNumber(source, false);

        public int CompareByAbsTo(BigInt? other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));
            if (GetSize > other.GetSize)
                return 1;
            if (other.GetSize > GetSize)
                return -1;
            for (var i = GetSize - 1; i >= 0; i--)
            {
                if (GetBits[i] > other.GetBits[i])
                    return 1;
                if (other.GetBits[i] > GetBits[i])
                    return -1;
            }
            return 0;
        }

        public int CompareTo(BigInt? other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));
            if(!Data.Signed && !other.Data.Signed)
                return CompareByAbsTo((BigInt?)other);
            if (!Data.Signed && other.Data.Signed)
                return 1;
            if (Data.Signed && !other.Data.Signed)
                return -1;
            return CompareByAbsTo((BigInt?)other) * -1;
        }

        public object Clone()
        {
            return new BigInt(new Data((byte[])GetBits.Clone(), GetSize, IsNegative));
        }

        public bool IsZero => Data.Bits[0] == '0' && GetSize == 1;

        public static implicit operator BigInt(ulong data) => new BigInt(data);

        public static implicit operator BigInt(long data) => new BigInt(data);

        public static implicit operator BigInt(uint data) => new BigInt(data);

        public static implicit operator BigInt(int data) => new BigInt(data);

        public static implicit operator BigInt(string data) => new BigInt(data);

        public static BigInt operator +(BigInt left, BigInt right)
        {
            return BigIntOperations.Add(left, right);
        }

        public static BigInt operator -(BigInt left, BigInt right)
        {
            return BigIntOperations.Sub(left, right);
        }

        public static BigInt operator *(BigInt left, BigInt right)
        {
            return BigIntOperations.Mul(left, right);
        }

        public static BigInt operator /(BigInt left, BigInt right)
        {
            return BigIntOperations.Div(left, right);
        }

        public static BigInt operator %(BigInt left, BigInt right)
        {
            return BigIntOperations.Mod(left, right);
        }
    }
}