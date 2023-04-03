// See https://aka.ms/new-console-tempslate for more information
Console.WriteLine("Hello, World!");


// Create a loop that prints all values from 1-255.
// for(int i = 0; i <= 255; i++) 
// {
//     Console.WriteLine(i);
// }



// Create a new loop that generates 5 random numbers between 10 and 20.
// Random randNum = new Random(); 
// for(int i = 0; i < 5; i++)
// {
//     Console.WriteLine(randNum.Next(10,20));
// }

// Modify the previous loop to add the random values together and print the sum after the loop finishes.
// Random randNum = new Random(); 
// int result = 0;
// for(int i = 0; i < 5; i++)
// {
//     result = result + randNum.Next(10,20);
    
// }
// Console.WriteLine(result);



// Create a new loop that prints all values from 1 to 100 that are divisible by 3 OR 5, but NOT both.
// for (int i = 0; i <= 100; i++)
// {
//      if((i % 3) == 0 && (i % 5) != 0)
//     {
//         Console.WriteLine(i);
//     } else if ((i % 5) == 0 && (i % 3) != 0) 
//     {
//         Console.WriteLine(i);
//     }
    
// }

// Modify the previous loop to print "Fizz" for multiples of 3 and "Buzz" for multiples of 5.

// for (int i = 0; i <= 100; i++)
// {
//      if((i % 3) == 0 && (i % 5) != 0)
//     {
//         Console.WriteLine("fizz");
//     } else if ((i % 5) == 0 && (i % 3) != 0) 
//     {
//         Console.WriteLine("buzz");
//     }
    
// }


// Modify the previous loop once more to now also print "FizzBuzz" for numbers that are multiples of both 3 and 5.

for (int i = 0; i <= 100; i++)
{
     if((i % 3) == 0 && (i % 5) != 0)
    {
        Console.WriteLine("fizz");
    } else if ((i % 5) == 0 && (i % 3) != 0) 
    {
        Console.WriteLine("buzz");
    }
    if ((i % 3) == 0 && (i % 5) == 0)
    {
        Console.WriteLine("fizzbuzz");
    }
}
