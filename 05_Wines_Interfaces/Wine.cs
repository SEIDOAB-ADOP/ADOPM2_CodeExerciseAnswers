using System;
using Seido.Utilities.SeedGenerator;

namespace _05_Wines_Interfaces
{
	public class WineAsClass : IWine
	{
        public string Name { get; set; }

        public Country Country { get; set; }
        public WineType WineType { get; set; }
        public GrapeType GrapeType { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
            => $"Wine {Name} from {Country} is {WineType} and made from grapes {GrapeType}."
            + $" The price is {Price:N2} Sek. ({this.GetType().Name})";


        public IWine Seed (SeedGenerator rnd)
        {
            Name = rnd.FromString("Chattaux de bueff, Chattaux de paraply, PutiPuti, NamNam");

            GrapeType = rnd.FromEnum<GrapeType>();
            WineType = rnd.FromEnum<WineType>();
            Country = rnd.FromEnum<Country>();
            Price = rnd.Next(50, 150);
            return this;
        }

        public WineAsClass(IWine original)
        {
            this.Name = original.Name;
            this.GrapeType = original.GrapeType;
            this.Country = original.Country;
            this.WineType = original.WineType;
            this.Price = original.Price;
        }
        public WineAsClass()
        {

        }
	}

    public struct WineAsStruct : IWine
    {
        public string Name { get; set; }

        public Country Country { get; set; }
        public WineType WineType { get; set; }
        public GrapeType GrapeType { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
            => $"Wine {Name} from {Country} is {WineType} and made from grapes {GrapeType}."
            + $" The price is {Price:N2} Sek. ({this.GetType().Name})";

        public IWine Seed(SeedGenerator rnd)
        {
            Name = rnd.FromString("Chattaux de bueff, Chattaux de paraply, PutiPuti, NamNam");

            GrapeType = rnd.FromEnum<GrapeType>();
            WineType = rnd.FromEnum<WineType>();
            Country = rnd.FromEnum<Country>();
            Price = rnd.Next(50, 150);
            return this;
        }
    }
}

