namespace AtmMachine.Tests;

public class WithdrawTests
{

    [Fact]
    public void ThrowsForInvalidInventory()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => new AtmMachine(null));
        Assert.Equal("Value cannot be null. (Parameter 'inventory')", exception.Message);
    }

    [Fact]
    public void ThrowsForNoAvailableCash()
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>> { });
        var exception = Assert.Throws<Exception>(() => atm.Withdraw(5));
        Assert.Equal("There is no cash available at this atm", exception.Message);
    }

    [Fact]
    public void ThrowsForZeroInput()
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>> { new KeyValuePair<int, int>(1, 5) });
        var exception = Assert.Throws<ArgumentException>(() => atm.Withdraw(0));
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
    public void ThrowsForInvalidAmount(int input)
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>>
        {
        new KeyValuePair<int, int>(1, 5)
        });

        var exception = Assert.Throws<ArgumentException>(() => atm.Withdraw(input));
        Assert.Equal("Invalid Input - Amount cannot be dispensed", exception.Message);
    }

    [Fact]
    public void ThrowsForNegativeInput()
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>> { new KeyValuePair<int, int>(1, 5) });
        Assert.Throws<ArgumentException>(() => atm.Withdraw(-5));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(50)]
    public void SingleNoteTheory(int input)
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>>
        {
        new KeyValuePair<int, int>(100, 50),
        new KeyValuePair<int, int>(100, 20),
        new KeyValuePair<int, int>(100, 10),
        new KeyValuePair<int, int>(100, 5),
        });
        var expected = new List<KeyValuePair<int, int>> { new KeyValuePair<int, int>(1, input) };
        var output = atm.Withdraw(input);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesFifteenInput()
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>>
        {
        new KeyValuePair<int, int>(100, 50),
        new KeyValuePair<int, int>(100, 20),
        new KeyValuePair<int, int>(100, 10),
        new KeyValuePair<int, int>(100, 5),
        });
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(1, 10 ),
            new KeyValuePair<int, int>(1, 5 ),
        };
        var output = atm.Withdraw(15);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesTwentyFiveInput()
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>>
        {
        new KeyValuePair<int, int>(100, 50),
        new KeyValuePair<int, int>(100, 20),
        new KeyValuePair<int, int>(100, 10),
        new KeyValuePair<int, int>(100, 5),
        });
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(1, 20 ),
            new KeyValuePair<int, int>(1, 5 ),
        };
        var output = atm.Withdraw(25);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesThirtyInput()
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>>
        {
        new KeyValuePair<int, int>(100, 50),
        new KeyValuePair<int, int>(100, 20),
        new KeyValuePair<int, int>(100, 10),
        new KeyValuePair<int, int>(100, 5),
        });
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(1, 20 ),
            new KeyValuePair<int, int>(1, 10 ),
        };
        var output = atm.Withdraw(30);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesThirtyFive()
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>>
        {
        new KeyValuePair<int, int>(100, 50),
        new KeyValuePair<int, int>(100, 20),
        new KeyValuePair<int, int>(100, 10),
        new KeyValuePair<int, int>(100, 5),
        });
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(1, 20 ),
            new KeyValuePair<int, int>(1, 10 ),
            new KeyValuePair<int, int>(1, 5 ),
        };
        var output = atm.Withdraw(35);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesFortyInput()
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>>
        {
        new KeyValuePair<int, int>(100, 50),
        new KeyValuePair<int, int>(100, 20),
        new KeyValuePair<int, int>(100, 10),
        new KeyValuePair<int, int>(100, 5),
        });
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(2, 20 ),
        };
        var output = atm.Withdraw(40);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesFortyFive()
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>>
        {
        new KeyValuePair<int, int>(100, 50),
        new KeyValuePair<int, int>(100, 20),
        new KeyValuePair<int, int>(100, 10),
        new KeyValuePair<int, int>(100, 5),
        });
        var expected = new List<KeyValuePair<int, int>>
        {
            new KeyValuePair<int, int>(2, 20 ),
            new KeyValuePair<int, int>(1, 5 ),
        };
        var output = atm.Withdraw(45);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesMixedNotes()
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>>
        {
        new KeyValuePair<int, int>(100, 50),
        new KeyValuePair<int, int>(100, 20),
        new KeyValuePair<int, int>(100, 10),
        new KeyValuePair<int, int>(100, 5),
        });
        var expected = new List<KeyValuePair<int, int>>
    {
        new KeyValuePair<int, int>(2, 50),
        new KeyValuePair<int, int>(1, 20),
        new KeyValuePair<int, int>(1, 5),
    };
        var output = atm.Withdraw(125);
        Assert.Equal(expected, output);
    }

    [Fact]
    public void HandlesRandomValue()
    {
        var atm = new AtmMachine(new List<KeyValuePair<int, int>>
        {
        new KeyValuePair<int, int>(100, 50),
        new KeyValuePair<int, int>(100, 20),
        new KeyValuePair<int, int>(100, 10),
        new KeyValuePair<int, int>(100, 5),
        });
        var expected = new List<KeyValuePair<int, int>>
    {
        new KeyValuePair<int, int>(4, 50),
        new KeyValuePair<int, int>(1, 10),
        new KeyValuePair<int, int>(1, 5),
    };
        var output = atm.Withdraw(215);
        Assert.Equal(expected, output);
    }
}