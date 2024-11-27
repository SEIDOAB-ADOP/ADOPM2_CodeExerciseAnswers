using _05_Wines_Interfaces;
using Seido.Utilities.SeedGenerator;

namespace _07_IEquatable_IComparable;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("07_IEquatable_IComparable");

        var rnd = new SeedGenerator();
        var p1 = new PearlAsClass(rnd);
        Console.WriteLine(p1);

        var p1_copy = new PearlAsClass(p1);
        Console.WriteLine(p1_copy);

        Console.WriteLine(p1.Equals(p1_copy));
        Console.WriteLine(p1 == p1_copy);

        var p3 = new PearlAsClass(rnd);
        Console.WriteLine(p3);
        Console.WriteLine(p1.Equals(p3));
        Console.WriteLine(p1 == p3);

        var n1 = new Necklace(100, "Pearl necklace");
        n1.ListOfPearls.Sort();
        Console.WriteLine(n1);

        var n2 = new Necklace(n1);
        Console.WriteLine(n2);

        Console.WriteLine(n1.Equals(n2));



        //Wines
        var w1 = new Wine().Seed(rnd);
        var w2 = new Wine().Seed(rnd);

        Console.WriteLine(w1 == w2);
        Console.WriteLine(w1.Equals(w2));
        Console.WriteLine(w1.GetHashCode());
        Console.WriteLine(w2.GetHashCode());

        var w3 = new Wine(w1);
        Console.WriteLine(w1 == w3);
        Console.WriteLine(w1.Equals(w3));
        Console.WriteLine(w1.GetHashCode());
        Console.WriteLine(w3.GetHashCode());

        var wineCellar = new WineCellar();
        wineCellar.Wines.Add(w1);
        wineCellar.Wines.Add(w2);
        wineCellar.Wines.Add(w3);

        Console.WriteLine(wineCellar);
    }
}

//Exercise:
// 1. Implementera IEquatable på csPearl
// 2. Skapa två instanser av csPearl och testa om de är lika. Tips, tänk på att
//    har en copy constructor i csPearl som enkelt skapar en kopia av instansen
// 3. Implementera operator == och != overload i csPearl och använd dessa i
//    jämförelsen
// 4. Implementera IComparable på csPearl, skapa ett halsband med 100 pärlor.
//    och sortera halsbandet först efter pärlornas storlek och sedan form 
// 5. Implementera IEqutable på csNecklace
// 6. Skapa en copy constructor i csNecklace
// 7. Skapa två instanser av csNecklace och testa om de är lika. 

// 8. Ni som är snabba gör 1 -7  med csWine och cswineCellar.
//    sortera vinerna efter distrikt och sedan pris.

