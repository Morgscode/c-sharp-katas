namespace Stack.Tests;

using System.Reflection;
using Stack;

public class StackTests
{

    [Fact]
    public void ThrowsForInvalidCapacity()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new XStack(0));
        Assert.Equal("Specified argument was out of the range of valid values. (Parameter 'capacity')", exception.Message);
        exception = Assert.Throws<ArgumentOutOfRangeException>(() => new XStack(-50));
        Assert.Equal("Specified argument was out of the range of valid values. (Parameter 'capacity')", exception.Message);
    }

    [Fact]
    public void HasGetSizeMethod()
    {
        var type = typeof(XStack);
        var methodInfo = type.GetMethod("GetSize", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void HasGetCapacityMethod()
    {
        var type = typeof(XStack);
        var methodInfo = type.GetMethod("GetCapacity", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void SetsTheStackCapacity()
    {
        XStack stack = new XStack(50);
        Assert.Equal(50, stack.GetCapacity());
    }

    [Fact]
    public void SetsTheStackSize()
    {
        XStack stack = new XStack(50);
        Assert.Equal(0, stack.GetSize());
    }

    [Fact]
    public void HasPushMethod()
    {
        var type = typeof(XStack);
        var methodInfo = type.GetMethod("Push", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void PushMethodReturnsNewStackSize()
    {
        XStack stack = new XStack(50);
        Assert.Equal(0, stack.GetSize());
        var size = stack.Push(21);
        Assert.Equal(1, size);
        stack.Push(33);
        stack.Push(69);
        size = stack.Push(420);
        Assert.Equal(4, size);
    }

    [Fact]
    public void PushMethodAddsInputToEndOfStack()
    {
        XStack stack = new XStack(50);
        stack.Push(50);
        Assert.Equal(50, stack.Peek());
    }

    [Fact]
    public void HasPopMethod()
    {
        var type = typeof(XStack);
        var methodInfo = type.GetMethod("Pop", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void PopMethodReturnsLastItemInStack()
    {
        XStack stack = new XStack(50);
        var newSize = stack.Push(50);
        Assert.Equal(50, stack.Pop());
    }

    [Fact]
    public void PopMethodTakesItemOffEndOfStack()
    {
        XStack stack = new XStack(50);
        var newSize = stack.Push(50);
        Assert.Equal(50, stack.Pop());
        Assert.Null(stack.PeekStackItemByIndex(newSize - 1));
        stack.Push(1);
        stack.Push(2);
        newSize = stack.Push(42069);
        Assert.Equal(42069, stack.Pop());
        Assert.Null(stack.PeekStackItemByIndex(newSize - 1));
    }

    [Fact]
    public void HasPeekMethod()
    {
        var type = typeof(XStack);
        var methodInfo = type.GetMethod("Peek", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void PeekMethodReturnsLastItemInStack()
    {
        var stack = new XStack(50);
        Assert.Null(stack.Peek());
    }

    [Fact]
    public void MaintainsStackSize()
    {
        var stack = new XStack(50);
        stack.Push(1);
        Assert.Equal(1, stack.GetSize());
        stack.Push(2);
        Assert.Equal(2, stack.GetSize());
        stack.Push(33);
        stack.Push(69);
        stack.Push(33);
        stack.Push(69);
        stack.Push(33);
        stack.Push(69);
        Assert.Equal(8, stack.GetSize());
        stack.Pop();
        stack.Pop();
        Assert.Equal(6, stack.GetSize());
    }

    [Fact]
    public void CanPeekStackItemByIndex()
    {
        var type = typeof(XStack);
        var methodInfo = type.GetMethod("PeekStackItemByIndex", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(methodInfo);

        XStack stack = new XStack(50);
        Assert.Null(stack.PeekStackItemByIndex(0));
        Assert.Null(stack.PeekStackItemByIndex(1));
        stack.Push(2);
        stack.Push(1);
        Assert.Equal(2, stack.PeekStackItemByIndex(0));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(50)]
    public void PeekItemByIndexThrowsForInvalidInput(int index)
    {
        XStack stack = new XStack(50);
        stack.Push(420);
        stack.Push(69);
        var exception = Assert.Throws<ArgumentOutOfRangeException>(()=> stack.PeekStackItemByIndex(index));
        Assert.Equal("Specified argument was out of the range of valid values. (Parameter 'index')", exception.Message);
    }

    [Fact]
    public void HasEmptyMethod()
    {
        var type = typeof(XStack);
        var methodInfo = type.GetMethod("EmptyCheck", BindingFlags.Public | BindingFlags.Instance);
        Assert.NotNull(methodInfo);
    }

    [Fact]
    public void EmptyCheckReturnsTrueWhenStackEmpty()
    {
        XStack stack = new XStack(50);
        Assert.True(stack.EmptyCheck());
        stack.Push(1);
        stack.Push(2);
        stack.Pop();
        stack.Pop();
        Assert.True(stack.EmptyCheck());
    }

    [Fact]
    public void EmptyCheckReturnsFalseWhenStackHasItems()
    {
        XStack stack = new XStack(50);
        stack.Push(1);
        Assert.False(stack.EmptyCheck());
        stack.Pop();
        Assert.True(stack.EmptyCheck());
        stack.Push(420);
        stack.Push(69);
        Assert.False(stack.EmptyCheck());
    }
}
