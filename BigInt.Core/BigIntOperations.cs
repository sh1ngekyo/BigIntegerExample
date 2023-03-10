using BigInt.Core.Models;

namespace BigInt.Core
{
    internal static class BigIntOperations
    {
        private static (BigInt Min, BigInt Max) GetMinMaxBySize(BigInt left, BigInt right)
            => left.GetSize > right.GetSize ? ((BigInt Min, BigInt Max))(right, left) : ((BigInt Min, BigInt Max))(left, right);

        private static void Shrink(Data data)
        {
            var shrink = 0;
            for (int i = data.Size - 1; i >= 0 && data.Bits[i] <= '0'; --i)
                ++shrink;
            if (shrink == data.Size)
            {
                data.Bits = new byte[1] { (byte)'0' };
                data.Size = 1;
                data.Signed = false;
                return;
            }
            if (shrink > 0)
            {
                var tmp = new byte[data.Size - shrink];
                for (var i = 0; i < data.Size - shrink; i++)
                    tmp[i] = data.Bits[i];
                data.Bits = tmp;
                data.Size -= shrink;
            }
        }

        public static BigInt Add(BigInt left, BigInt right)
        {
            if (left.IsNegative && !right.IsNegative)
            {
                var copy = (BigInt)left.Clone();
                copy.Data.Signed = false;
                return Sub(right, copy);
            }
            if (right.IsNegative && !left.IsNegative)
            {
                var copy = (BigInt)right.Clone();
                copy.Data.Signed = false;
                return Sub(left, copy);
            }
            var signed = false;
            if (left.IsNegative && right.IsNegative)
                signed = true;
            var compared = GetMinMaxBySize(left, right);
            var data = new Data(new byte[compared.Max.GetSize], compared.Max.GetSize, signed);
            for (var i = 0; i < compared.Min.GetSize; i++)
                data.Bits[i] = (byte)(compared.Max.GetBits[i] - 48 + (compared.Min.GetBits[i] - 48) + 48);
            for (var i = compared.Min.GetSize; i < compared.Max.GetSize; i++)
                data.Bits[i] = compared.Max.GetBits[i];
            for (var i = 0; i < compared.Max.GetSize; i++)
            {
                if (data.Bits[i] > '9')
                {
                    if (i == compared.Max.GetSize - 1)
                    {
                        var tmp = new Data(new byte[compared.Max.GetSize + 1], compared.Max.GetSize + 1, signed);
                        Array.Copy(data.Bits, tmp.Bits, compared.Max.GetSize);
                        tmp.Bits[compared.Max.GetSize] = (byte)'0';
                        data = tmp;
                    }
                    data.Bits[i] = (byte)((data.Bits[i] - 48) % 10 + 48);
                    data.Bits[i + 1] += 1;
                }
            }
            return new BigInt(data);
        }

        public static BigInt Sub(BigInt left, BigInt right)
        {
            var cmp = left.CompareByAbsTo(right);
            if (left.IsNegative && !right.IsNegative)
            {
                var copy = (BigInt)right.Clone();
                copy.Data.Signed = true;
                return Add(left, copy);
            }
            if (right.IsNegative && !left.IsNegative)
            {
                var copy = (BigInt)right.Clone();
                copy.Data.Signed = false;
                return Add(left, copy);
            }
            BigInt min;
            BigInt max;
            bool signed;
            if (cmp == 1)
            {
                min = right;
                max = left;
                signed = false;
            }
            else
            {
                min = left;
                max = right;
                signed = true;
            }
            if (right.IsNegative && left.IsNegative && cmp == 1)
                signed = true;
            if (right.IsNegative && left.IsNegative && cmp == -1)
                signed = false;
            var data = new Data(new byte[max.GetSize], max.GetSize, signed);
            for (var i = 0; i < min.GetSize; i++)
                data.Bits[i] = (byte)(max.GetBits[i] - 48 - (min.GetBits[i] - 48) + 48);
            for (var i = min.GetSize; i < max.GetSize; i++)
                data.Bits[i] = max.GetBits[i];
            for (var i = 0; i < max.GetSize; i++)
            {
                if (data.Bits[i] < '0')
                {
                    data.Bits[i] += 10;
                    data.Bits[i + 1] -= 1;
                }
            }
            Shrink(data);
            return new BigInt(data);
        }

        public static BigInt Mul(BigInt left, BigInt right)
        {
            BigInt result = 0;
            if (left.IsZero || right.IsZero)
                return result;
            var currentDigitIndex = 0;
            for (var i = 0; i < right.GetSize; i++)
            {
                var chunk = new BigInt(new Data(new byte[left.GetSize + right.GetSize], left.GetSize + right.GetSize, false));
                var carry = 0;
                var j = 0;
                for (; j < left.GetSize; j++)
                {
                    var digit = (left.Data.Bits[j] - 48) * (right.Data.Bits[i] - 48) + carry;
                    carry = digit / 10;
                    digit %= 10;
                    chunk.Data.Bits[j] = (byte)(digit + 48);
                }
                if (carry > 0)
                    chunk.Data.Bits[j] = (byte)(carry + 48);
                for (var k = chunk.GetSize - 1; k >= 0; --k)
                    if (char.IsDigit((char)chunk.Data.Bits[k]))
                        chunk.Data.Bits[k + currentDigitIndex] = chunk.Data.Bits[k];
                for (var k = 0; k < currentDigitIndex; k++)
                    chunk.Data.Bits[k] = (byte)'0';
                Shrink(chunk.Data);
                result += chunk;
                ++currentDigitIndex;
            }
            if (left.IsNegative || right.IsNegative)
                result.Data.Signed = true;
            if (left.IsNegative && right.IsNegative)
                result.Data.Signed = false;
            return result;
        }

        public static BigInt Div(BigInt left, BigInt right)
        {
            if (left.IsZero)
                return 0;
            if (right.IsZero)
                throw new DivideByZeroException(nameof(right));
            var cmp = left.CompareByAbsTo(right);
            if (cmp == -1)
                return 0;
            if (cmp == 0)
                return 1;
            BigInt result = 0;
            var systemBase = 10;
            var leftCopy = (BigInt)left.Clone();
            var rightCopy = (BigInt)right.Clone();
            leftCopy.Data.Signed = false;
            rightCopy.Data.Signed = false;
            while (!leftCopy.IsNegative && leftCopy.CompareByAbsTo(rightCopy) != -1)
            {
                result *= systemBase;
                BigInt range = 0;
                var i = leftCopy.GetSize - 1;
                var j = 1;
                while (range.CompareByAbsTo(rightCopy) == -1)
                {
                    range *= systemBase;
                    range.Data.Bits[range.GetSize - j++] = leftCopy.GetBits[i--];
                }
                var temp = 0L;
                var range_size_backup = range.GetSize;
                while (range.CompareByAbsTo(rightCopy) != -1)
                {
                    range -= rightCopy;
                    temp++;
                }
                BigInt numberOfDigits = temp;
                BigInt subRange = rightCopy * numberOfDigits;
                for (var k = 0; k < leftCopy.GetSize - range_size_backup; k++)
                    subRange *= systemBase;
                leftCopy -= subRange;
                result += numberOfDigits;
            }
            if (left.IsNegative || right.IsNegative)
                result.Data.Signed = true;
            if (left.IsNegative && right.IsNegative)
                result.Data.Signed = false;
            return result;
        }

        public static BigInt Mod(BigInt left, BigInt right)
        {
            if (left.IsZero)
                return 0;
            if (right.IsZero)
                throw new DivideByZeroException(nameof(right));
            var cmp = left.CompareByAbsTo(right);
            if (cmp == -1)
                return 0;
            if (cmp == 0)
                return 1;
            var leftCopy = (BigInt)left.Clone();
            var rightCopy = (BigInt)right.Clone();
            leftCopy.Data.Signed = false;
            rightCopy.Data.Signed = false;
            var signed = false;
            if (left.IsNegative || right.IsNegative)
                signed = true;
            if (left.IsNegative && right.IsNegative) 
                signed = false;
            BigInt result = leftCopy - ((leftCopy / rightCopy) * rightCopy);
            result.Data.Signed = signed;
            return result;
        }
    }
}
