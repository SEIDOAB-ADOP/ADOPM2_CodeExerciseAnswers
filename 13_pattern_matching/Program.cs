using _13_pattern_matching.Models;
using Seido.Utilities.SeedGenerator;

var rnd = new SeedGenerator();

var cars = new List<ICar>();
for (int i = 0; i < 100; i++)
{
    cars.Add(new CarAsStruct().Seed(rnd));
    cars.Add(new CarAsClass().Seed(rnd));
    cars.Add(new CarAsRecord().Seed(rnd));
}

//Using classical if
System.Console.WriteLine("\n\nCarMatch on cars using if");
foreach (var item in cars)
{
    if (CarMatch(item))
    {
        var message = CarMessage(item);
        Console.WriteLine($"{item}\n   Message: {message}");
    }
}

//Using Linq Where
System.Console.WriteLine("\n\nCarMatch on cars using Linq Where");
foreach (var item in cars.Where(x => CarMatch(x)))
{
    var message = CarMessage(item);
    Console.WriteLine($"{item}\n   Message: {message}");
}


//Pattern matching in a method with switch using expression bodied member syntax
static string CarMessage(ICar car) => car switch
{
    ICar { Brand: CarBrand.Mercedes} => "A Mercedes",
    CarAsRecord {Brand: CarBrand.Jaguar } => "A Jaguar implemented as a record",
    ICar { Year: < 1980 } => "A car earlier than 1980",
    CarAsStruct { Year: < 2000 } => "A car earlier than 1980",
    ICar c when c.Owner.Email.Contains("icloud.com") => "A car with owner using icloud.com as email",
    CarAsRecord {Year: < 2000} c when c.Owner.Email.Contains("gmail") => "A car implemented as a record earlier that 2000 with an owner using gmail",
    //CarAsStruct => "Implemented as a struct",
    //CarAsClass => "Implemented as a class",
    //CarAsRecord => "Implemented as a record",
    
    _ => ""
};

static bool CarMatch(ICar car) => car switch
{
    ICar { Brand: CarBrand.Mercedes} => true,
    CarAsRecord {Brand: CarBrand.Jaguar } => true,
    ICar { Year: < 1980 } => true,
    CarAsStruct { Year: < 2000 } => true,
    ICar c when c.Owner.Email.Contains("icloud.com") => true,
    CarAsRecord {Year: < 2000} c when c.Owner.Email.Contains("gmail") => true,
    //CarAsStruct => "Implemented as a struct",
    //CarAsClass => "Implemented as a class",
    //CarAsRecord => "Implemented as a record",
    
    _ => false
};


/* Exercises 
1. Use pattern matching to modify message in CarMessage according to below
   - A Mercedes 
   - A Jaguar implemented as a record
   - A car earlier than 1980
   - A car earlier than 2000 as struct
   - A car with owner using icloud.com as email. Hint: Owner.Email.Contains("icloud.com")
   - A car implemented as a record earlier that 2000 with an owner using gmail

2. Declare a method, static bool CarMatch(ICar car), using above patternmatching but instead of the message return true, if pattern matched, otherwise false
   (remove matching for CarAsStruct =>, CarAsClass =>, CarAsRecord => )
3. Use the method CarMatch() to filter out only those cars in the list that matches. Hint: use cars.Where()
4. Create a list of 3000 cars (loop 100 times) and print out only those cars that matches CarMatch(). 
   In other words you should only get the cars matching the pattern in exercise 1

*/
