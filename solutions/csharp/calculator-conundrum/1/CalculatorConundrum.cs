public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if (operation == null)
            throw new ArgumentNullException();
        if (operation == "")
            throw new ArgumentException();
        if (operation != "/" && operation != "*" && operation != "+")
            throw new ArgumentOutOfRangeException();
        if (operation == "/" && operand2 == 0)
            return "Division by zero is not allowed.";

        int result = 0;
        if (operation == "/")
            result = operand1 / operand2;
        if (operation == "*")
            result = operand1 * operand2;
        if (operation == "+")
            result = operand1 + operand2;

        return $"{operand1} {operation} {operand2} = {result}";
    }
}
