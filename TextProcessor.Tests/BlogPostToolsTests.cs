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
    [InlineData("Hello, World!", 2)]
    [InlineData("Hello  World", 2)]
    [InlineData("   Hello   World   ", 2)]
    [InlineData("Hello\tWorld", 2)]
    [InlineData("Hello\nWorld", 2)]
    [InlineData("HELLO WORLD", 2)]
    [InlineData("This is a simple sentence.", 5)]
    [InlineData("I am learning how to write unit tests in C#.", 10)]
    [InlineData("Wait, what?", 2)]
    [InlineData("Wait, ! what?", 2)]
    [InlineData("No, I don't think so...", 5)]
    [InlineData("This is line one.\nThis is line two.", 8)]
    [InlineData("Spaces    between     words.", 3)]
    [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", 19)]
    [InlineData("When in the Course of human events, it becomes necessary for one people to dissolve the political bands which have connected them with another...", 24)]
    public void CanCalculateTotalWords(string input, int output)
    {
        Assert.Equal(output, BlogPostTools.GetTotalWords(input));
    }
}
