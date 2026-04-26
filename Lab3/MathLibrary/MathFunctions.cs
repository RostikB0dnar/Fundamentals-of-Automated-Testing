namespace MathLibrary;

public static class MathFunctions
{
    public static double Modulus(double a, double b)
    {
        return a % b;
    }

    public static double Power(double a, double b)
    {
        return Math.Pow(a, b);
    }

    public static double Sqrt(double a)
    {
        return Math.Sqrt(a);
    }
}