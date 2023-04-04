
class MagicCaster : Enemy 
{
    public MagicCaster() : base("SpellMan", 80)
    {

    }
    public void Heal(Enemy Target)
    {
        Target.Health = Target.Health + 40;
        Console.WriteLine($"{Target.Name} was healed by {Name} and now has {Target.Health} health");
    }
}