public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner) : base(message, inner)
    {
	this.Operand1 = operand1;
	this.Operand2 = operand2;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
}

public class CalculatorTestHarness
{
    private Calculator calculator;

    public CalculatorTestHarness(Calculator calculator)
    {
        this.calculator = calculator;
    }

    public string TestMultiplication(int x, int y)
    {
	try
	{
	    Multiply(x, y);
	    return "Multiply succeeded";
	}
	catch (CalculationException err) when (err.Operand1 < 0 && err.Operand2 < 0)
	{
	    return $"Multiply failed for negative operands. {err.InnerException.Message}";
	}
	catch (CalculationException err)
	{
	    return $"Multiply failed for mixed or positive operands. {err.InnerException.Message}";
	}
    }

    public void Multiply(int x, int y)
    {
	try
	{
	    calculator.Multiply(x, y);
	}
	catch (OverflowException err)
	{
	    throw new CalculationException(x, y, "", err);
	}
    }
}


// Please do not modify the code below.
// If there is an overflow in the multiplication operation
// then a System.OverflowException is thrown.
public class Calculator
{
    public int Multiply(int x, int y)
    {
        checked
        {
            return x * y;
        }
    }
}
