﻿namespace RandomNumberGame.Tests;

using RandomNumberGame;

public class RandomNumberTests
{
    [Fact]
    public void GeneratesRandomNumber()
    {
        // Arrange
        RandomNumber randomNumberGame = new RandomNumber();

        // Act
        int result = randomNumberGame.GetNumber();

        // Assert
        Assert.IsType<int>(result);
    }

    [Fact]
    public void CanTestAgainstInput()
    {
        // Arrange
        RandomNumber randomNumberGame = new RandomNumber();

        // Act
        bool result = randomNumberGame.IsNumber(2);

        // Assert
        Assert.IsType<bool>(result);
    }
}
