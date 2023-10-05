using System.Text.RegularExpressions;

namespace TextProcessor;

public class BlogPostTools
{
    public BlogPostTools()
    {
    }

    public static Dictionary<string, object> Analyse(string input)
    {
        Dictionary<string, object> output = new Dictionary<string, object>
        {
            { "most common words", new Dictionary<string, int> {} },
            { "total words", 0 }
        };

        output["total words"] = GetTotalWords(input);

        return output;
    }

    public static Dictionary<string, int> GetMostCommonWords(string text, Dictionary<string, int> dict)
    {
        return dict;
    }

    public static int GetTotalWords(string text)
    {

        text = text.Trim();
        text = text.ToLower();
        text = Regex.Replace(text, @"\s+", " "); // Removing Extra White Spaces
        text = Regex.Replace(text, @"[^\w\s]", "");// Removing Punctuation
        text = Regex.Replace(text, @"\s+", " "); // Handling Various Delimiters
        text = Regex.Replace(text, @"\d", ""); // Handling Special Characters
        text = text.Trim();

        if (Regex.IsMatch(text, @"^\s*$")) return 0;

        return text.Split(" ").Length;
    }
}


