using System.Diagnostics;
using Seido.Utilities.SeedGenerator;

namespace _03_Pearls;

public enum PearlColor { Black, White, Pink }
public enum PearlShape { Round, DropShaped }
public enum PearlType { FreshWater, SaltWater }

public class Pearl
{
    public const int PearlMinSize = 5;
    public const int PearlMaxSize = 25;

    public PearlColor Color { get; set; }
    public PearlShape Shape { get; set; }
    public PearlType Type { get; set; }

    private int _size;
    public int Size
    {
        get => _size;
        set
        {
            if (value < PearlMinSize || value > PearlMaxSize)
            {
                throw new ArgumentOutOfRangeException(nameof(Size));
            }
            _size = value;
        }
    }

    public override string ToString() => $"{Size}mm {Color} {Shape} {Type} pearl.";


    public Pearl() { }
    public Pearl(SeedGenerator _seeder)
    {
        Size = _seeder.Next(PearlMinSize, PearlMaxSize + 1);
        Color = _seeder.FromEnum<PearlColor>();
        Shape = _seeder.FromEnum<PearlShape>();
        Type = _seeder.FromEnum<PearlType>();
    }
    public Pearl(int _size, PearlColor _color, PearlShape _shape, PearlType _type)
    {
        Size = _size;
        Color = _color;
        Shape = _shape;
        Type = _type;
    }
    public Pearl(Pearl org)
    {
        Size = org.Size;
        Color = org.Color;
        Shape = org.Shape;
        Type = org.Type;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var rnd = new SeedGenerator();
        Console.WriteLine("Hello, Perls!");

        var p2 = new Pearl(rnd);
        Console.WriteLine(p2);


        var p = new Pearl(5, PearlColor.White, PearlShape.DropShaped, PearlType.SaltWater);
        Console.WriteLine(p);

        /*
        var p2c = new csPearl(p2);
        Console.WriteLine(p2c);
        */


        var pdc = new Pearl(p);
        pdc.Color = PearlColor.Black;
        Console.WriteLine(pdc);
        Console.WriteLine(p);

        var psc = p;
        psc.Color = PearlColor.Black;
        Console.WriteLine(psc);
        Console.WriteLine(p);


        //Create a necklace
        Pearl[] necklace = new Pearl[10];
        for (int i = 0; i < 10; i++)
        {
            necklace[i] = new Pearl(rnd) { Type = PearlType.SaltWater};
        }

        //Present it to the user
        Console.WriteLine("\nThis is the neclace");
        foreach (var item in necklace)
        {
            Console.WriteLine(item);
        }


        //Find min and max pear
        int maxSize = int.MinValue;
        int maxIdx = 0;
        int minSize = int.MaxValue;
        int minIdx = 0;
        for (int i = 0; i < 10; i++)
        {
            if (necklace[i].Size > maxSize)
            {
                maxSize = necklace[i].Size;
                maxIdx = i;
            }
            if (necklace[i].Size < minSize)
            {
                minSize = necklace[i].Size;
                minIdx = i;
            }
        }

        //Present it to the user
        Console.WriteLine("\nThis is the neclace");
        foreach (var item in necklace)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"Largest pearl: {necklace[maxIdx]}");
        Console.WriteLine($"Smalest pearl: {necklace[minIdx]}");

        Console.WriteLine("\n\nA necklace copy");
        Pearl[] necklace_copy = new Pearl[10];
        for (int i = 0; i < necklace_copy.Length; i++)
        {
            necklace_copy[i] = new Pearl(necklace[i]);
        }
        foreach (var item in necklace_copy)
        {
            Console.WriteLine(item);
        }

    }
}

//Exercise:
// 1. Modellera en pärlan i en C# class. Utmärkande för en pärla är
//    Storlek: Diameter 5mm till 25mm
//    Färg: Svart, Vit, Rosa
//    Form: Rund, Droppformad
//    Typ: Sötvatten, Saltvatten
//
// 2. När pärlan väl är skapad så ska man inte kunna ändra den.

// 3. Gör om constructor csPearl(csSeedGenerator _seeder) som initierar en slumpmässig pärla

// 4. Skapa en ToString i din pärlklass som presenterar pärlan.
//
// 5. Skapa ett halsband bestående av 10 pärlor av slumpmässig storlek, färg
//    form, och typ
//
// 6. Skriv kod som visar vilken färg, form och typ har den minsta och den största pärlan i halsbandet?
//
// 7. Deklarera en contruktor som tillåter dig att själv bestämma alla csPearl public properties
//
// 8. Deklarera en Copy constructor.
//
// 9. Använd copy constructorn för att skapa ett nytt halsband som är en kopia av ursprunget
