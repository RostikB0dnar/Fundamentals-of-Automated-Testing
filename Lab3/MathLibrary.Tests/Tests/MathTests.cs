namespace MathLibrary.Tests.Tests;

public class MathTests
{
    [Fact]
    public void Add_Test()
    {
        Assert.Equal(4, 2 + 2);
    }

    [Fact]
    public void Multiply_Test()
    {
        Assert.Equal(10, 2 * 5);
    }

    [Fact]
    public void IsEven_Test()
    {
        Assert.True(10 % 2 == 0);
    }

    [Fact]
    public void String_NotNull()
    {
        Assert.NotNull("test");
    }

    [Fact]
    public void Compare_Test()
    {
        Assert.True(5 > 3);
    }
}