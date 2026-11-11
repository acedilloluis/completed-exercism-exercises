public static class Isogram
{
    public static bool IsIsogram(string word)
    {
	string letters = word
	    .Replace("-", "")
	    .Replace(" ", "")
	    .Trim()
	    .ToLower();
	HashSet<char> uniqueLetters  = new HashSet<char>(letters);
	return letters.Length == uniqueLetters.Count;
    }
}
