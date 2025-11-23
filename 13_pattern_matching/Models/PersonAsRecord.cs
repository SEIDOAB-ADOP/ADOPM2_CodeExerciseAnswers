using Seido.Utilities.SeedGenerator;

namespace _13_pattern_matching.Models;

public record PersonAsRecord (string FirstName, string LastName, string Email) : IPerson
{
    public PersonAsRecord():this(default, default, default)
    {}
    public IPerson Seed(SeedGenerator seeder)
    { 
        var fn = seeder.FirstName;
        var ln = seeder.FirstName;

        return new PersonAsRecord(
            fn,
            ln,
            seeder.Email(fn, ln));
    }
}