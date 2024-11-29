using _12_interfaces.Models;
using Seido.Utilities.SeedGenerator;

Console.WriteLine("Hello, World!");
var rnd = new SeedGenerator();

IPerson p = new PersonAsRecord().Seed(rnd); //new PersonAsClass().Seed(rnd);
Console.WriteLine(p);

var c = new CarAsRecord().Seed(rnd); //new CarAsClass().Seed(rnd);
Console.WriteLine(c);

var cars = new List<ICar>();
for (int i = 0; i < 50; i++)
{
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
