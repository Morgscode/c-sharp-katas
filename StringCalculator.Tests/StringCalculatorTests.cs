namespace StringCalculator.Tests;

using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void HasAddMethod()
    {
        // Arrange
        Type type = typeof(Calculator);

        // Act
        var methodInfo = type.GetMethod("Add", BindingFlags.Public | BindingFlags.Instance);

        // Assert
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void ReturnsZeroForEmptyString()
    {
        // Arrange
        Calculator calculator = new Calculator();
        // Act
        int result = calculator.Add("");
        // Assert
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("0", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 3)]
    [InlineData("4", 4)]
    [InlineData("5", 5)]
    [InlineData("6", 6)]
    [InlineData("7", 7)]
    [InlineData("8", 8)]
    [InlineData("9", 9)]
    [InlineData("10", 10)]
    [InlineData("11", 11)]
    [InlineData("111", 111)]
    [InlineData("9000990", 9000990)]
    public void HandlesOneNumber(string input, int output)
    {
        // Arrange
        Calculator calculator = new Calculator();
        // Act
        int result = calculator.Add(input);
        // Assert
        Assert.Equal(output, result);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("abc")]
    [InlineData("stavvy")]
    [InlineData("jkjskjskjsksj")]
    [InlineData("1,jkjskjskjsksj")]
    [InlineData("1,jkjskjskjsksj,3")]
    [InlineData("1,1,1")]
    public void ThrowsForInvalidInputs(string input)
    {
        // Arrange
        Calculator calculator = new Calculator();
        // Act
        ArgumentException e = Assert.Throws<ArgumentException>(() => calculator.Add(input));
    }

    [Theory]
    [InlineData("2,2", 4)]
    [InlineData("3,1", 4)]
    public void HandlesTwoNumbers(string input, int output)
    {
        // Arrange
        Calculator calculator = new Calculator();
        // Act
        int result = calculator.Add(input);
        // Assert
        Assert.Equal(output, result);
    }
}
