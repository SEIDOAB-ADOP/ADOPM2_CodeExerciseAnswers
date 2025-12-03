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

foreach (Animal a in zoo.ListOfAnimal)
{
    System.Console.WriteLine();
    System.Console.WriteLine($"{a}");
    a.Seed(seeder);
    System.Console.WriteLine($"{a}");
}

#endregion

#region 3-Exercise-copy-constructors
var originalZoo = new Zoo() { Name = "Original Zoo" };
originalZoo.ListOfAnimal.AddRange(seeder.ItemsToList<NordicAnimal>(2));

var referenceCopy = new Zoo(originalZoo) { Name = "Reference Copy Zoo"};
referenceCopy.ListOfAnimal.Add(new AfricanAnimal().Seed(seeder));
referenceCopy.ListOfAnimal.Add(new HunterBird().Seed(seeder));

System.Console.WriteLine($"\noriginalZoo Count: {originalZoo.ListOfAnimal.Count}");
foreach (var a in originalZoo.ListOfAnimal)
{
    System.Console.WriteLine(a);
}
System.Console.WriteLine($"\nreferenceCopy Count: {referenceCopy.ListOfAnimal.Count}");
foreach (var a in referenceCopy.ListOfAnimal)
{
    System.Console.WriteLine(a);
}

/*
var shallowCopy = new Zoo(originalZoo) { Name = "Shallow Copy Zoo"};
shallowCopy.ListOfAnimal.Add(new AfricanAnimal().Seed(seeder));
shallowCopy.ListOfAnimal.Add(new HunterBird().Seed(seeder));

shallowCopy.ListOfAnimal[0].Name = "Modified Name";

System.Console.WriteLine($"\noriginalZoo Count: {originalZoo.ListOfAnimal.Count}");
System.Console.WriteLine($"\nshallowCopy Count: {shallowCopy.ListOfAnimal.Count}");
foreach (var a in originalZoo.ListOfAnimal)
{
    System.Console.WriteLine(a);
}
foreach (var a in shallowCopy.ListOfAnimal)
{
    System.Console.WriteLine(a);
}
*/

/*
var deepCopy = new Zoo(originalZoo) { Name = "Deep Copy Zoo"};
deepCopy.ListOfAnimal.Add(new AfricanAnimal().Seed(seeder));
deepCopy.ListOfAnimal.Add(new HunterBird().Seed(seeder));

deepCopy.ListOfAnimal[0].Name = "Modified Name";

System.Console.WriteLine($"\noriginalZoo Count: {originalZoo.ListOfAnimal.Count}");
System.Console.WriteLine($"\ndeepCopy Count: {deepCopy.ListOfAnimal.Count}");
foreach (var a in originalZoo.ListOfAnimal)
{
    System.Console.WriteLine(a);
}
foreach (var a in deepCopy.ListOfAnimal)
{
    System.Console.WriteLine(a);
}
*/

#endregion