using Seido.Utilities.SeedGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_interfaces.Models
{
    public class CarAsClass : ICar
    {
        public CarBrand Brand { get; init; }
        public CarModel Model { get; init; }
        public string RegNumber { get; init; }
        public int Year { get; init; }
        public IPerson Owner { get; init; }
        public ICar Seed(SeedGenerator seeder)
        {
            var licLetters = seeder.FromString("ABC, EFT, KLW, KHP, DFY, HHJ");
            var licDigits = seeder.Next(100,1000);

            return new CarAsClass() {
                Brand = seeder.FromEnum<CarBrand>(),
                Model = seeder.FromEnum<CarModel>(),

                RegNumber = $"{licLetters} {licDigits}",
                Year = seeder.Next(1970, 2024),

                Owner = new PersonAsClass().Seed(seeder)
            };
        }

        public override string ToString() => 
            $"{GetType().Name}: {Brand}, {Model}, {RegNumber}, {Year}\n   Owner: {Owner}";
    }
}
