using Seido.Utilities.SeedGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01a_Seeder.Models
{
    public enum CarColor
    {
        Brown, Red, Green, Burgundy
    }
    public enum CarBrand
    {
        Ford, Jaguar, Honda, Volvo
    }
    public enum CarModel
    {
        Mustang_GT, XF, Civic, v70
    }
    class Car : ISeed<Car>
    {
        public CarColor Color { get; set; }
        public CarBrand Brand { get; set; }
        public CarModel Model { get; set; }

        public string RegNr { get; set; }

        public override string ToString() => $"{Brand} {Model} in {Color} wth RegNr {RegNr}";

        public bool Seeded { get; set; } = false;
        public Car Seed(SeedGenerator seeder)
        {
            Model = seeder.FromEnum<CarModel>();
            Brand = seeder.FromEnum<CarBrand>();
            Color = seeder.FromEnum<CarColor>();

            RegNr = seeder.FromString("ABC, HKL, BHS, JKW, QRT") + " " + seeder.Next(100, 1000).ToString();

            return this;
        }
    }
}
