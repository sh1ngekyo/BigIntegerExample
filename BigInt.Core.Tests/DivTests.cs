using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigInt.Core.Tests
{
    public class DivTests
    {
        [Fact]
        public void DivBothPositiveShouldReturnPositive()
        {
            var expected = "12";
            BigInt data = new BigInt("1234567") / new BigInt("99999");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void DivLeftNegativeShouldReturnNegative()
        {
            var expected = "12";
            BigInt data = new BigInt("-1234567") / new BigInt("99999");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal("-" + expected, data.ToString());
        }

        [Fact]
        public void DivRightNegativeShouldReturnNegative()
        {
            var expected = "12";
            BigInt data = new BigInt("1234567") / new BigInt("-99999");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal("-" + expected, data.ToString());
        }

        [Fact]
        public void DivBothNegativeShouldReturnPositive()
        {
            var expected = "12";
            BigInt data = new BigInt("-1234567") / new BigInt("-99999");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void DivLeftZeroShouldReturnZero()
        {
            var expected = "0";
            BigInt data = new BigInt("0") / new BigInt("-99999");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void DivRightZeroShouldThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => new BigInt("124345") / new BigInt("0"));
        }
    }
}
