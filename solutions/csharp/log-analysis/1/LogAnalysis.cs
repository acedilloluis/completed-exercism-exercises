public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delimiter) => 
        str.Substring(str.IndexOf(delimiter) + delimiter.Length);

    public static string SubstringBetween(this string str, string delimiter1, string delimiter2) =>
        str.Substring(str.IndexOf(delimiter1) + delimiter1.Length, str.IndexOf(delimiter2) - str.IndexOf(delimiter1) - delimiter1.Length);
    
    public static string Message(this string str) => str.SubstringAfter(": ");

    public static string LogLevel(this string str) => str.SubstringBetween("[", "]");
}