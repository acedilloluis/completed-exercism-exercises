public static class Raindrops
{
    public static string CheckDivisibility(int number, int divisor) =>
	divisor switch
        {
	    3 => number % 3 == 0 ? "Pling" : string.Empty,
	    5 => number % 5 == 0 ? "Plang" : string.Empty,
	    7 => number % 7 == 0 ? "Plong" : string.Empty,
	    _ => throw new ArgumentException()
        };
    
    public static string Convert(int number)
    {
	string raindropSounds =
	    CheckDivisibility(number, 3) + CheckDivisibility(number, 5) + CheckDivisibility(number, 7);

	if(raindropSounds == string.Empty)
	    return number.ToString();
	else
	    return raindropSounds;
    }
}
