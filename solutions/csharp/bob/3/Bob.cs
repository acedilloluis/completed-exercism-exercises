public static class Bob
{
    public static bool IsYelling(this string str) =>
        str.ToUpper() == str && str.Any(c => Char.IsLetter(c));
    
    public static string Response(string statement)
    {
        string str = statement.TrimEnd();
        if (str == "")
            return "Fine. Be that way!";

        switch ((str.EndsWith("?"), str.IsYelling())) {
            case (true, true): return "Calm down, I know what I'm doing!";
            case (true, _): return "Sure.";
            case (_, true): return "Whoa, chill out!";
            default: return "Whatever.";
        }
    }
}