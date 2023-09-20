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
            {10, "X"},
            {50, "L"},
            {100, "C"},
            {500, "D"},
            {1000, "M"}
        };

        public static readonly Dictionary<int, string> SubtractionNumeralMap = new Dictionary<int, string>
        {
            {1, "I"},
            {4, "IV"},
            {5, "V"},
            {9, "IX"},
            {10, "X"},
            {40, "XL"},
            {50, "L"},
            {90, "XC"},
            {100, "C"},
            {500, "D"},
            {1000, "M"}
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

            // check for the input as a key inside our subtraction dict
            if (SubtractionNumeralMap.TryGetValue(input, out string subtractionValue))
            {
                return subtractionValue;
            }

            var keys = NumeralMap.Keys.OrderByDescending(k => k).ToList();

            foreach (var key in keys)
            {
                if (input >= key)
                {
                    var numeralBase = NumeralMap[key];
                    var remainder = input - key;

                    // If remainder exists, append the Roman numeral for the remainder to the base numeral
                    return remainder > 0 ? numeralBase + Convert(remainder) : numeralBase;
                }
            }

            return "";
        }

        public static string ICharacterMultiples(int input)
        {
            if (input < 0 || input > 3) throw new ArgumentException("Invalid Input: " + input);
            return new string('I', input);
        }
    }
}

