using _12_interfaces.Models;
using Seido.Utilities.SeedGenerator;

Console.WriteLine("Hello, World!");
var rnd = new SeedGenerator();

//IPerson p = new PersonAsClass().Seed(rnd);
IPerson p = new PersonAsRecord().Seed(rnd); 
Console.WriteLine(p);

//ICar c = new CarAsClass().Seed(rnd);
var c = new CarAsRecord().Seed(rnd); 
Console.WriteLine(c);

var cars = new List<ICar>();
for (int i = 0; i < 50; i++)
{
//    cars.Add(new CarAsClass().Seed(rnd));
    cars.Add(new CarAsRecord().Seed(rnd));
}

Console.WriteLine("\n\nOldest Cars");
foreach (var item in cars.OrderBy(c => c.Year).Take(10))
{
    Console.WriteLine(item);
}

Console.WriteLine("\n\nYoungest Cars");
foreach (var item in cars.OrderByDescending(c => c.Year).Take(10))
{
    Console.WriteLine(item);
}


/* Exercises

1. Declare a class PersonAsRecord that implements IPerson. Seed() should set random values to all props
2. Declare a class CarAsRecord that implements ICar. Seed() should set random values to all props
   and use new PersonAsRecord() when instatiating IPerson.
3. Modify only the three lines where you instantiate (new ...) IPerson and ICar (around lines 8, 12, 19) 
4. Run the program now using immutable records instead of an immutable classes
 */
