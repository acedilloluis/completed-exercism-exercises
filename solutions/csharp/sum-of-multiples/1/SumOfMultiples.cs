public static class SumOfMultiples
{	
    public static int Sum(IEnumerable<int> multiples, int max)
    {
	HashSet<int> uniqueMultiples = new HashSet<int>();
	 
	foreach (int multiple in multiples)
	{
	    if (multiple == 0)
		continue;
	    
	    int multiplier = 1;
	    int energy = multiple * multiplier;
	    while (energy < max)
	    {
		uniqueMultiples.Add(energy);
		multiplier += 1;
		energy = multiple * multiplier;
	    }
	}

	return uniqueMultiples.Aggregate(0, (acc, multiple) => acc + multiple);
    }
}
