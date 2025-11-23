using Seido.Utilities.SeedGenerator;

namespace _13_pattern_matching.Models;

public record CarAsRecord (
    CarBrand Brand, CarModel Model, string RegNumber,
    int Year, IPerson Owner) : ICar
{
    public CarAsRecord():this(default, default, default, default, default)
    {}
    public ICar Seed(SeedGenerator seeder)
    { 
        var licLetters = seeder.FromString("ABC, EFT, KLW, KHP, DFY, HHJ");
        var licDigits = seeder.Next(100,1000);

        return new CarAsRecord(
                seeder.FromEnum<CarBrand>(),
                seeder.FromEnum<CarModel>(),

                $"{licLetters} {licDigits}",
                seeder.Next(1970, 2024),

                new PersonAsRecord().Seed(seeder));
    }
}