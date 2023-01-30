using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigInt.Core.Tests
{
    public class AddTests
    {
        [Fact]
        public void AddBothPositiveShouldReturnPositive()
        {
            var expected = "1800";
            BigInt data = new BigInt("1234") + new BigInt("566");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void AddWithOverloadingShouldReturnNumberWithNewSize()
        {
            var expected = "10000";
            BigInt data = new BigInt("1234") + new BigInt("8766");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void AddZeroShouldNotChangeResult()
        {
            var expected = "1234";
            BigInt data = new BigInt("1234") + new BigInt("0");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void AddNegativeShouldUseSub()
        {
            var expected = "650";
            BigInt data = new BigInt("1000") + new BigInt("-350");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void AddNegativeRightBiggerThanLeftShouldReturnNegativeResult()
        {
            var expected = "9000";
            BigInt data = new BigInt("1000") + new BigInt("-10000");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal("-" + expected, data.ToString());
        }

        [Fact]
        public void AddZeroToNegativeShouldReturnSameNegative()
        {
            var expected = "9000";
            BigInt data = new BigInt("-9000") + new BigInt("-0");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal("-" + expected, data.ToString());
        }

        [Fact]
        public void AddBothNegativeShouldReturnNegativeSum()
        {
            var expected = "11234566";
            BigInt data = new BigInt("-1234567") + new BigInt("-9999999");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal("-" + expected, data.ToString());
        }
    }
}
