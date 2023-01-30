namespace BigInt.Core.Models
{
    internal class Data
    {
        internal byte[] Bits { get; set; }
        internal int Size { get; set; }
        internal bool Signed { get; set; }

        internal Data(byte[] bits, int size, bool signed)
        {
            Bits = bits;
            Size = size;
            Signed = signed;
        }
    }
}
