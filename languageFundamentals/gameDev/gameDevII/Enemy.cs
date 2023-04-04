class Enemy
{
    public string Name;
    public int Health = 100;
    public List<Attack> AttackList = new List<Attack>();

    public Enemy(string name, int health = 100)
    {
        Name = name;
        Health = health;

    }

    public void RandomAttack()
    {
        if (AttackList.Count > 0)
        {
            Random random = new Random();
            int i = random.Next(0, AttackList.Count);
            Attack attack = AttackList[i];
            Console.WriteLine($"{Name} used {attack.Name} and gave {attack.DamageAmount} damage");
        }
        else
        {
            Console.WriteLine("NO ATTACKS");
        }


    }

    public virtual void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        Target.Health = Target.Health - ChosenAttack.DamageAmount;
        Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target.Health}!!");
    }

    public virtual void AddAttack(Attack attack)
    {
        AttackList.Add(attack);
    }





}