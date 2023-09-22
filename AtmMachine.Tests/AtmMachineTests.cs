namespace AtmMachine.Tests;

public class AtmMachineTests
{
    [Fact]
    public void ThrowsForInvalidInventory()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => new AtmMachine(null));
        Assert.Equal("Value cannot be null. (Parameter 'inventory')", exception.Message);
    }

    [Fact]
    public void CalculatesTotalCashAvailable()
    {
        var atm = new AtmMachine(new Dictionary<int, int>
        {
            { 50,  100},
            { 20,  100},
            { 10, 100 },
            { 5, 100 },
        });
        Assert.Equal(8500, atm.GetTotalCashAvailable());
    }

    [Fact]
    public void MaintainsTotalAvailableCash()
    {
        // Initialize ATM with $290 - 5 notes of $50 and 4 notes of $10
        var initialInventory = new Dictionary<int, int>
        {
            { 50, 5 },
            { 10, 4 }
        };
        var atm = new AtmMachine(initialInventory);

        // First withdrawal of $70 (1 note of $50 and 2 notes of $10)
        var result1 = atm.Withdraw(70);
        Assert.Equal(1, result1[50]);
        Assert.Equal(2, result1[10]);

        // Check remaining cash after both withdrawals
        Assert.Equal(220, atm.GetTotalCashAvailable()); // 290 - 70 - 50 = 170

        // Second withdrawal of $50 (1 note of $50)
        var result2 = atm.Withdraw(50);
        Assert.Equal(1, result2[50]);

        // Check remaining cash after both withdrawals
        Assert.Equal(170, atm.GetTotalCashAvailable()); // 290 - 70 - 50 = 170
    }

    [Fact]
    public void ThrowsErrorWhenInsufficientTotalCash()
    {
        // Initialize ATM with $60 - 1 note of $50 and 1 note of $10
        var initialInventory = new Dictionary<int, int>
        {
            { 50, 1 },
            { 10, 1 }
        };
        var atm = new AtmMachine(initialInventory);

        // First withdrawal of $50 (1 note of $50)
        var result1 = atm.Withdraw(50);
        Assert.Equal(1, result1[50]);

        // Second withdrawal that tries to get more than available cash
        Assert.Throws<ArgumentException>(() => atm.Withdraw(20)); // Only $10 left
    }
}

