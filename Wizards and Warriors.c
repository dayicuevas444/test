public abstract class Character
{
    public override string ToString()
    {
        return $"Character is a {GetType().Name}";
    }

    public virtual bool Vulnerable()
    {
        return false;
    }

    public abstract int DamagePoints(Character target);
}

public class Warrior : Character
{
    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
        {
            return 10;
        }

        return 6;
    }
}

public class Wizard : Character
{
    private bool _spellPrepared;

    public void PrepareSpell()
    {
        _spellPrepared = true;
    }

    public override bool Vulnerable()
    {
        return !_spellPrepared;
    }

    public override int DamagePoints(Character target)
    {
        if (_spellPrepared)
        {
            return 12;
        }

        return 3;
    }
    public static void Main(string[] args)
    {
        Character warrior = new Warrior();
        Character wizard = new Wizard();

        Console.WriteLine(warrior.ToString());
        Console.WriteLine(wizard.ToString());

        Console.WriteLine($"Warrior damage to Wizard: {warrior.DamagePoints(wizard)}");
        Console.WriteLine($"Wizard damage to Warrior: {wizard.DamagePoints(warrior)}");

        ((Wizard)wizard).PrepareSpell();
        Console.WriteLine($"Wizard damage to Warrior after preparing spell: {wizard.DamagePoints(warrior)}");
    }
}
