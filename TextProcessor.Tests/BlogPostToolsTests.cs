namespace TextProcessor.Tests;

using System.Reflection;
using TextProcessor;

public class BlogPostToolsTests
{
    [Fact]
    public void HasAnalyseMethod()
    {
        // Arrange
        Type type = typeof(BlogPostTools);
        // Act
        MethodInfo info = type.GetMethod("Analyse");
        // Assert
        Assert.NotNull(info);
    }

    [Theory]
    [InlineData("Hello World", 2)]
    [InlineData("One Two Three Four", 4)]
    [InlineData("", 0)]
    [InlineData("Hello", 1)]
    [InlineData("   ", 0)]
    //[InlineData("Hello, World!", 2)]
    //[InlineData("Hello  World", 2)]
    //[InlineData("   Hello   World   ", 2)]
    //[InlineData("Hello\tWorld", 2)]
    //[InlineData("Hello\nWorld", 2)]
    //[InlineData("HELLO WORLD", 2)]
    public void CanCalculateTotalWords(string input, int output)
    {
        Assert.Equal(output, BlogPostTools.GetTotalWords(input));
    }
}
