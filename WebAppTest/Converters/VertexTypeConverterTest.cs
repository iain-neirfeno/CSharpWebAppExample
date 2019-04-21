using System;
using WebApp.Converters;
using WebApp.Dto;
using Xunit;

namespace WebAppTest.Converters
{
    public class VertexTypeConverterTest
    {
        private readonly VertexTypeConverter _testSubject;

        public VertexTypeConverterTest()
        {
            _testSubject = new VertexTypeConverter();
        }

        [Fact]
        public void CanConvertFromString()
        {
            Assert.True(_testSubject.CanConvertFrom(null, typeof(string)));
        }

        [Fact]
        public void CanNotConvertFromInt()
        {
            Assert.False(_testSubject.CanConvertFrom(null, typeof(int)));
        }

        [Theory]
        [InlineData("0,0", 0, 0)]
        [InlineData("1,2", 1, 2)]
        [InlineData("-1,0", -1, 0)]
        [InlineData("0,-1", 0, -1)]
        public void CanConvertValidStrings(string str, int x, int y)
        {
            Vertex result = (Vertex) _testSubject.ConvertFrom(null, null, str);
            Assert.NotNull(result);
            Assert.Equal(result.X, x);
            Assert.Equal(result.Y, y);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("0,0,0")]
        public void CanNotConvertStringsOfTheWrongLength(string str)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _testSubject.ConvertFrom(null, null, str));
        }

        [Theory]
        [InlineData("")]
        [InlineData("0,A")]
        [InlineData("A,0")]
        [InlineData("A,A")]
        public void CanNotConvertNaNStrings(string str)
        {
            Assert.Throws<FormatException>(() => _testSubject.ConvertFrom(null, null, str));
        }
    }
}