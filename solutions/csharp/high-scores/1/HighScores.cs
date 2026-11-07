using System;
using System.Linq;
using System.Collections.Generic;

public class HighScores
{
    private List<int> highScores;
    
    public HighScores(List<int> list) =>
	highScores = list;

    public List<int> Scores() =>
	highScores;

    public int Latest() =>
	highScores[^1];

    public int PersonalBest() =>
	highScores.Max();
    
    public List<int> PersonalTopThree()
    {
        List<int> topThree = new List<int>();
	List<int> temp = new List<int>(highScores);
	int iterations = highScores.Count < 3 ? highScores.Count : 3;
	
	for(int i = 0; i < iterations; i++)
	{
	    topThree.Add(temp.Max());
	    temp.Remove(temp.Max());
	}
	return topThree;
    }
}
