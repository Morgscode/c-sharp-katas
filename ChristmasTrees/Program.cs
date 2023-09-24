using ChristmasTrees;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter the size for your Christmas tree:");
if (int.TryParse(Console.ReadLine(), out int size))
{
    try
    {
        XmasTree.GrowTree(size);
    }
    catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine($"Error: {e.Message}");
    }
}
else
{
    Console.WriteLine("Please enter a valid size (integer value)!");
}







