public class Player
{
    public int RollDie()
    {
	Random die = new Random();
	return die.Next(1, 19);
    }

    public double GenerateSpellStrength()
    {
	Random strength = new Random();
	return strength.NextDouble() * 100;
    }
}
