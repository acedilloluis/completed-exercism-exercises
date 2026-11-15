public static class SumOfMultiples
{
    //copied from cprobbie's solution
    public static int Sum(IEnumerable<int> multiples, int max) =>
	Enumerable
	    .Range(0, max)
	    .Where(x => multiples.Any(i => i != 0 && x % i == 0))
	    .Sum();
}
