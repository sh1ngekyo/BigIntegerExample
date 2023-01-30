namespace BigInt.Core.Tests
{
    public class SubTests
    {
        [Fact]
        public void SubLeftSmallerThanRightShouldReturnNegativeResult()
        {
            var expected = "111111";
            BigInt data = new BigInt("12345") - new BigInt("123456");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal("-" + expected, data.ToString());
        }

        [Fact]
        public void SubLeftBiggerThanRightShouldReturnPositiveResult()
        {
            var expected = "111111";
            BigInt data = new BigInt("123456") - new BigInt("12345");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void SubLeftNegativeShouldUseAddAndShouldReturnNegative()
        {
            var expected = "11234566";
            BigInt data = new BigInt("-1234567") - new BigInt("9999999");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal("-" + expected, data.ToString());
        }

        [Fact]
        public void SubRightNegativeShouldUseAddAndShouldReturnPositive()
        {
            var expected = "11234566";
            BigInt data = new BigInt("1234567") - new BigInt("-9999999");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void SubBothNegativeShouldReturnPositiveSum()
        {
            var expected = "8765432";
            BigInt data = new BigInt("-1234567") - new BigInt("-9999999");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void SubWithOverloadingShouldReturnNumberWithNewSize()
        {
            var expected = "1";
            BigInt data = new BigInt("10000") - new BigInt("9999");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }
    }
}
