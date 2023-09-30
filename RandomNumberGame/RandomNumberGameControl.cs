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

    private string Hint(int guess)
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
        if (attempts == limit) throw new Exception("You are out of guesses");

        if (_randomNumber.IsNumberToGuess(guess))
        {
            return "Correct!";
        }
        attempts++;

        return Hint(guess);
    }
}


