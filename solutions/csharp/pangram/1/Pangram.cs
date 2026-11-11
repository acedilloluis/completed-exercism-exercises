public static class Pangram
{
    public static bool IsPangram(string input)
    {
	HashSet<char> alphabet = new HashSet<char>(
	    "abcdefghijklmnopqrstuvwxyz"
	);
	HashSet<char> inputChars = new HashSet<char>(
	    input.Trim().ToLower()
	);

	return alphabet.IsSubsetOf(inputChars);
    }
}
