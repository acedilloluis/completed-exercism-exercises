using System;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) =>
	Math.Pow(Math.Pow(realNumber, r.Numerator), 1.0 / r.Denominator); 
}

public struct RationalNumber
{
    public readonly int Numerator { get; }
    public readonly int Denominator { get; }
    
    public RationalNumber(int numerator, int denominator)
    {
	Numerator = numerator;
	Denominator = denominator;
    }

    //helper functions
    private static int CommonDenominator(RationalNumber r1, RationalNumber r2) =>
	r1.Denominator * r2.Denominator;

    private static int CommonNumerator(RationalNumber r1, RationalNumber r2, Func<int, int, int> operation) =>
	operation(r1.Numerator * r2.Denominator, r2.Numerator * r1.Denominator);

    private static int GetGcd(int n, int m)
    {
	while (m != 0)
	{
	    int remainder = n % m;
	    n = m;
	    m = remainder;
	}
	return Math.Abs(n);
    }
	
    //binary operations
    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2) =>
	new RationalNumber(CommonNumerator(r1, r2, (a, b) => a + b), CommonDenominator(r1, r2)).Reduce();

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2) =>
	new RationalNumber(CommonNumerator(r1, r2, (a, b) => a - b), CommonDenominator(r1, r2)).Reduce();

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) =>
	new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator).Reduce();

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) =>
	new RationalNumber(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator).Reduce();

    //unary operations
    public RationalNumber Abs() =>
	new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator)).Reduce();

    public RationalNumber Reduce()
    {
	int gcd = GetGcd(Numerator, Denominator);
	int denominator = Denominator < 0 ? -Denominator : Denominator;
	int numerator = Denominator < 0 ? -Numerator : Numerator;
	return new RationalNumber(numerator / gcd, denominator / gcd);
    }

    public RationalNumber Exprational(int power) =>
	power >= 0 ?
	new RationalNumber((int)Math.Pow(Numerator, power), (int)Math.Pow(Denominator, power)).Reduce() :
	new RationalNumber((int)Math.Pow(Denominator, -power), (int)Math.Pow(Numerator, -power)).Reduce();

    public double Expreal(int baseNumber) =>
	Math.Pow(Numerator, baseNumber) / Math.Pow(Denominator, baseNumber);
}
