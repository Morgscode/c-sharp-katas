using RomanNumeralConverter;
using Xunit;

namespace RomanNumeralConverter.Tests
{
    public class ConvertTest
    {
        [Theory]

        // standard test cases to get us going
        [InlineData(0, "")]
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
        [InlineData(11, "XI")]
        [InlineData(12, "XII")]
        [InlineData(13, "XIII")]
        [InlineData(14, "XIV")]
        [InlineData(15, "XV")]
        [InlineData(16, "XVI")]
        [InlineData(17, "XVII")]
        [InlineData(18, "XVIII")]
        [InlineData(19, "XIX")]
        [InlineData(20, "XX")]
        [InlineData(21, "XXI")]
        [InlineData(22, "XXII")]
        [InlineData(23, "XXIII")]
        [InlineData(24, "XXIV")]
        [InlineData(25, "XXV")]
        [InlineData(26, "XXVI")]
        [InlineData(27, "XXVII")]
        [InlineData(28, "XXVIII")]
        [InlineData(29, "XXIX")]
        [InlineData(30, "XXX")]

        // milestones, edge cases and randos
        [InlineData(40, "XL")]
        [InlineData(49, "XLIX")]
        [InlineData(50, "L")]
        [InlineData(90, "XC")]
        [InlineData(99, "XCIX")]
        [InlineData(100, "C")]
        [InlineData(400, "CD")]
        [InlineData(500, "D")]
        [InlineData(900, "CM")]
        [InlineData(999, "CMXCIX")]
        [InlineData(1000, "M")]
        [InlineData(1492, "MCDXCII")]
        [InlineData(1888, "MDCCCLXXXVIII")]
        [InlineData(1989, "MCMLXXXIX")]
        [InlineData(2000, "MM")]

        public void TestConvertTheory(int input, string expectedOutput)
        {
            var output = NumeralConverter.Convert(input);
            Assert.Equal(expectedOutput, output);
        }
    }
}






