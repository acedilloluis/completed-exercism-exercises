public static class Bob
{
    public static bool IsQuestion(this string str) => 
        str.EndsWith("?");

    public static bool IsYelling(this string str) =>
        str.ToUpper() == str && str.ToLower() != str;

    public static bool IsSilence(this string str) =>
        string.IsNullOrWhiteSpace(str);
    
    public static string Response(string statement)
    {
        string str = statement.Trim();
        
        if (str.IsQuestion() && str.IsYelling())
            return "Calm down, I know what I'm doing!";
        if (str.IsQuestion())
            return "Sure.";
        if (str.IsSilence())
            return "Fine. Be that way!";
        if (str.IsYelling())
            return "Whoa, chill out!";
        else
            return "Whatever.";
        
    }
}