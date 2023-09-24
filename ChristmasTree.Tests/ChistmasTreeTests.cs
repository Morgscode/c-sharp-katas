using ChristmasTrees;

namespace ChristmasTree.Tests;

public class ChristmasTreeTests
{

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void ThrowsForLessThanZeroInput(int height)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => XmasTree.GrowTree(height));
    }

    [Fact]
    public void GrowTreeMethodPrintsToTheConsole()
    {
        // Arrange
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        XmasTree.GrowTree(2);
        var capturedMessage = stringWriter.ToString();

        // Reset console output (not strictly necessary, but good practice)
        var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        Console.SetOut(standardOutput);

        // Assert
        Assert.StartsWith(" ", capturedMessage);
    }

    [Fact]
    public void HandlesTopRow()
    {

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);


        XmasTree.GrowTree(2);
        var capturedMessage = stringWriter.ToString();

        // Reset console output (not strictly necessary, but good practice)
        var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        Console.SetOut(standardOutput);


        Assert.StartsWith("  X", capturedMessage);


        string output = XmasTree.GrowTree(4);
        Assert.StartsWith("    X", output);
    }

    [Fact]
    public void HandlesBottomRow()
    {
        string output = XmasTree.GrowTree(4);
        Assert.Contains("    |", output);

        output = XmasTree.GrowTree(10);
        Assert.Contains("          |", output);
    }

    [Fact]
    public void AddsTwoXCharsForEveryRow()
    {
        string output = XmasTree.GrowTree(4);
                       
        Assert.Contains("    X", output);
        Assert.Contains("   XXX", output);
        Assert.Contains("  XXXXX", output);
        Assert.Contains(" XXXXXXX", output);
    }
}
