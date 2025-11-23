using Microsoft.AspNetCore.Identity;
using Seido.Utilities.SeedGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_interfaces.Models
{
    public enum CarBrand { Boxcar, Ford, Jaguar, Honda, Mercedes }
    public enum CarModel { Boxmodel, Mustang_GT, Golf, V70, XF, Civic, S_class, E_class }
    public interface ICar
    {
        public CarBrand Brand { get; set; }
        public CarModel Model { get; set; }
        public string RegNumber { get; set; }
        public int Year { get; set; }

        public IPerson Owner { get; set; }
        public ICar Seed(SeedGenerator seeder);
    }

    public interface IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public IPerson Seed(SeedGenerator _seeder);
    }
}
