using Mailhub.Core.Domain.ValueObject;
using System;
using Xunit;

namespace EmailTest
{
    public class HostValueObjectTests
    {
        [Fact]
        public void IsNotEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Host(""));
        }

        [Fact]
        public void IsNotNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Host(null));
        }

        [Theory]
        [InlineData("123a@sdsad")]
        public void IsNotValidHost(string address)
        {
            Assert.Throws<ArgumentException>(() => new Host(address));
        }

        [Theory]
        [InlineData("smtp.gmail.com")]
        [InlineData("gmail.com")]
        [InlineData("outlook.com")]
        [InlineData("hotmail.com")]
        public void IsValidHost(string address)
        {
            Assert.Equal(new Host(address).ToString(), address);
        }
    }
}