using System;
using Seido.Utilities.SeedGenerator;

namespace _05_Wines_Interfaces
{
    public enum GrapeType { Reissling, Tempranillo, Chardonay, Shiraz, CabernetSavignoin, Syrah }
    public enum WineType { Red, White, Rose }
    public enum Country { Germany, France, Spain }

    public class Wine : IEquatable<Wine>
    {
        public string Name { get; set; }

        public Country Country { get; set; }
        public WineType WineType { get; set; }
        public GrapeType GrapeType { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
            => $"Wine {Name} from {Country} is {WineType} and made from grapes {GrapeType}. The price is {Price:N2} Sek";


        public bool Equals(Wine other) => (Name, Country, WineType, GrapeType) == (other.Name, other.Country, other.WineType, other.GrapeType);

        public override bool Equals(object obj) => Equals(obj as Wine);

        public override int GetHashCode() => (Name, Country, WineType, GrapeType).GetHashCode();

        public static bool operator ==(Wine left, Wine right) => left.Equals(right);
        public static bool operator !=(Wine left, Wine right) => left.Equals(right);



        public Wine Seed(SeedGenerator rnd)
        {
            Name = rnd.FromString("Chattaux de bueff, Chattaux de paraply, PutiPuti, NamNam");

            GrapeType = rnd.FromEnum<GrapeType>();
            WineType = rnd.FromEnum<WineType>();
            Country = rnd.FromEnum<Country>();
            Price = rnd.Next(50, 150);
            return this;
        }
        public Wine()
        {

        }
        public Wine(Wine org)
        {
            Name = org.Name;
            GrapeType = org.GrapeType;

            WineType = org.WineType;
            Country = org.Country;
            Price = org.Price;


        }

    }
}

