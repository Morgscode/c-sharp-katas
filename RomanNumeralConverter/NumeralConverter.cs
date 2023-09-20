namespace RomanNumeralConverter
{
    public class NumeralConverter
    {
        public NumeralConverter()
        {
        }

        public static readonly Dictionary<int, string> NumeralMap = new Dictionary<int, string>
        {
            {1, "I"},
            {5, "V"},
            {10, "X"}
        };

        public static string Convert(int input)
        {
            if (input == 0) return "";

            // tiny perf boost, if it's less than 4 we don't need to use memory looking up the dict
            if (input < 4)
            {
                return ICharacterMultiples(input);
            }

            // check for the input as a key inside our dict
            if (NumeralMap.TryGetValue(input, out string value))
            {
                return value;
            }

            // might need to lose this - handle the 'IIII' problem 
            if (NumeralMap.TryGetValue(input + 1, out string offsetValue))
            {
                return "I" + offsetValue;
            }

            var result = "";

            var keys = NumeralMap.Keys.Skip(1).ToList();
            var values = NumeralMap.Values.Skip(1).ToList();

            for (int i = 0; i < keys.Count; i++)
            {
                // Console.WriteLine($"Key: {keys[i]}, Value: {values[i]}");
                if (input < keys[i] || i == keys.Count - 1)
                {
                    var numeralBase = values[i];
                    var remainder = input % 5;
                    Console.WriteLine($"Target - Loop Index: {i}, Input: {input}, Key: {keys[i]}, Value: {values[i]}, Remainder: {remainder}");
                    if (remainder > 0)
                    {
                        var ending = ICharacterMultiples(remainder);
                        result = numeralBase += ending;
                    }
                }

            }

            return result;
        }

        public static string ICharacterMultiples(int input)
        {
            if (input < 0 || input > 3) throw new ArgumentException("Invalid Input: " + input);
            return new string('I', input);
        }
    }
}

