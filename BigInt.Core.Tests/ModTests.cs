using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigInt.Core.Tests
{
    public class ModTests
    {
        [Fact]
        public void MulBothPositiveShouldReturnPositive()
        {
            var expected = "34579";
            BigInt data = new BigInt("1234567") % new BigInt("99999");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }

        [Fact]
        public void MulLeftNegativePositiveShouldReturnNegative()
        {
            var expected = "34579";
            BigInt data = new BigInt("-1234567") % new BigInt("99999");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal("-" + expected, data.ToString());
        }

        [Fact]
        public void MulRightNegativePositiveShouldReturnNegative()
        {
            var expected = "34579";
            BigInt data = new BigInt("1234567") % new BigInt("-99999");
            Assert.NotNull(data);
            Assert.True(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal("-" + expected, data.ToString());
        }


        [Fact]
        public void MulBothNegativePositiveShouldReturnPositive()
        {
            var expected = "34579";
            BigInt data = new BigInt("-1234567") % new BigInt("-99999");
            Assert.NotNull(data);
            Assert.False(data.IsNegative);
            Assert.Equal(expected.Length, data.GetSize);
            Assert.Equal(expected, data.ToString());
        }
    }
}
