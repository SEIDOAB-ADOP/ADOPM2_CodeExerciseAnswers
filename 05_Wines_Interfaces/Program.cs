using System.Xml.Linq;
using Seido.Utilities.SeedGenerator;
namespace _05_Wines_Interfaces;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Wines with Interface!");

        var rnd = new SeedGenerator();
        WineCellar wineCellar = new WineCellar("Martin's cellar");

        #region Add wines to the winecellar
        /*
        wineCellar.Add(new csWine().Seed(rnd));
        wineCellar.Add(new stWine().Seed(rnd));
        */

        for (int i = 0; i < 5; i++)
        {
            wineCellar.Add(new WineAsClass().Seed(rnd));
            wineCellar.Add(new WineAsStruct().Seed(rnd));
        }
        #endregion

        Console.WriteLine($"\nWinecellar: {wineCellar.Name}");
        //wineCellar.Wines = null;
        //wineCellar.Wines[0] = new csWine();
        //Console.WriteLine(wineCellar);

        /*
        Console.WriteLine($"Nr of bottles: {wineCellar.Count}");
        */
        Console.WriteLine($"Value of winecellar: {wineCellar.Value:N2} Sek");

        var hilo = wineCellar.WineHiLoCost();
        Console.WriteLine($"\nMost expensive wine:\n{hilo.hicost}");
        Console.WriteLine($"Least expensive wine:\n{hilo.locost}");


        Console.WriteLine("\nMyCellar");
        Console.WriteLine(wineCellar);


        //wineCellar.Wines = null;
        //wineCellar.Wines[0] = null;
        //wineCellar.Wines[2] = null;

        Console.WriteLine("\nSpecial focus");
        Console.WriteLine(wineCellar[0]);
        Console.WriteLine(wineCellar[2]);

        wineCellar[0].Name = "BulliBupp";
        wineCellar[2].Name = "BulliBupp";

        Console.WriteLine("\nPoison focus");
        Console.WriteLine(wineCellar[0]);
        Console.WriteLine(wineCellar[2]);

        Console.WriteLine("\nMyCellar");
        Console.WriteLine(wineCellar);
        

        /*
        Console.WriteLine("\nIndexers");
        for (int i = 0; i < wineCellar.Count; i++)
        {
            Console.WriteLine(wineCellar[i]);
        }
        */
    }
}

/* Exercises
1. Implement csWine and stWine
2. Add some wines to the cellar of both csWine and stWine, notice you can mix
*/

