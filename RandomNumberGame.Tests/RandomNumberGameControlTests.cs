namespace RandomNumberGame.Tests;

using System.Reflection;
using RandomNumberGame;

public class RandomNumberGameControlTests
{

    [Fact]
    public void HasGuessMethod()
    {
        // Arrange
        var type = typeof(RandomNumberGameControl);

        // Act
        var methodInfo = type.GetMethod("Guess", BindingFlags.Public | BindingFlags.Instance);

        // Assert
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void GuessReturnsString()
    {
        // Arrange
        RandomNumberGameControl control = new RandomNumberGameControl();

        // Act
        var result = control.Guess(1);

        // Assert
        Assert.IsType<string>(result);
    }

    [Fact]
    public void GuessMethodReturnsUsefulFeedback()
    {
        // Arrange
        RandomNumberGameControl control = new RandomNumberGameControl();
        string[] hints = new string[] { "The number is higher", "The number is lower", "The number is equal", "Correct!" };

        // Act
        string result = control.Guess(3);

        // Assert
        Assert.Contains(result, hints);
       
    }

    [Fact]
    public void AllowsOnlyThreeGuesses()
    {
        RandomNumberGameControl control = new RandomNumberGameControl();
        control.Guess(1);
        control.Guess(2);
        control.Guess(3);
        Assert.Throws<Exception>(() => control.Guess(4));
    }
}


