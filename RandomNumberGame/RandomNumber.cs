namespace RandomNumberGame;

public class RandomNumber
{
    private readonly int Number;
    private readonly Random _random;

    public RandomNumber()
    {
        _random = new Random();
        Number = GenerateRandomNumber();
    }

    private int GenerateRandomNumber()
    {
        return _random.Next(1, 11);
    }

    public int GetNumber()
    {
        return Number;
    }

    public bool IsNumber(int guess)
    {
        return guess == Number;
    }
}
