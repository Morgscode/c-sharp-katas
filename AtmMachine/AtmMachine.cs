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

		public static Dictionary<int, int> Withdraw(int amount)
		{
			if (amount == 0)
			{
				throw new ArgumentException("Invalid Input - Amount must be greater than 0");
            }

			if (amount % Notes[0] != 0)
			{
                throw new ArgumentException("Invalid Input - Amount cannot be dispensed");
            }

            var result = new Dictionary<int, int>
            {

            };

            if (Notes.Contains(amount)) result.Add(1, amount);

            return result;
		}

	}
}

