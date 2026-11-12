using System;
using System.Linq;

public class DndCharacter
{
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }
    public int Hitpoints { get; private set; }

    private static readonly Random die = new Random();

    public DndCharacter(
	int strength,
	int dexterity,
	int constitution,
	int intelligence,
	int wisdom,
	int charisma
    )
    {
	Strength = strength;
	Dexterity = dexterity;
	Constitution = constitution;
	Intelligence = intelligence;
	Wisdom = wisdom;
	Charisma = charisma;
	Hitpoints = 10 + Modifier(Constitution);
    }

    public static int Modifier(int score) =>
	(int)Math.Floor((score - 10) * 0.5);

    public static int Ability() 
    {
	int[] dice = RollDice();
        int min = dice.Min();
	return dice.Aggregate(0, (acc, die) => acc + die) - min;
    }

    public static DndCharacter Generate() =>
	new DndCharacter(
	    Ability(),
	    Ability(),
	    Ability(),
	    Ability(),
	    Ability(),
	    Ability()
	);

    private static int[] RollDice()
    {
	int[] dice = new int[4];

	for (int i = 0; i < 4; i++)
	    dice[i] = die.Next(1, 7);

	return dice;
    }
}
