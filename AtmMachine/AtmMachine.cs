namespace AtmMachine
{
	public class AtmMachine
	{
		public static readonly List<int> Notes = new List<int>
		{
			5,
			10,
			20,
			50
		};

		public static List<KeyValuePair<int, int>> Withdraw(int amount)
		{
			if (amount == 0)
			{
				throw new ArgumentException("Invalid Input - Amount must be greater than 0");
            }

			if (amount % 5 != 0)
			{
                throw new ArgumentException("Invalid Input - Amount cannot be dispensed");
            }

            var result = new List<KeyValuePair<int, int>>
            {

            };

			if (Notes.Contains(amount))
			{
                result.Add(new KeyValuePair<int, int>(1, amount) );
				return result;
            }

			result = RecursiveGetNote(result, amount);

            return result;
		}

		public static List<KeyValuePair<int, int>> RecursiveGetNote(List<KeyValuePair<int, int>> input, int amount)
		{
			// loop over reversed notes
			var notes = new List<int>(Notes);
			notes.Reverse();

			Console.WriteLine($"");

            foreach (var note in notes)
			{
				if (amount > note)
				{
                    // if amount > note => add note to result
                    input.Add(new KeyValuePair<int, int> (1, note));
                    // subtract note from amount => get remainder
                    var remainder = amount - note;
					if (remainder > 0)
					{
                        // same process on remainder
                        RecursiveGetNote(input, remainder);
                    }
				}
			}

			return input;
        }

    }
}

