using System;
using System.Collections.Generic;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
	int total = 0;
	foreach(T item in input)
	    total++;
	return total;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
	if (input.Count == 0)
	    return input;
	
	int endPointer = input.Count - 1;
	int startPointer = 0;
	while(endPointer > startPointer)
	{
	    T temp = input[endPointer];
	    input[endPointer] = input[startPointer];
	    input[startPointer] = temp;
	    endPointer--;
	    startPointer++;
	}
	return input;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
	if (input.Count == 0)
	    return new List<TOut>();
	
	List<TOut> output = new List<TOut>();
	
        foreach(TIn item in input)
	    output.Add(map(item));
	
	return output;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
	List<T> output = new List<T>();
	
	foreach(T item in input)
	{
	    if(predicate(item))
		output.Add(item);
	}
	return output;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
	TOut output = start;
	
	foreach(TIn item in input)
	    output = func(output, item);
	
	return output;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
	TOut output = start;
	
	foreach(TIn item in Reverse(input))
	    output = func(item, output);

	return output;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
	List<T> output = new List<T>();
	foreach(List<T> list in input)
	{
	    foreach(T item in list)
		output.Add(item);
	}
	return output;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
	foreach(T item in right)
	    left.Add(item);
	return left;
    }
}
