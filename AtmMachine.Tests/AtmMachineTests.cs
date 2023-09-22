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
}

