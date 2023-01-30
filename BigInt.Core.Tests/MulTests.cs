using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace BigInt.Core.Tests
{
    public class MulTests
    {
        [Fact]
        public void MulBothPositiveShouldReturnPositive()
        {
            var expected = "151782";
            BigInt data = new BigInt("1234") * new BigInt("123");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void MulMinusOneShouldChangeSign()
        {
            BigInt data = new BigInt("1234") * new BigInt("-1");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            data = data * new BigInt("-1");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
        }

        [Fact]
        public void MulZeroShuldReturnZero()
        {
            BigInt data = new BigInt("1234") * new BigInt("0");
            Assert.NotNull(data);
            Assert.True(data.IsZero);
        }

        [Fact]
        public void MulLeftNegativeShouldReturnNegative()
        {
            var expected = "123455465433";
            BigInt data = new BigInt("-1234567") * new BigInt("99999");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal("-" + expected, data.ToString());
        }

        [Fact]
        public void MulRightNegativeShouldReturnNegative()
        {
            var expected = "123455465433";
            BigInt data = new BigInt("1234567") * new BigInt("-99999");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal("-" + expected, data.ToString());
        }

        [Fact]
        public void MulBothNegativeShouldReturnPositive()
        {
            var expected = "123455465433";
            BigInt data = new BigInt("-1234567") * new BigInt("-99999");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }
    }
}
