using System;

public class Robot
{
    private static readonly HashSet<string> names = new HashSet<string>();
    private static readonly Random rng = new Random();
    private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    public Robot() =>
	Name = GenerateName();

    private string GenerateName()
    {
	string name = rng.GetString(letters, 2) + rng.Next(0, 1000).ToString("D3");
	    
	while (names.Contains(name))
	    name = rng.GetString(letters, 2) + rng.Next(0, 1000).ToString("D3");

	names.Add(name);
	return name;
    }
    
    public string Name { get; private set; }

    public void Reset() =>
	Name = GenerateName();
}
