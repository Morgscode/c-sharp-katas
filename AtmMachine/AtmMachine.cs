namespace AtmMachine;

public class AtmMachine
{

	private Dictionary<int, int> NoteInventory { get;  }
	private int TotalAvailableCash = 0;

	public AtmMachine(Dictionary<int, int> inventory)
	{
		NoteInventory = inventory ?? throw new ArgumentNullException(nameof(inventory));

		foreach(var item in inventory)
		{
			int itemTotal = item.Key * item.Value;
                TotalAvailableCash += itemTotal;
		}
	}

	public int GetTotalCashAvailable()
	{
		return TotalAvailableCash;
	}

	public Dictionary<int, int> Withdraw(int amount)
	{
            if (amount <= 0) throw new ArgumentException("Invalid Input - Amount must be greater than 0");

		if (amount % 5 != 0) throw new ArgumentException("Invalid Input - Amount cannot be dispensed");

            if (TotalAvailableCash == 0) throw new Exception("There is no cash available at this atm");

		if (amount > TotalAvailableCash) throw new ArgumentException("That amount is not available to dispense");

            return GetNotes(amount);
	}

	private Dictionary<int, int> GetNotes(int amount)
	{

		var output = new Dictionary<int, int> { };

            foreach (var note in NoteInventory)
            {
                if (amount == 0) break;

			// if we don't  have any of the notes left, continue
			if (note.Value == 0) continue;

			// calc how many of this note to dispense
                int count = amount / note.Key;
                if (count > 0)
                {
				// add the quantity of notes to the output
                    output.Add(note.Key, count);
                    // update the amount
                    amount -= count * note.Key;
				// subtract from total cash available
				TotalAvailableCash -= amount;
				// update inventory count of note
				NoteInventory[note.Key] -= count;
                }
            }

            return output;
        }

    }

