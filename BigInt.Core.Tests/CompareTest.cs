namespace BigInt.Core.Tests
{
    public class CompareTest
    {
        [Fact]
        public void CompareSmallerToBiggerBothPositiveShouldReturnMinusOne()
        {
            var expected = -1;
            BigInt smaller = "456";
            BigInt bigger = "1245";
            Assert.Equal(expected, smaller.CompareTo(bigger));
        }

        [Fact]
        public void CompareBiggerToSmallerBothPositiveShouldReturnOne()
        {
            var expected = 1;
            BigInt smaller = "456";
            BigInt bigger = "1245";
            Assert.Equal(expected, bigger.CompareTo(smaller));
        }

        [Fact]
        public void CompareBigNegativeToSmallPositiveShouldReturnMinusOne()
        {
            var expected = -1;
            BigInt smaller = "-4367";
            BigInt bigger = "24";
            Assert.Equal(expected, smaller.CompareTo(bigger));
        }

        [Fact]
        public void CompareBigNegativeToSmallNegativeShouldReturnMinusOne()
        {
            var expected = -1;
            BigInt smaller = "-4367";
            BigInt bigger = "-24";
            Assert.Equal(expected, smaller.CompareTo(bigger));
        }

        [Fact]
        public void CompareByAbsBothNegativeShouldReturnOne()
        {
            var expected = 1;
            BigInt smaller = "-4367";
            BigInt bigger = "-24";
            Assert.Equal(expected, smaller.CompareByAbsTo(bigger));
        }
    }
}
