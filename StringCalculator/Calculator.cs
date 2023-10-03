namespace StringCalculator;

public class Calculator
{
    public Calculator()
    {
    }

    public int Add(string input)
    {
        if (input == "") return 0;

        if (input.Contains(",") == false)
        {
            return ParseStringToNumberOrFail(input);
        }
        else
        {
            string[] strings = input.Split(",");

            if (strings.Length > 2) throw new ArgumentException($"Invalid input - {strings.Length} arguements passed in and this module expects 2");

            int result = 0;

            for (int i = 0; i < strings.Length; i++)
            {
                result += ParseStringToNumberOrFail(strings[i]);
            }

            return result;
        }
    }

    private int ParseStringToNumberOrFail(string input)
    {
        if (int.TryParse(input, out int number))
        {
            return number;
        }
        else
        {
            throw new ArgumentException($"Invalid input - {input} is not valid");
        }
    }
}
