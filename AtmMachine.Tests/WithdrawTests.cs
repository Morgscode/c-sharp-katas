namespace AtmMachine.Tests;

public class WithdrawTests
{
    [Fact]
    public void HandlesZeroInput()
    {
        var exception = Assert.Throws<ArgumentException>(() => AtmMachine.Withdraw(0));
        Assert.Equal("Invalid Input - Amount must be greater than 0", exception.Message);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
    [InlineData(19)]
    [InlineData(98)]
    [InlineData(11111)]
    public void InvalidInputTheory(int input)
    {
        var exception = Assert.Throws<ArgumentException>(() => AtmMachine.Withdraw(input));
        Assert.Equal("Invalid Input - Amount cannot be dispensed", exception.Message);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(50)]
    public void SingleNoteTheory(int input)
    {
        var expected = new List<KeyValuePair<int, int>> { new KeyValuePair<int, int>(1, input) };
        var output = AtmMachine.Withdraw(input);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesFifteenInput()
    {
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(1, 10 ),
            new KeyValuePair<int, int>(1, 5 ),
        };
        var output = AtmMachine.Withdraw(15);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesTwnetyFiveInput()
    {
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(1, 20 ),
            new KeyValuePair<int, int>(1, 5 ),
        };
        var output = AtmMachine.Withdraw(25);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesThirtyInput()
    {
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(1, 20 ),
            new KeyValuePair<int, int>(1, 10 ),
        };
        var output = AtmMachine.Withdraw(30);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesThirtyFive()
    {
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(1, 20 ),
            new KeyValuePair<int, int>(1, 10 ),
            new KeyValuePair<int, int>(1, 5 ),
        };
        var output = AtmMachine.Withdraw(35);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesFortyInput()
    {
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(2, 20 ),
        };
        var output = AtmMachine.Withdraw(40);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesFortyFive()
    {
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(2, 20 ),
            new KeyValuePair<int, int>(1, 5 ),
        };
        var output = AtmMachine.Withdraw(45);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesFiftyFive()
    {
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(1, 50 ),
            new KeyValuePair<int, int>(1, 5 ),
        };
        var output = AtmMachine.Withdraw(55);
        Assert.Equal(expected, output);
    }
}