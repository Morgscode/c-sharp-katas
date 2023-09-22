namespace AtmMachine
{
	public class AtmMachine
	{

		private List<KeyValuePair<int, int>> NoteInventory;
		private int TotalAvailableCash = 0;

        public static readonly List<int> Notes = new List<int>
		{
			5,
			10,
			20,
			50
		};

		public AtmMachine(List<KeyValuePair<int, int>> inventory)
		{
			NoteInventory = inventory ?? throw new ArgumentNullException(nameof(inventory));

			foreach(var item in inventory)
			{
				int itemTotal = item.Value * item.Key;
                TotalAvailableCash += itemTotal;
			}
		}

		public List<KeyValuePair<int, int>> Withdraw(int amount)
		{
            if (amount <= 0)
			{
				throw new ArgumentException("Invalid Input - Amount must be greater than 0");
            }

			if (amount % 5 != 0)
			{
                throw new ArgumentException("Invalid Input - Amount cannot be dispensed");
            }

            if (TotalAvailableCash == 0) throw new Exception("There is no cash available at this atm");

            return GetNotes(new List<KeyValuePair<int, int>>{}, amount);
		}

		private List<KeyValuePair<int, int>> GetNotes(List<KeyValuePair<int, int>> input, int amount)
		{
            List<int> notes = new List<int>(Notes);
            notes.Reverse();

            foreach (var note in notes)
            {
                if (amount == 0) break;

                int count = amount / note;
                if (count > 0)
                {
                    input.Add(new KeyValuePair<int, int>(count, note));
                    amount -= count * note;
                }
            }

            return input;
        }

    }
}

