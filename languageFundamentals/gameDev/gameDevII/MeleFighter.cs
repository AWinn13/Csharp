
class MeleeFighter : Enemy 
{
    public MeleeFighter() : base("theSlapMan", 120)
    {}

    public void Rage(Enemy Target, Attack ChosenAttack)
    {
        ChosenAttack.DamageAmount = ChosenAttack.DamageAmount + 10;
        Target.Health = Target.Health - ChosenAttack.DamageAmount;
        Console.WriteLine($"{Target.Name} was hit with {ChosenAttack.DamageAmount} damage and now has {Target.Health} health");

    }

}