using System;
using System.Text;

public static class Identifier
{    
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder();
        string[] words = identifier.Split('-');

        for (int i = 0; i < words.Length; i++)
        {
            if (i != 0)
                words[i] = Char.ToUpper(words[i][0]) + words[i].Substring(1); 
            
            foreach (char c in words[i])
            {
                if (Char.IsWhiteSpace(c))
                    sb.Append('_');
                else if (Char.IsControl(c))
                    sb.Append("CTRL");
                else if (c >= 'α' && c <= 'ω')
                    continue;
                else if (Char.IsLetter(c)) 
                    sb.Append(c);
            }
        }

        return sb.ToString();
    }
}
