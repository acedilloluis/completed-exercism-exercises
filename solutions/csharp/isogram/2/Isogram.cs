public static class Isogram
{
    public static bool IsIsogram(string word)
    {
	return word.ToLower()
	    .Where(Char.IsLetter)
	    .GroupBy(letter => letter)
	    .All(g => g.Count() == 1);
    }
}
