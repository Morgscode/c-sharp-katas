namespace RandomNumberGame;

public class RandomNumberGameControl
{
    private int limit = 3;
    private int attempts = 0;
    private RandomNumber _randomNumber;

    public RandomNumberGameControl()
    {
        _randomNumber = new RandomNumber();
    }

    public string Hint(int guess)
    {
        if (guess < _randomNumber.GetNumberToGuess())
        {
            return "The number is higher";
        }
        else if (guess > _randomNumber.GetNumberToGuess())
        {
            return "The number is lower";
        }
        else
        {
            return "The number is equal";
        }
    }

    public string Guess(int guess)
    {
        if (_randomNumber.IsNumberToGuess(guess))
        {
            return "Correct!";
        }

        return Hint(guess);
    }
}


