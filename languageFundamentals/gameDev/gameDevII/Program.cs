// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Attack NinjaStar = new Attack("Ninja Star", 24);
Attack Punch = new Attack("Punched", 15);
Attack Slap = new Attack("Slap", 20);
Attack Arrow = new Attack("It's Arrow Time", 20);
Attack Knife = new Attack("Shanked", 15);
Attack Fireball = new Attack("spitting that fire", 25);
Attack LightningBolt = new Attack("Where there's thunder there's lightning ", 20);
Attack Stick = new Attack("beat with a stick", 10);



MeleeFighter theSlapMan  = new MeleeFighter();
RangedFighter Johnathan = new RangedFighter();
MagicCaster SpellMan = new MagicCaster();

theSlapMan.AddAttack(Slap);
theSlapMan.AddAttack(Punch);
theSlapMan.AddAttack(NinjaStar);
Johnathan.AddAttack(Arrow);
Johnathan.AddAttack(Knife);
SpellMan.AddAttack(Fireball);
SpellMan.AddAttack(LightningBolt);
SpellMan.AddAttack(Stick);


theSlapMan.PerformAttack(Johnathan, Slap);
theSlapMan.Rage(SpellMan, Punch);

Johnathan.Dash(Johnathan);

SpellMan.PerformAttack(theSlapMan, Stick);
SpellMan.Heal(Johnathan);
SpellMan.Heal(theSlapMan);

