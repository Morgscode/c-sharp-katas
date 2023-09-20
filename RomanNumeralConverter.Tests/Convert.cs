using RomanNumeralConverter;
using Xunit;

namespace RomanNumeralConverter.Tests;

public class Convert
{
    [Fact]
    public void HandlesZero()
    {
        var output = NumeralConverter.Convert(0);
        Assert.Equal("", output);
    }

    [Fact]
    public void HandlesOne()
    {
        var output = NumeralConverter.Convert(1);
        Assert.Equal("I", output);
    }

    [Fact]
    public void HandlesTwo()
    {
        var output = NumeralConverter.Convert(2);
        Assert.Equal("II", output);
    }

    [Fact]
    public void HandlesThree()
    {
        var output = NumeralConverter.Convert(3);
        Assert.Equal("III", output);
    }

    [Fact]
    public void HandlesFour()
    {
        var output = NumeralConverter.Convert(4);
        Assert.Equal("IV", output);
    }

    [Fact]
    public void HandlesFive()
    {
        var output = NumeralConverter.Convert(5);
        Assert.Equal("V", output);
    }

    [Fact]
    public void HandlesSix()
    {
        var output = NumeralConverter.Convert(6);
        Assert.Equal("VI", output);
    }

    [Fact]
    public void HandlesSeven()
    {
        var output = NumeralConverter.Convert(7);
        Assert.Equal("VII", output);
    }

    [Fact]
    public void HandlesEight()
    {
        var output = NumeralConverter.Convert(8);
        Assert.Equal("VIII", output);
    }

    [Fact]
    public void HandleNine()
    {
        var output = NumeralConverter.Convert(9);
        Assert.Equal("IX", output);
    }

    [Fact]
    public void HandleTen()
    {
        var output = NumeralConverter.Convert(10);
        Assert.Equal("X", output);
    }

    [Fact]
    public void HandleEleven()
    {
        var output = NumeralConverter.Convert(11);
        Assert.Equal("XI", output);
    }
}