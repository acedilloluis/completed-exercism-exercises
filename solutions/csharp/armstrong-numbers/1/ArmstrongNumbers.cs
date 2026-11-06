using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
	if (number == 0)
	    return true;
	
	int numberOfDigits = (int)Math.Log10(Math.Abs(number)) + 1;
	int total = 0;
	int tempNumber = number;

	while (tempNumber != 0)
	{
	    int digit = tempNumber % 10;
	    total += (int)Math.Pow(digit, numberOfDigits);
	    tempNumber /= 10;
	}

	return number == total;
    }
}
