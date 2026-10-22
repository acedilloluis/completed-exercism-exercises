static class LogLine
{
    public static string Message(string logLine) {
        int indexOfColon = logLine.Trim().IndexOf(": ");
        return logLine.Substring(indexOfColon + 2).Trim();
    }
    
    public static string LogLevel(string logLine)
    {
        string trimmedLogLine = logLine.Trim();        
        int idxOpenBracket = trimmedLogLine.IndexOf("[");
        int idxCloseBracket = trimmedLogLine.IndexOf("]");
        return trimmedLogLine.Substring(idxOpenBracket + 1, idxCloseBracket - 1).ToLower();
    }

    public static string Reformat(string logLine) => $"{Message(logLine)} ({LogLevel(logLine)})";
}
