using Seido.Utilities.SeedGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_interfaces.Models
{
    public class PersonAsClass : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public override string ToString() => $"{FirstName} {LastName} - {Email}";

        public IPerson Seed(SeedGenerator seeder)
        { 
            FirstName = seeder.FirstName;
            LastName = seeder.LastName;
            Email = seeder.Email(FirstName, LastName);
            return this;
        }
    }
}
