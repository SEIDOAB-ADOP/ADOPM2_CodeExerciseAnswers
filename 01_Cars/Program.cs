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
        Console.WriteLine("Class exploration with Cars!");
        var rnd = new SeedGenerator();

        var car1 = new Car(rnd) { Brand = CarBrand.Ford };
        Console.WriteLine(car1);

        var car2 = new Car(rnd) { Brand = CarBrand.Ford };
        Console.WriteLine(car2);

        var car2Copy = new Car(car2) { Color = CarColor.Burgundy };

        var cars = new List<Car>();
        for (int i = 0; i < 10; i++)
        {
            cars.Add(new Car(rnd) { Brand = CarBrand.Ford });
        }

        Console.WriteLine();
        Console.WriteLine("List of cars");
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine();
        Console.WriteLine("List of carsrefcopy");
        var carsrefcopy = cars;
        foreach (var car in carsrefcopy)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine();
        Console.WriteLine("element nr 9");
        carsrefcopy[9] = null;
        Console.WriteLine(carsrefcopy[9]);
        Console.WriteLine(cars[9]);


        Console.WriteLine();
        Console.WriteLine("List of carsshallowcopy");
        var carsshallowcopy = new List<Car>();
        foreach (var car in cars)
        {
            carsshallowcopy.Add(car);
        }

        Console.WriteLine();
        Console.WriteLine("element nr 7");
        carsshallowcopy[7] = null;
        Console.WriteLine(carsshallowcopy[7]);
        Console.WriteLine(cars[7]);

        Console.WriteLine();
        Console.WriteLine("element nr 5");
        carsshallowcopy[5].Color = CarColor.Red;
        Console.WriteLine(carsshallowcopy[5].Color);
        Console.WriteLine(cars[5].Color);

        Console.WriteLine();
        Console.WriteLine("List of carsdeepcopy");
        var carsdeepcopy = new List<Car>();
        foreach (var car in cars)
        {
            if (car != null)
            {
                carsdeepcopy.Add(new Car(car));
            }
        }
        for (int i = 0; i < carsdeepcopy.Count; i++)
        {
            if (carsdeepcopy[i] != null)
            {
                carsdeepcopy[i].Color = CarColor.Red;
            }
        }
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
        foreach (var car in carsdeepcopy)
        {
            Console.WriteLine(car);
        }
    }

    //Exercises:
    //1. Make class Car public field Color a public property with getters and setters

    //2. Create two new public properties in class Car, Brand, Model
    //   (of types enCarBrand and enCarModel)

    // 3. Gör en construtor Car(csSeedGenerator _seeder) som sätter alla properties till
    //    random

    //4. Make a ToString() override that presents for example
    //   "I am a Red Ford Mustang_GT";

    //5. In Main(), create two variables, car1, car2 and instantiate from Car
    //   - presentera car1 and car2

    //6. Modify the properties Color, Brand and Model so that only Color can change
    //   once an instance of Car has been created

    //7. Modify the properties of Brand and Model so they can also be set during
    //   Object initialization, i.e.  new Car(){ Model = ..., Brand = ...}

    //8. Create an array of 10 cars, all of Color Burgundy, all othet properties random

    //9. Change class Car to struct Car and run the program again.

    // 10. Deklarera en construktor som tillåter dig att själv bestämma alla Car public properties

    // 11. Deklarera en Copy constructor.

    // 12. Använd copy constructorn för att skapa en array av 10 bilar som är en kopia av ursprunget
}

