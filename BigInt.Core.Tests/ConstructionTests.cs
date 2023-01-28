namespace BigInt.Core.Tests
{
    public class ConstructionTests
    {
        //private char[] 

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
    }
}