using System.Linq;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if 
        ( 
            inputBase <= 1 || 
            outputBase <= 1 ||
            inputDigits.Any(digit => digit < 0 || digit >= inputBase)
        )
            throw new ArgumentException();
        if
        (
            inputDigits.Length == 0 ||
            Array.TrueForAll(inputDigits, digit => digit == 0)
        )
            return new int[] {0};

        int inBaseNum = 
            inputDigits
                .Aggregate(0, (accumulator, digit) => digit + inputBase * accumulator);

        return convertToOutBase(new int[] {}, inBaseNum, outputBase);
    }

    public static int[] convertToOutBase(int[] outBaseDigits, int digit, int outBase)
    {
        if (digit < outBase)
            return [digit, ..outBaseDigits];

        int remainder = digit % outBase;
        return convertToOutBase([remainder, ..outBaseDigits], digit / outBase, outBase);
    }
}