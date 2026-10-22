public static class Bob
{
    public static bool IsQuestion(this string str) => str.EndsWith("?");

    public static bool IsYelling(this string str) {
        if ( string.IsNullOrEmpty(str) 
           || Array.TrueForAll(str.ToCharArray(0, str.Length - 1), c => !Char.IsLetter(c))
           )
            return false;
        else
            return str.ToUpper() == str;
    }
    
    public static string Response(string statement)
    {
        string str = statement.Trim();
        
        if (str.IsQuestion() && str.IsYelling())
            return "Calm down, I know what I'm doing!";
        if (str.IsQuestion())
            return "Sure.";
        if (string.IsNullOrWhiteSpace(str))
            return "Fine. Be that way!";
        if (str.IsYelling())
            return "Whoa, chill out!";
        else
            return "Whatever.";
        
    }
}