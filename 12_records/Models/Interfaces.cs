using Microsoft.AspNetCore.Identity;
using Seido.Utilities.SeedGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_interfaces.Models
{
    public enum CarBrand { Boxcar, Ford, Jaguar, Honda, Mercedes }
    public enum CarModel { Boxmodel, Mustang_GT, Golf, V70, XF, Civic, S_class, E_class }
    public interface ICar
    {
        public CarBrand Brand { get; init; }
        public CarModel Model { get; init; }
        public string RegNumber { get; init; }
        public int Year { get; init; }

        public IPerson Owner { get; init; }
        public ICar Seed(SeedGenerator seeder);
    }

    public interface IPerson
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }

        public IPerson Seed(SeedGenerator _seeder);
    }
}
