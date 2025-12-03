// See https://aka.ms/new-console-template for more information
using Seido.Utilities.SeedGenerator;
using _15_polymorphism.Models;

Console.WriteLine("Hello Polymorphism!");

var seeder = new SeedGenerator();
var animal = new Animal().Seed(seeder);
System.Console.WriteLine(animal);

var animals = seeder.ItemsToList<Animal>(5);
foreach (var a in animals)
{
    System.Console.WriteLine(a);
}

#region 1-Exercise-inheritance
var nordicAnimal = new NordicAnimal().Seed(seeder);
System.Console.WriteLine(nordicAnimal);

var africanAnimal = new AfricanAnimal().Seed(seeder);
System.Console.WriteLine(africanAnimal);

var hunterBird = new HunterBird().Seed(seeder);
System.Console.WriteLine(hunterBird);

System.Console.WriteLine("--- Demonstrating method chaining ---");
hunterBird.Fly().Hunt().Rest();
#endregion

#region 2-Exercise-polymorphism
System.Console.WriteLine("--- Demonstrating polymorphism ---");
var zoo = new Zoo() { Name = "City Zoo" };

for (int i = 0; i < 5; i++)
{
    var ani = new NordicAnimal().Seed(seeder);
    zoo.ListOfAnimal.Add(ani);
}

zoo.ListOfAnimal.AddRange(seeder.ItemsToList<NordicAnimal>(5));
zoo.ListOfAnimal.AddRange(seeder.ItemsToList<AfricanAnimal>(5));
zoo.ListOfAnimal.AddRange(seeder.ItemsToList<HunterBird>(5));

foreach (var a in zoo.ListOfAnimal)
{
    System.Console.WriteLine(a);
}

foreach (var a in zoo.ListOfAnimal)
{
    System.Console.WriteLine($"{a}. Says: {a.MakeSound()}");
}


#endregion