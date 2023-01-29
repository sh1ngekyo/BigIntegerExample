namespace BigInt.Core.Tests
{
    public class ToStringTests
    {
        [Fact]
        public void BigIntToStringShouldReturnReversedBitsConvertedToDigits()
        {
            var expected = "1234";
            BigInt data = "1234";
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(4, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void NegativeBigIntToStringShouldReturnReversedBitsConvertedToDigitsWithMinus()
        {
            var expected = "-1234";
            BigInt data = "-1234";
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(4, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }
    }
}
