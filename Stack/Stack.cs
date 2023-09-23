namespace Stack;

public struct XStack
{

    private int?[] Stack;
    private int Size;
    private readonly int Capacity;

    public XStack(int capacity)
    {
        if (capacity < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }

        Capacity = capacity;
        Stack = new int?[capacity];
        Size = 0;  // Initially, the stack should have a size of 0 because it's empty.
    }

    public int GetCapacity()
    {
        return Capacity;
    }

    public int GetSize()
    {
        return Size;
    }

    public int Push(int input)
    {
        Stack[Size] = input;
        Size++;
        return Size;
    }

    public int? Pop()
    {
        var result = Stack[Size == 0 ? Size : Size - 1];
        Stack[Size == 0 ? Size : Size - 1] = null;
        Size--;
        return result;
    }

    public int? Peek()
    {
        return Stack[Size == 0 ? Size : Size - 1];
    }

    public int? PeekStackItemByIndex(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        if (index > (Capacity - 1)) throw new ArgumentOutOfRangeException(nameof(index));
        return Stack[index];
    }

    public bool EmptyCheck()
    {
        return Size == 0 ? true : false;
    }

}


