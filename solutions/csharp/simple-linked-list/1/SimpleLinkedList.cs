using System;
using System.Collections;
using System.Collections.Generic;

public class SimpleLinkedList<T> : IEnumerable<T>
{   
    //need to implement GetEnumerator and IEnumerable.GetEnumerator
    //GetEnumerator is public and IEnumerable.GetEnumerator is private
    public IEnumerator<T> GetEnumerator()
    {
	Node currentNode = _head;
	while (currentNode != null)
	{
	    yield return currentNode.Value;
	    currentNode = currentNode.Next;
	}
    }

    IEnumerator IEnumerable.GetEnumerator() =>
	GetEnumerator();
    
    private class Node
    {
	public T Value { get; set; }
	public Node Next{ get; set; }
    }

    private Node _head;

    public SimpleLinkedList(params T[] items)
    {
	foreach (T item in items)
	    Push(item);
    }

    public int Count { get; private set; }
    
    public void Push(T value)
    {
	Node node = new Node { Value = value, Next = _head };
	_head = node;
	Count += 1;
    }

    public T Pop()
    {
	if (Count == 0)
	    throw new InvalidOperationException("List is empty");

	T data = _head.Value;
	_head = _head.Next;
	Count -= 1;
	return data;
    }

    public SimpleLinkedList<T> Reverse()
    {
	List<T> items = new List<T>();

	while (Count != 0)
	    items.Add(Pop());

	return new SimpleLinkedList<T>(items.ToArray());
    }
}
