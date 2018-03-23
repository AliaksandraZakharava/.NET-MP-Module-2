using System;
using Xunit;

namespace NETMP.Module2.Parser.Tests
{
    public class ParserTest
    {
        private readonly Parser _parser;

        public ParserTest()
        {
            _parser = new Parser();
        }

        [Fact]
        public void ParseToInt_TryParseToInt_InvalidPassedValue_ThrowsArgumentException()
        {
            var invalidValue = "not a number";

            Assert.Throws<ArgumentException>(() => _parser.ParseToInt(invalidValue));
        }

        [Fact]
        public void TryParseToInt_InvalidPassedValue_ReturnsNull()
        {
            var invalidValue = "not a number";

            var actualResult = _parser.TryParseToInt(invalidValue);

            Assert.Null(actualResult);
        }

        [Fact]
        public void ParseToInt_TryParseToInt_PositiveValue_ReturnsPositiveIntValue()
        {
            var validValue = "25";
            var expectedResult = 25;

            var actualResultParse = _parser.ParseToInt(validValue);
            var actualResultTryParse = _parser.ParseToInt(validValue);

            Assert.Equal(expectedResult, actualResultParse);
            Assert.Equal(expectedResult, actualResultTryParse);
        }

        [Fact]
        public void ParseToInt_NegativeValue_ReturnsNegativeIntValue()
        {
            var validValue = "-25";
            var expectedResult = -25;

            var actualResultParse = _parser.ParseToInt(validValue);
            var actualResultTryParse = _parser.ParseToInt(validValue);

            Assert.Equal(expectedResult, actualResultParse);
            Assert.Equal(expectedResult, actualResultTryParse);
        }
    }
}
