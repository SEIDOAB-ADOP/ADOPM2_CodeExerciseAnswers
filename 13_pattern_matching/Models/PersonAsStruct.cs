using Seido.Utilities.SeedGenerator;

namespace _13_pattern_matching.Models
{
    public struct PersonAsStruct : IPerson
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }

        public override string ToString() => $"{FirstName} {LastName} - {Email}";

        public IPerson Seed(SeedGenerator seeder)
        { 
            return new PersonAsStruct(){

                FirstName = seeder.FirstName,
                LastName = seeder.LastName,
                Email = seeder.Email(FirstName, LastName)
            };
        }
    }
}
