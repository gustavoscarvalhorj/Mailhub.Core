using Mailhub.Core.Domain.ValueObject;
using System;
using Xunit;

namespace EmailTest
{
    public class PortValueObjectTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void IsNotLessThanZero(int port)
        {
            Assert.Throws<ArgumentException>(() => new Port(port));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(15)]
        [InlineData(1000)]
        public void IsMajorThanZero(int port)
        {
            Assert.Equal(port.ToString(), new Port(port).ToString());
        }
    }
}