using System.Diagnostics;
using _03a_Necklace.Models;
using Seido.Utilities.SeedGenerator;

namespace _03a_Necklace;

class Program
{
    static void Main(string[] args)
    {
        var rnd = new SeedGenerator();
        Console.WriteLine("Hello, Perls!");

        var p2 = new Pearl(rnd);
        Console.WriteLine(p2);

        var n1 = new Necklace(5, "My first necklace");
        Console.WriteLine(n1);

        var (minPearl, maxPearl) = n1.GetMinMaxPearl();
        Console.WriteLine($"Smallest pearl: {minPearl}");
        Console.WriteLine($"Largest pearl: {maxPearl}");        
    }
}


