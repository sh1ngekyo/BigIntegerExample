using BigInt.Core.Models;

using System;

namespace BigInt.Core
{
    public sealed class BigInt
    {
        private Data Data { get; set; }

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

        public static implicit operator BigInt(ulong data) => new BigInt(data);

        public static implicit operator BigInt(long data) => new BigInt(data);

        public static implicit operator BigInt(uint data) => new BigInt(data);

        public static implicit operator BigInt(int data) => new BigInt(data);

        public static implicit operator BigInt(string data) => new BigInt(data);
    }
}