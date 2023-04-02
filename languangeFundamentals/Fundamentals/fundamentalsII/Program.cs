// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


// Create an integer array with the values 0 through 9 inside.
int[] arr = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

// Create a string array with the names "Tim", "Martin", "Nikki", and "Sara".
string[] arr2 = {"Tim", "Martin", "Nikki", "Sara" };

// Create a boolean array of length 10. Then fill it with alternating true/false values, starting with true. (Tip: do this using logic! Do not hard-code the values in!)
bool[] arr3 = new bool[10]; 
arr3[0] = true;
arr3[1] = false;
arr3[2] = true;
arr3[3] = false;
arr3[4] = true;
arr3[5] = false;
arr3[6] = true;
arr3[7] = false;
arr3[8] = true;
arr3[9] = false;

foreach (bool value in arr3)
{
    Console.WriteLine(value);
}

// Create a string List of ice cream flavors that holds at least 5 different flavors. (Feel free to add more than 5!)
List<string> stringList = new List<string>() {"Vanilla", "Chocolate", "Strawberry", "PhishFood", "Cheesecake"};

// Output the length of the List after you added the flavors.
Console.WriteLine(stringList.Count);

// Output the third flavor in the List.
Console.WriteLine(stringList[2]);

// Now remove the third flavor using its index location.
stringList.Remove("Strawberry");
Console.WriteLine(stringList[2]);

// Output the length of the List again. It should now be one fewer.
Console.WriteLine(stringList.Count);

// Create a dictionary that will store string keys and string values.
Dictionary<string,string> dict = new Dictionary<string,string>();

// Add key/value pairs to the dictionary where:
// Each key is a name from your names array (this can be done by hand or using logic)
// Each value is a randomly selected flavor from your flavors List (remember Random from earlier?)
for(int i = 0; i < arr2.Length; i++)
{
    dict.Add(arr2[i], stringList[i]);
}

// Loop through the dictionary and print out each user's name and their associated ice cream flavor.
foreach (KeyValuePair<string,string> entry in dict )
{
    Console.WriteLine(entry);
}
