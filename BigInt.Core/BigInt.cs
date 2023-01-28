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

        public BigInt(long source)
        {
            CreateFromLong(source);
        }

        public BigInt(int source)
        {
            CreateFromInt(source);
        }

        public BigInt(uint source)
        {
            CreateFromUInt(source);
        }

        public BigInt(ulong source)
        {
            CreateFromULong(source);
        }

        private void CreateFromNumber(ulong source, bool signed)
        {
            var bits = source.ToString().ToCharArray().Select(c => (byte)c).Reverse().ToArray();
            Data = new Data(bits, bits.Length, signed);
        }

        private void CreateFromInt(int source)
        {
            var signed = source < 0;
            if (signed)
                source *= -1;
            CreateFromNumber((ulong)source, signed);
        }

        private void CreateFromLong(long source)
        {
            var signed = source < 0;
            if (signed)
                source *= -1;
            CreateFromNumber((ulong)source, signed);
        }

        private void CreateFromUInt(uint source)
        {
            CreateFromNumber(source, false);
        }

        private void CreateFromULong(ulong source)
        {
            CreateFromNumber(source, false);
        }

        public static implicit operator BigInt(ulong data)
        {
            return new BigInt(data);
        }

        public static implicit operator BigInt(long data)
        {
            return new BigInt(data);
        }

        public static implicit operator BigInt(uint data)
        {
            return new BigInt(data);
        }

        public static implicit operator BigInt(int data)
        {
            return new BigInt(data);
        }
    }
}