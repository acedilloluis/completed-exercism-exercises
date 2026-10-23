public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public enum Student
{
    Alice, 
    Bob, 
    Charlie, 
    David, 
    Eve, 
    Fred, 
    Ginny, 
    Harriet, 
    Ileana, 
    Joseph, 
    Kincaid, 
    Larry
}

public class KindergartenGarden
{
    private string _diagram;
    
    public KindergartenGarden(string diagram)
    {
        _diagram = diagram;
    }

    public string DeterminePots(string student) {
        int index = (int)Enum.Parse(typeof(Student), student);
        int startOfSecondRow = _diagram.Length / 2 + 1;
        return _diagram.Substring(2 * index, 2) + _diagram.Substring(2 * index + startOfSecondRow, 2);  
    }

    public IEnumerable<Plant> Plants(string student)
    {
        string pots = DeterminePots(student);
        foreach (char pot in pots)
            yield return (Plant)pot;
    }
}