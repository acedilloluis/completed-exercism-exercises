public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType CheckForSublist<T>(List<T> largerList, List<T> smallerList, SublistType sublistType) where T : IComparable
    {
	if (smallerList.Count == 0)
	    return sublistType;
	
	for(int i = 0; i < largerList.Count - smallerList.Count + 1; i++)
	{
	    int j = 0;
	    while(j < smallerList.Count && largerList[i + j].CompareTo(smallerList[j]) == 0)
		j++;
	    if(j == smallerList.Count)
		return sublistType;
	}
	return SublistType.Unequal;
    }
    
    public static SublistType Classify<T>(List<T> list1, List<T> list2) where T : IComparable
    {
	if (list1.Count > list2.Count)
	    return CheckForSublist(list1, list2, SublistType.Superlist);
	else if (list2.Count > list1.Count)
	    return CheckForSublist(list2, list1, SublistType.Sublist);
	else
	    return CheckForSublist(list1, list2, SublistType.Equal);
    }
}
