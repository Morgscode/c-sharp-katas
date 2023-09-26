namespace RandomNumberGame;

public class RandomNumber
{
    private readonly int NumberToGuess;
    private Random _random;

    public RandomNumber()
    {
        _random = new Random();
        NumberToGuess = GenerateRandomNumber();
    }

    private int GenerateRandomNumber()
    {
        return _random.Next(1, 11);
    }

    public int GetNumberToGuess()
    {
        return NumberToGuess;
    }

    public bool IsNumberToGuess(int guess)
    {
        return guess == NumberToGuess;
    }
}
