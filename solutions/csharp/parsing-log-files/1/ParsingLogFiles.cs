using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class LogParser
{
    private const string validLineRegexPattern = @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
    private const string splitLineRegexPattern = @"<[\^*=-]+>";
    private const string quotedPasswordRegexPattern = @""".*password.*""";
    private const string endOfLineRegexPattern = @"end-of-line\d+";
    private const string weakPasswordRegexPattern = @"password\w+";
    
    public bool IsValidLine(string text) =>
	Regex.IsMatch(text, validLineRegexPattern); 

    public string[] SplitLogLine(string text) =>
	Regex.Split(text, splitLineRegexPattern);

    public int CountQuotedPasswords(string lines) =>
	Regex.Matches(lines, quotedPasswordRegexPattern, RegexOptions.IgnoreCase).Count();

    public string RemoveEndOfLineText(string line) =>
	Regex.Replace(line, endOfLineRegexPattern, string.Empty);

    public string[] ListLinesWithPasswords(string[] lines)
    {
	List<string> processedLines = new List<string>();
	foreach(string line in lines)
	{
	    Match passwordMatch = Regex.Match(line, weakPasswordRegexPattern, RegexOptions.IgnoreCase);

	    if (passwordMatch == Match.Empty)
		processedLines.Add($"--------: {line}");
	    else
		processedLines.Add($"{passwordMatch.Value}: {line}");
	}

	return processedLines.ToArray();
    }
}
