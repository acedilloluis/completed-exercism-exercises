using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value) =>
	Value = value;

    public BinarySearchTree(IEnumerable<int> values)
    {
	Value = values.First();
	foreach (int value in values.Skip(1))
	    Add(value);
    }

    public int Value { get; private set; }

    public BinarySearchTree? Left { get; private set; }

    public BinarySearchTree? Right { get; private set; }

    public BinarySearchTree Add(int value)
    {
	if (value <= Value)
	{
	    Left = Left is not null ?
		Left.Add(value) :
		new BinarySearchTree(value);
	}
	else
	{
	    Right = Right is not null ?
		Right.Add(value) :
		new BinarySearchTree(value);
	}

	return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
	if (Left is not null)
	    foreach (int subtreeValues in Left)
		yield return subtreeValues;

	yield return Value;

	if (Right is not null)
	    foreach (int subtreeValues in Right)
		yield return subtreeValues;
    }

    IEnumerator IEnumerable.GetEnumerator() =>
	GetEnumerator();
}
