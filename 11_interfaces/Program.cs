// See https://aka.ms/new-console-template for more information
using _11_interfaces.Models;
using Seido.Utilities.SeedGenerator;

Console.WriteLine("Hello, World!");
var rnd = new SeedGenerator();

IPerson p = new PersonAsClass().Seed(rnd);
Console.WriteLine(p);

var c = new CarAsClass().Seed(rnd);
Console.WriteLine(c);

var cars = new List<ICar>();
for (int i = 0; i < 50; i++)
{
    cars.Add(new CarAsClass().Seed(rnd));
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

1. Declare a class PersonAsClass that implements IPerson. Seed() should set random values to all props
2. Declare a class CarAsClass that implements ICar. Seed() should set random values to all props
   and use new PersonAsClass() when instatiating IPerson.
3. Use GetType() in ToString() to show the type of the ICar when presenting the car
4. In Program.cs create a list ICar, that should contain 50 cars
5. Print to the console the 10 oldest and youngest cars

6. Declare a struct PersonAsStruct that implements IPerson. Seed() should set random values to all props
7. Declare a struct CarAsStruct that implements ICar. Seed() should set random values to all props
   and use new PersonAsStruct() when instatiating IPerson.
8. Use GetType() in ToString() to show the type of the ICar when presenting the car
9. Add 50 cars of CarAsStruct to the list of cars.
10. Print to the console the 10 oldest and youngest cars

 */
