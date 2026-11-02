public class CalculationException : Exception
{
    public CalculationException(int operand1, int operand2, string message, Exception inner)
    // TODO: complete the definition of the constructor
    {
	this.Operand1 = operand1;
	this.Operand2 = operand2;
	this.CalcMessage = message;
	this.Inner = inner;
    }

    public int Operand1 { get; }
    public int Operand2 { get; }
    public string CalcMessage { get; }
    public Exception Inner { get; }
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
	catch (CalculationException err)
	{
	    return $"{err.CalcMessage} {err.Inner.Message}";
	}
    }

    public void Multiply(int x, int y)
    {
	try
	{
	    calculator.Multiply(x, y);
	}
	catch (OverflowException err) when (x < 0 && y < 0)
	{
	    throw new CalculationException(x, y, "Multiply failed for negative operands.", err);
	}
	catch (OverflowException err) when (x > 0 || y > 0)
	{
	    throw new CalculationException(x, y, "Multiply failed for mixed or positive operands.", err);
	}
	catch (OverflowException err)
	{
	    throw new CalculationException(x, y, "Too Big", err);
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
