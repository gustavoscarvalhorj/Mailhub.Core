using Mailhub.Core.Domain.ValueObject;
using System;
using Xunit;

namespace EmailTest
{
    public class EmailValueObjectTests
    {
        [Fact]
        public void IsNotEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Email(""));
        }

        [Fact]
        public void IsNotNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Email(null));
        }

        [Theory]
        [InlineData("teste-semarroba.com.br")]
        [InlineData(".@gmail.com")]
        [InlineData("..@teste.com.br")]
        [InlineData("123@.")]
        [InlineData("123@.123")]
        public void IsNotEmail(string address)
        {
            Assert.Throws<ArgumentException>(() => new Email(address));
        }

        [Theory]
        [InlineData("gustavo@gmail.com")]
        [InlineData("gustavo123@gmail.com")]
        [InlineData("gustavo123@teste.com.br")]
        public void IsEmail(string address)
        {
            Assert.Equal(new Email(address).ToString(), address);
        }
    }
}