abstract class Character
{
    private string _characterType; 
        
    protected Character(string characterType) =>
         _characterType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() =>
        false;

    public override string ToString() =>
        $"Character is a {_characterType}";
}

class Warrior : Character
{
    public Warrior() : base(nameof(Warrior))
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
            return 10;
        else
            return 6;
    }
}

class Wizard : Character
{
    public bool preparedSpell = false;
    
    public Wizard() : base(nameof(Wizard))
    {
    }

    public override int DamagePoints(Character target)
    {
        if (preparedSpell)
            return 12;
        else
            return 3;
    }

    public override bool Vulnerable() =>
        !preparedSpell;

    public void PrepareSpell() =>
        preparedSpell = true;
}
