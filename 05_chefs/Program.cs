using Seido.Utilities.SeedGenerator;

namespace _05_chefs;

public class Chef
{
    public virtual string Name => "Boring";

    public virtual string Hello => $"Hello";
    public virtual string FavoriteDish => "nothing";

    public override string ToString() => $"{Hello}, I am {Name}. I like {FavoriteDish}";

}

public class FrenchChef : Chef
{
    public override string Name => "Pierre";

    public override string Hello => $"Bonjour";
    public override string FavoriteDish => "Escargo";
}

public class GermanChef : Chef
{
    public override string Name => "Heinz";

    public override string Hello => $"Guten Tag";
    public override string FavoriteDish => "Wurtz";
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Chefs!");


        FrenchChef fc = new FrenchChef();
        Console.WriteLine(fc);

        GermanChef gc = new GermanChef();
        Console.WriteLine(gc);

        var list = new List<Chef>();
        list.Add(fc);
        list.Add(gc);

        foreach (var chef in list)
        {
            Console.WriteLine(chef);
        }
    }
}

//Exercises
// 1. Create a FrechChef named Pierre who says Bonjour and likes Escargo
// 2. Create a GermanChef named Heinz who says Guten Tag and likes Wurtz
// 3. Create a list of 10 mixed german and french chefs.
//    Have the chefs present themselves correctly through polymorfism


