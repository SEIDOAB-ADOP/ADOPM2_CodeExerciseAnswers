using Seido.Utilities.SeedGenerator;

namespace _13_pattern_matching.Models
{
    public struct CarAsStruct : ICar
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

            return new CarAsStruct() {
                Brand = seeder.FromEnum<CarBrand>(),
                Model = seeder.FromEnum<CarModel>(),

                RegNumber = $"{licLetters} {licDigits}",
                Year = seeder.Next(1970, 2024),

                Owner = new PersonAsStruct().Seed(seeder)
            };
        }

        public override string ToString() => 
            $"{GetType().Name}: {Brand}, {Model}, {RegNumber}, {Year}\n   Owner: {Owner}";
    }
}
