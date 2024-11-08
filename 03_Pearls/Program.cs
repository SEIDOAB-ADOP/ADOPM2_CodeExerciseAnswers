﻿using System.Diagnostics;
using Helpers;

namespace _03_Pearls;

public enum enPearlColor { Black, White, Pink }
public enum enPearlShape { Round, DropShaped }
public enum enPearlType { FreshWater, SaltWater }

public class csPearl
{
    public const int PearlMinSize = 5;
    public const int PearlMaxSize = 25;

    public enPearlColor Color { get; set; }
    public enPearlShape Shape { get; set; }
    public enPearlType Type { get; set; }

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


    public csPearl() { }
    public csPearl(csSeedGenerator _seeder)
    {
        Size = _seeder.Next(PearlMinSize, PearlMaxSize + 1);
        Color = _seeder.FromEnum<enPearlColor>();
        Shape = _seeder.FromEnum<enPearlShape>();
        Type = _seeder.FromEnum<enPearlType>();
    }
    public csPearl(int _size, enPearlColor _color, enPearlShape _shape, enPearlType _type)
    {
        Size = _size;
        Color = _color;
        Shape = _shape;
        Type = _type;
    }
    public csPearl(csPearl org)
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
        var rnd = new csSeedGenerator();
        Console.WriteLine("Hello, Perls!");

        var p2 = new csPearl(rnd);
        Console.WriteLine(p2);


        var p = new csPearl(5, enPearlColor.White, enPearlShape.DropShaped, enPearlType.SaltWater);
        Console.WriteLine(p);

        /*
        var p2c = new csPearl(p2);
        Console.WriteLine(p2c);
        */


        var pdc = new csPearl(p);
        pdc.Color = enPearlColor.Black;
        Console.WriteLine(pdc);
        Console.WriteLine(p);

        var psc = p;
        psc.Color = enPearlColor.Black;
        Console.WriteLine(psc);
        Console.WriteLine(p);


        //Create a necklace
        csPearl[] necklace = new csPearl[10];
        for (int i = 0; i < 10; i++)
        {
            necklace[i] = new csPearl(rnd) { Type = enPearlType.SaltWater};
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
        csPearl[] necklace_copy = new csPearl[10];
        for (int i = 0; i < necklace_copy.Length; i++)
        {
            necklace_copy[i] = new csPearl(necklace[i]);
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
