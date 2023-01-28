using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
