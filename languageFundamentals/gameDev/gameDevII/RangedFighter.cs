

class RangedFighter : Enemy 
{
    public int Distance;

    public RangedFighter(int distance = 5) : base("Johnathan", 90)
    {

    }
     public void Dash(RangedFighter Target)
    {
        Target.Distance = Target.Distance + 10;
        Console.WriteLine($"{Target.Name} ran for it distance is now {Target.Distance}");
    }




}