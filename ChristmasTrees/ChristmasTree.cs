namespace ChristmasTrees;

public class XmasTree
{
    public static string GrowTree(int size)
    {
        if (size < 2) throw new ArgumentOutOfRangeException(nameof(size));

        int spaces = size;
        int xChars = 1;
     
        string output = "";

        for (int i = 0; i < size; i++)
        {
            // calculate spaces for top and bottom (always the height)
            int localSpaces = (i == 0 || i == size) ? size : spaces;
            for (int j = 0; j < localSpaces; j++)
            {
                output += " ";
              
            }
            // calculate the x chars
            // with each iteration - add 2 x chars
          
            for (int j = 0; j < xChars; j++)
            {
                output += "X";
            }

            // add a newline
            output += "\n";
            // with each iteration - remove one from spaces
            spaces--;
            xChars += 2;
        }

        // add the spaces for the trunk
        for (int i = 0; i < size; i++)
        {
            output += " ";
        }

        // add the trunk
        output += "|";

        Console.WriteLine(output);

        return output;
    }
}


