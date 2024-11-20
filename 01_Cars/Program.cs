using System.Reflection;
using Seido.Utilities.SeedGenerator;

namespace _01_Cars;

public class Program
{
    public enum CarColor
    {
        Brown, Red, Green, Burgundy
    }
    public enum CarBrand
    {
        Boxcar, Ford, Jaguar, Honda
    }
    public enum CarModel
    {
        Boxmodel, Mustang_GT, Golf, V70, XF, Civic
    }
    public class Car
    {
        public CarColor Color { get; set; }
        public CarBrand Brand { get; init; }
        public CarModel Model { get; init; }

        public override string ToString()
        {
            string _s = $"I am a {Color} {Brand} {Model}";
            return _s;
        }

        public Car() { }
        public Car(CarColor _color, CarBrand _brand, CarModel _model)
        {
            Color = _color;
            Brand = _brand;
            Model = _model;
        }
        public Car(Car org)
        {
            Color = org.Color;
            Brand = org.Brand;
            Model = org.Model;
        }
        public Car(SeedGenerator _seeder)
        {

            //alternative to SeedGenerator
            var rnd1 = new Random();
            Model =  (CarModel) rnd1.Next((int)CarModel.Boxmodel, (int)CarModel.Civic + 1);


            Color = _seeder.FromEnum<CarColor>();
            Brand = _seeder.FromEnum<CarBrand>();
            Model = _seeder.FromEnum<CarModel>();
        }
    }


    static void Main(string[] args)
    {
        var rnd = new SeedGenerator();
        Console.WriteLine("Class exploration with Cars!");

        Console.WriteLine("\nDefault constructor");
        Car car0 = new Car();
        Console.WriteLine(car0);

        Console.WriteLine("Copy constructor");
        Car car0_copy = new Car(car0);
        Console.WriteLine(car0_copy);

        Console.WriteLine("\nRandom constructor"); Car car1 = new Car(rnd);
        Console.WriteLine(car1);

        Console.WriteLine("Copy constructor");
        Car car1_copy = new Car(car1);
        Console.WriteLine(car1_copy);

        Console.WriteLine("\nConstructor to set properties");
        Car car1a = new Car(CarColor.Red, CarBrand.Jaguar, CarModel.XF);
        Console.WriteLine(car1a);

        Console.WriteLine("Copy constructor");
        Car car1a_copy = new Car(car1a);
        Console.WriteLine(car1a_copy);


        //Create 10 cars
        Console.WriteLine("\nLista 10 bilar");
        Car[] cars = new Car[10];
        for (int i = 0; i < 10; i++)
        {
            cars[i] = new Car(rnd) { Color = CarColor.Burgundy };
        }

        foreach (var item in cars)
        {
            Console.WriteLine(item);
        }

        //Copy 10 cars
        Console.WriteLine("\nKopia av listan 10 bilar");
        Car[] cars_copy = new Car[10];
        for (int i = 0; i < cars_copy.Length; i++)
        {
            cars_copy[i] = new Car(cars[i]);
        }

        foreach (var item in cars_copy)
        {
            Console.WriteLine(item);
        }

    }

    //Exercises:
    //1. Make class csCar public field Color a public property with getters and setters

    //2. Create two new public properties in class csCar, Brand, Model
    //   (of types enCarBrand and enCarModel)

    //3. Create an empty class constructor to csCar that sets Color, Brand and Model to
    //   Random values

    //4. Create a method public method WhoAmI() that presents for example
    //   "I am a Red Ford Mustang_GT";

    //5. In Main(), create two variables, car1, car2 and instantiate from csCar
    //   - printout WhoAmI of car1 and car2

    //Advanced:
    //6. Modify the properties Color, Brand and Model so that only Color can change
    //   once an instance of Car has been created

    //7. Modify the properties of Brand and Model so they can also be set during
    //   Object initialization, i.e.  new Car(){ Model = ..., Brand = ...}

    //8. Create an array of 10 cars, all of Color Burgundy.

    //9. Change class Car to struct Car and run the program again.


    // --- Gör tills 4 Oktober
    // 10. Gör om construtor csCar() så att den tar en parameter (csSeedGenerator _seeder).
    //    Instantiera csSeedGeneratorn i Main() och modifiera koden så att den fungerar som innan.
    //
    // 11. Deklarera en construktor som tillåter dig att själv bestämma alla csCar public properties
    //
    // 12. Deklarera en Copy constructor.
    //
    // 13. Använd copy constructorn för att skapa en array av 10 bilar som är en kopia av ursprunget
}

