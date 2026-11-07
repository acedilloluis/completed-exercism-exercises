using System;
using System.Linq;
using System.Collections.Generic;

public class HighScores
{
    private readonly List<int> highScores;
    
    public HighScores(List<int> list) =>
	highScores = list;

    public List<int> Scores() =>
	highScores;

    public int Latest() =>
	highScores.Last();

    public int PersonalBest() =>
	highScores.Max();
    
    public List<int> PersonalTopThree() =>
	highScores.OrderByDescending(x => x).Take(3).ToList();
}
