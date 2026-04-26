using FluentAssertions;

namespace MathLibrary.Tests;

public class MathFunctionsTests
{
    // ---------------- MODULUS ----------------
    [Fact]
    public void Modulus_PositiveNumbers_ReturnsCorrectResult()
    {
        MathFunctions.Modulus(10, 3).Should().Be(1);
    }

    [Fact]
    public void Modulus_NegativeDividend_ReturnsCorrectResult()
    {
        MathFunctions.Modulus(-10, 3).Should().Be(-1);
    }

    [Fact]
    public void Modulus_NegativeDivisor_ReturnsCorrectResult()
    {
        MathFunctions.Modulus(10, -3).Should().Be(1);
    }

    [Fact]
    public void Modulus_ZeroDividend_ReturnsZero()
    {
        MathFunctions.Modulus(0, 5).Should().Be(0);
    }

    [Fact]
    public void Modulus_DivisionByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => MathFunctions.Modulus(10, 0));
    }

    // ---------------- POWER ----------------
    [Fact]
    public void Power_PositiveExponent_ReturnsCorrectResult()
    {
        MathFunctions.Power(2, 3).Should().Be(8);
    }

    [Fact]
    public void Power_ZeroExponent_ReturnsOne()
    {
        MathFunctions.Power(5, 0).Should().Be(1);
    }

    [Fact]
    public void Power_NegativeExponent_ReturnsCorrectResult()
    {
        MathFunctions.Power(2, -1).Should().Be(0.5);
    }

    [Fact]
    public void Power_ZeroBase_ReturnsZero()
    {
        MathFunctions.Power(0, 5).Should().Be(0);
    }

    [Fact]
    public void Power_FractionalExponent_ReturnsCorrectResult()
    {
        MathFunctions.Power(9, 0.5).Should().Be(3);
    }

    // ---------------- SQRT ----------------
    [Fact]
    public void Sqrt_PositiveNumber_ReturnsCorrectResult()
    {
        MathFunctions.Sqrt(16).Should().Be(4);
    }

    [Fact]
    public void Sqrt_Zero_ReturnsZero()
    {
        MathFunctions.Sqrt(0).Should().Be(0);
    }

    [Fact]
    public void Sqrt_Fraction_ReturnsCorrectResult()
    {
        MathFunctions.Sqrt(0.25).Should().Be(0.5);
    }

    [Fact]
    public void Sqrt_NegativeNumber_ReturnsNaN()
    {
        MathFunctions.Sqrt(-4).Should().Be(double.NaN);
    }

    [Fact]
    public void Sqrt_LargeNumber_ReturnsCorrectResult()
    {
        MathFunctions.Sqrt(1000000).Should().Be(1000);
    }
}