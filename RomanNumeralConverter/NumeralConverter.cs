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
            {4, "IV"},
            {5, "V"},
            {9, "IX"},
            {10, "X"},
            {40, "XL"},
            {50, "L"},
            {90, "XC"},
            {100, "C"},
            {400, "CD" },
            {500, "D"},
            {900, "CM" },
            {1000, "M"}
        };

        public static string Convert(int input)
        {
            if (input == 0) return "";

            // check for the input as a key inside our dict
            if (NumeralMap.TryGetValue(input, out string value))
            {
                return value;
            }

            var keys = NumeralMap.Keys.OrderByDescending(k => k).ToList();

            foreach (var key in keys)
            {

                Console.WriteLine($"Searching - Input: {input}, Key: {key}, NumeralBase: {NumeralMap[key]}");

                if (input >= key)
                { 
                    var remainder = input - key;

                    Console.WriteLine($"Target - Input: {input}, Key: {key}, NumeralBase: {NumeralMap[key]}, Remainder: {remainder}");

                    // If remainder exists, Recursively convert and append the Roman numeral for the remainder to the base numeral
                    return remainder > 0 ? NumeralMap[key] + Convert(remainder) : NumeralMap[key];
                }
            }

            return "";
        }
    }
}

