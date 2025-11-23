using System.Drawing;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml.Linq;
using Seido.Utilities.SeedGenerator;

namespace _02_Friends;

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

    private CarColor _color;
    public CarColor Color
    {
        get => _color;
      set => _color = value;
    }


    public CarBrand Brand { get; init; }
    public CarModel Model { get; set; }

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
        Model = (CarModel)rnd1.Next((int)CarModel.Boxmodel, (int)CarModel.Civic + 1);


        Color = _seeder.FromEnum<CarColor>();
        Brand = _seeder.FromEnum<CarBrand>();
        Model = _seeder.FromEnum<CarModel>();
    }
}

public enum FriendLevel
{
    Friend, ClassMate, Family, BestFriend
}
public class Friend
{
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value == null || value == "")
            {
                throw new Exception("Name cannot be set to null");
            }
            _name = value;
        }
    }

    public string Email { get; set; }
    public FriendLevel Level { get; set; }

    public Car Car { get; set; }
        

    public override string ToString()
    {
        var sRet = $"{Name} is my {Level} and can be reached at {Email}.";
        if (Car != null)
        {
            sRet += $"\n -The car is a {Car.Color} {Car.Brand} {Car.Model}";
        }
        return sRet;
    }

    public Friend(SeedGenerator _seeder)
    {
        string _firstName = _seeder.FirstName;
        string _lastName = _seeder.LastName;
        Name = $"{_firstName} {_lastName}";

        Email = _seeder.Email(_firstName, _lastName);
        Level = _seeder.FromEnum<FriendLevel>();
        Car = new Car(_seeder);
    }
    public Friend(string name, string email, FriendLevel level)
    {
        Name = name;
        Email = email;
        Level = level;
    }
    public Friend(Friend org)
    {
        Name = org.Name;
        Email = org.Email;
        Level = org.Level;
        Car = new Car(org.Car);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var rnd = new SeedGenerator();
        Console.WriteLine("Hello, Friends!");

        Friend[] friends = new Friend[10];
        for (int i = 0; i < 10; i++)
        {
            friends[i] = new Friend(rnd);
        }

        foreach (var item in friends)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nCopy of friends");
        Friend[] friends_copy = new Friend[10];
        for (int i = 0; i < friends_copy.Length; i++)
        {
            friends_copy[i] = new Friend(friends[i]);
        }

        foreach (var item in friends_copy)
        {
            Console.WriteLine(item);
        }
    }
}

//Exercises:
//1. Create a constructor to class csFriend that takes Name, Email, and Level as
//   Parameters and sets the corresponding properties.
//   Create an instance of csFriend(..) settign the properties with Arguments

//2. Create an empty constructor that sets all properties to random values
//   Create an instance of csFriend() setting the properties to random values.

//3. Create a method ToString() in csFriend that presents the instance of csFriend.
//   For example "Sam Baggins is my BestFriend and can be reached at sam.baggins@gmail.com"

//Advanced:
//4. Create an array of 10 random instances of csFriend and have them present themself

//5. Add a property, Car, of type csCar to csFriend class. Instantiate a csFriend
//   as a variable friend and give your friend a random car.

//6. Modify ToString() in csFriend to also present the friends car if it exists (not null)

//7. Modify the setter in Name so an Error is thrown if the new name is null or ""


// --- Gör tills 4 Oktober
// 8. Gör om construtor csFriend() så att den tar en parameter (csSeedGenerator _seeder).
//    Instantiera csSeedGeneratorn i Main() och modifiera koden så att den fungerar som innan.
//
// 10. Deklarera en Copy constructor.
//
// 11. Använd copy constructorn för att skapa en ny lista av 10 vänner som är en kopia
//     av ursprungslistan



