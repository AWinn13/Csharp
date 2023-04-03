// See https://aka.ms/new-console-template for more information

Attack ninjaStar = new Attack("Ninja Star", 44);
Attack fistTotheFace = new Attack("Punched", 25);
Attack slap = new Attack("Slap", 75);

Enemy jabbaTheHut = new Enemy("Jabba");

jabbaTheHut.AddAttack(slap);
jabbaTheHut.AddAttack(fistTotheFace);
jabbaTheHut.AddAttack(ninjaStar);

jabbaTheHut.RandomAttack();


