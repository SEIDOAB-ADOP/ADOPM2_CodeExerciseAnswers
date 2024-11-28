using Seido.Utilities.SeedGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_interfaces.Models
{
    public class CarAsClass : ICar
    {
        public CarBrand Brand { get; set; }
        public CarModel Model { get; set; }
        public string RegNumber { get; set; }
        public int Year { get; set; }
        public IPerson Owner { get; set; }
        public ICar Seed(SeedGenerator seeder)
        {
            Brand = seeder.FromEnum<CarBrand>();
            Model = seeder.FromEnum<CarModel>();

            var tmp = seeder.FromString("ABC, EFT, KLW, KHP, DFY, HHJ");
            RegNumber = $"{tmp} {seeder.Next(100,1000)}";
            Year = seeder.Next(1970, 2024);

            Owner = new PersonAsClass().Seed(seeder);

            return this;
        }

        public override string ToString() => 
            $"{GetType().Name}: {Brand}, {Model}, {RegNumber}, {Year}\n   Owner: {Owner}";
    }
}
