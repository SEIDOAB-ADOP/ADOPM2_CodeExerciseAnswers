// See https://aka.ms/new-console-template for more information
using _01a_Seeder.Models;
using Seido.Utilities.SeedGenerator;

Console.WriteLine("Hello from Martin and Cars!");
Console.WriteLine("Hello from Martin and Cars!");
//Create a generator, inherited from .NET Random

var rnd = new SeedGenerator();

Car c1 = new Car().Seed(rnd);
Car c2 = new Car().Seed(rnd);

Console.WriteLine($"\nRandom Car {c1}");
Console.WriteLine($"\nRandom Car {c2}");

var cars = rnd.ItemsToList<Car>(100);


/* Excercise:
 * 1. Create a new Model "Person" with properties FirstName, LastName, Age,
 * 2. Create a Seed method for Person
 * 3. Override ToString to return e.g. "John Doe, 30 years"
 
 * 4. Add a property to Car "Owner" of type Person
 * 5. In the list of 100 Cars, make a car have an owner with 50% chance
 * 6. Print out the list of cars, including owner info if available
*/