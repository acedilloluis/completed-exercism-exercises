using System;

public class Robot
{
    private static HashSet<string> names = new HashSet<string>();
    private string _name = "";

    public Robot() =>
	GenerateName();

    private void GenerateName()
    {
	Random rng = new Random();
	const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	string name = rng.GetString(letters, 2) + rng.Next(0, 1000).ToString("D3");
	    
	while (names.Contains(name))
	    name = rng.GetString(letters, 2) + rng.Next(0, 1000).ToString("D3");

	names.Add(name);
	_name = name;
    }
    
    public string Name
    {
        get
        {   
	    return _name; 
        }
    }

    public void Reset() =>
	GenerateName();
}
