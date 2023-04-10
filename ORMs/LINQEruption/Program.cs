// See https://aka.ms/new-console-template for more information



// !! WORKED WITH PEYTON AND JACOB

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// Use LINQ to find the first eruption that is in Chile and print the result.

IEnumerable<Eruption> ChileFirst = eruptions.Where(q => q.Location == "Chile").Take(1);
PrintEach(ChileFirst);


// Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
Eruption? Hawiian = eruptions.FirstOrDefault(q => q.Location == "Hawaiian Is");
if(Hawiian != null)
{
    Console.WriteLine(Hawiian);
}
else 
{
    Console.WriteLine( "No Hawaiian Is Eruption found." );
}

// Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
Eruption? Greenland = eruptions.FirstOrDefault(q => q.Location == "Greenland");
if(Greenland != null)
{
    Console.WriteLine(Greenland);
}
else 
{
    Console.WriteLine( "No Greenland Eruption found" );
}


// Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.

Eruption? Kiwi = eruptions.FirstOrDefault(q => q.Year > 1900 && q.Location == "New Zealand");

Console.WriteLine(Kiwi);

// Find all eruptions where the volcano's elevation is over 2000m and print them.
 IEnumerable<Eruption> tallVolcano = eruptions.Where(q => q.ElevationInMeters > 2000);
 PrintEach(tallVolcano);


// Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.

IEnumerable<Eruption> StartsWithL = eruptions.Where(q => q.Volcano.StartsWith("L"));
PrintEach(StartsWithL);
Console.WriteLine($"Number found: {StartsWithL.Count()}");

// Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)

int HighestElevation = eruptions.Max(q => q.ElevationInMeters);
Console.WriteLine($"Highest Elevation is {HighestElevation}");

// Use the highest elevation variable to find and print the name of the Volcano with that elevation.

Eruption? HighestName = eruptions.First(q => q.ElevationInMeters == HighestElevation);
Console.WriteLine($"The highest elevation volcano is {HighestName.Volcano}");

// Print all Volcano names alphabetically.

IEnumerable<string> VolAtoZ = eruptions.OrderBy(q => q.Volcano).Select(q => q.Volcano).ToList(); 

foreach (string name in VolAtoZ)
{
Console.WriteLine(name);
}

// Print the sum of all the elevations of the volcanoes combined.
int sumEle = eruptions.Sum(q => q.ElevationInMeters);
Console.WriteLine($"Total Elevation = {sumEle}");

// Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)
bool in2000 = eruptions.Any(q => q.Year == 2000);
if(in2000)
{
    Console.WriteLine("Yep");
}
else
{
    Console.WriteLine("Nope");
}


// Find all stratovolcanoes and print just the first three (Hint: look up Take)
IEnumerable<Eruption> Strat = eruptions.Where(q => q.Type == "Stratovolcano").Take(3);
PrintEach(Strat);

// Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
IEnumerable<Eruption> before1000 = eruptions.Where(q => q.Year < 1000).OrderBy(q => q.Volcano);
PrintEach(before1000);

// Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
IEnumerable<string> before1000pt2 = eruptions.Where(q => q.Year < 1000).OrderBy(q => q.Volcano).Select(q =>q.Volcano);

foreach (string name in before1000pt2)
{
Console.WriteLine(name);
}

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
