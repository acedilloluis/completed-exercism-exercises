using System;

public struct ComplexNumber
{
    private readonly double Re;
    private readonly double Im;
    
    public ComplexNumber(double real, double imaginary)
    {
	Re = real;
	Im = imaginary;
    }

    public double Real() => Re;

    public double Imaginary() => Im;

    //binary operations: complex number, complex number
    public ComplexNumber Mul(ComplexNumber other) =>
	new ComplexNumber(Re * other.Re - Im * other.Im, Im * other.Re + Re * other.Im); 

    public ComplexNumber Add(ComplexNumber other) =>
	new ComplexNumber(Re + other.Re, Im + other.Im);

    public ComplexNumber Sub(ComplexNumber other) =>
	new ComplexNumber(Re - other.Re, Im - other.Im);

    public ComplexNumber Div(ComplexNumber other)
    {
	double denominator = Math.Pow(other.Re, 2) + Math.Pow(other.Im, 2);
	double reNumerator = Re * other.Re + Im * other.Im;
	double imNumerator = Im * other.Re - Re * other.Im;
	return denominator == 0 ?
	    throw new ArgumentException() :
	    new ComplexNumber(reNumerator / denominator, imNumerator / denominator);
    }

    //binary operations: complex number, real number
    public ComplexNumber Mul(double other) =>
	new ComplexNumber(Re * other, Im * other); 

    public ComplexNumber Add(double other) =>
	new ComplexNumber(Re + other, Im);

    public ComplexNumber Sub(double other) =>
	new ComplexNumber(Re - other, Im);

    public ComplexNumber Div(double other)
    {
	double denominator = Math.Pow(other, 2);
	double reNumerator = Re * other;
	double imNumerator = Im * other;
	return denominator == 0 ?
	    throw new ArgumentException() :
	    new ComplexNumber(reNumerator / denominator, imNumerator / denominator);
    }
    
    //unary operations
    public double Abs() =>
        Math.Sqrt(Math.Pow(Re, 2) + Math.Pow(Im, 2)); 

    public ComplexNumber Conjugate() =>
	new ComplexNumber(Re, -Im);
    
    public ComplexNumber Exp() =>
	new ComplexNumber(Math.Exp(Re) * Math.Cos(Im), Math.Exp(Re) * Math.Sin(Im));
}
