using System;
using System.Linq;

public class CustomSet
{
    private HashSet<int> _values;
    
    public CustomSet(params int[] values) =>
	_values = new HashSet<int>(values);

    public int Length(CustomSet values) =>
        values._values.Count;
    
    public CustomSet Add(int value)
    {
	_values.Add(value);
	return new CustomSet(_values.ToArray());
    }

    public bool Empty() =>
	_values.Count == 0;

    public bool Contains(int value) =>
	_values.Contains(value);

    public bool Subset(CustomSet right) =>
	_values.IsSubsetOf(right._values);

    public bool Disjoint(CustomSet right) =>
	!_values.Overlaps(right._values);

    public CustomSet Intersection(CustomSet right)
    {
	_values.IntersectWith(right._values);
	return new CustomSet(_values.ToArray());
    }

    public CustomSet Difference(CustomSet right)
    {
	_values.ExceptWith(right._values);
	return new CustomSet(_values.ToArray());
    }

    public CustomSet Union(CustomSet right)
    {
	_values.UnionWith(right._values);
	return new CustomSet(_values.ToArray());
    }

    //equality
    public override bool Equals(Object? obj) =>
	obj is CustomSet right && _values.SetEquals(right._values);

    public override int GetHashCode()
    {
	HashCode hash = new HashCode();
	foreach (int num in _values)
	    hash.Add(num);
	return hash.ToHashCode();
    }
}
