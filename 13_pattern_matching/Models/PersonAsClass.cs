using Seido.Utilities.SeedGenerator;

namespace _13_pattern_matching.Models
{
    public class PersonAsClass : IPerson
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }

        public override string ToString() => $"{FirstName} {LastName} - {Email}";

        public IPerson Seed(SeedGenerator seeder)
        { 
            return new PersonAsClass(){

                FirstName = seeder.FirstName,
                LastName = seeder.LastName,
                Email = seeder.Email(FirstName, LastName)
            };
        }
    }
}
