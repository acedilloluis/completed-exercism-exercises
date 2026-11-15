using System.Collections;

public static class FlattenArray
{   
    public static IEnumerable Flatten(IEnumerable input)
    {
	foreach (var value in input)
	{
	    if (value is IEnumerable nested)
	    {
		foreach (var nestedValue in Flatten(nested))
		    yield return nestedValue;
	    }
	    else if (value is not null)
		yield return value;
	}
    }
}
