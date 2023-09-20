using RomanNumeralConverter;
using Xunit;

namespace RomanNumeralConverter.Tests
{
    public class ConvertTest
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(14, "XIV")]
        [InlineData(19, "XIX")]
        [InlineData(20, "XX")]
        [InlineData(40, "XL")]
        [InlineData(49, "XLIX")]
        [InlineData(50, "L")]
        [InlineData(90, "XC")]
        [InlineData(99, "XCIX")]
        [InlineData(100, "C")]
        //[InlineData(400, "CD")]
        //[InlineData(500, "D")]
        //[InlineData(900, "CM")]
        //[InlineData(999, "CMXCIX")]
        //[InlineData(1000, "M")]
        //[InlineData(1492, "MCDXCII")]
        //[InlineData(1888, "MDCCCLXXXVIII")]
        //[InlineData(1989, "MCMLXXXIX")]
        //[InlineData(2000, "MM")]
        public void TestConvertTheory(int input, string expectedOutput)
        {
            var output = NumeralConverter.Convert(input);
            Assert.Equal(expectedOutput, output);
        }
    }
}






