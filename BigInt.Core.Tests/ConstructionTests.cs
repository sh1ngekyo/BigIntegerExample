namespace BigInt.Core.Tests
{
    public class ConstructionTests
    {
        [Fact]
        public void CreateFromNegativeIntShouldReturnSignedBigInt()
        {
            var expected = new char[] {'4', '3', '2', '1'}.Select(x => (byte)x).ToArray();
            BigInt data = -1234;
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(4, data.GetSize);
            Assert.Equal(expected, data.GetBits);
        }

        [Fact]
        public void CreateFromPositiveIntShouldReturnUnsignedBigInt()
        {
            var expected = new char[] { '4', '3', '2', '1' }.Select(x => (byte)x).ToArray();
            BigInt data = 1234;
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(4, data.GetSize);
            Assert.Equal(expected, data.GetBits);
        }

        [Fact]
        public void CreateFromNegativeLongShouldReturnSignedBigInt()
        {
            var expected = new char[] { '4', '3', '2', '1' }.Select(x => (byte)x).ToArray();
            BigInt data = -1234L;
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(4, data.GetSize);
            Assert.Equal(expected, data.GetBits);
        }

        [Fact]
        public void CreateFromPositiveLongShouldReturnUnsignedBigInt()
        {
            var expected = new char[] { '4', '3', '2', '1' }.Select(x => (byte)x).ToArray();
            BigInt data = 1234L;
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(4, data.GetSize);
            Assert.Equal(expected, data.GetBits);
        }

        [Fact]
        public void CreateFromULongShouldReturnUnsignedBigInt()
        {
            var expected = new char[] { '4', '3', '2', '1' }.Select(x => (byte)x).ToArray();
            BigInt data = 1234UL;
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(4, data.GetSize);
            Assert.Equal(expected, data.GetBits);
        }

        [Fact]
        public void CreateFromUIntShouldReturnUnsignedBigInt()
        {
            var expected = new char[] { '4', '3', '2', '1' }.Select(x => (byte)x).ToArray();
            BigInt data = 1234U;
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(4, data.GetSize);
            Assert.Equal(expected, data.GetBits);
        }


        [Fact]
        public void CreateFromEmptyStringShouldThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new BigInt(""));
            Assert.Throws<ArgumentNullException>(() => new BigInt(null));
            Assert.Throws<ArgumentNullException>(() => new BigInt(" "));
            Assert.Throws<ArgumentNullException>(() => new BigInt("\t"));
        }


        [Fact]
        public void CreateFromStringShouldIgnoreFirstZeroes()
        {
            var expected = new char[] { '4', '3', '2', '1' }.Select(x => (byte)x).ToArray();
            BigInt data = "00001234";
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(4, data.GetSize);
            Assert.Equal(expected, data.GetBits);
        }

        [Fact]
        public void CreateFromNegativeStringShouldIgnoreFirstZeroes()
        {
            var expected = new char[] { '4', '3', '2', '1' }.Select(x => (byte)x).ToArray();
            BigInt data = "-00001234";
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(4, data.GetSize);
            Assert.Equal(expected, data.GetBits);
        }

        [Fact]
        public void CreateFromPositiveStringShouldIgnorePlus()
        {
            var expected = new char[] { '4', '3', '2', '1' }.Select(x => (byte)x).ToArray();
            BigInt data = "+1234";
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(4, data.GetSize);
            Assert.Equal(expected, data.GetBits);
        }

        [Fact]
        public void CreateFromStringWithNonDigitsCharsShouldThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new BigInt("1234dj"));
            Assert.Throws<ArgumentException>(() => new BigInt("--0004f"));
            Assert.Throws<ArgumentException>(() => new BigInt("-000-"));
        }

        [Fact]
        public void CreateFromAllZeroStringShouldReturnZeroBigInt()
        {
            var expected = new char[] { '0' }.Select(x => (byte)x).ToArray();
            BigInt data = "+0000";
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(1, data.GetSize);
            Assert.Equal(expected, data.GetBits);
        }

        [Fact]
        public void CreateFromAllZeroStringWithMinusShouldReturnUnsignedZeroBigInt()
        {
            var expected = new char[] { '0' }.Select(x => (byte)x).ToArray();
            BigInt data = "-0000";
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(1, data.GetSize);
            Assert.Equal(expected, data.GetBits);
        }
    }
}