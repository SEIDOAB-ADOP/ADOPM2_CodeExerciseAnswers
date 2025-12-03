using System;
using Seido.Utilities.SeedGenerator;
namespace _15_polymorphism.Models;

public enum NordicAnimalKind { Moose, Wolf, Deer, Bear, Fox}
public enum AfricanAnimalKind { Aligator, Elephant, Lion, Donkey, Monkey}
public enum HunterBirdKind {Eagle, Hawk, Owl, Falcon}

public enum AnimalMood { Happy, Sleepy, Sad, Hungry, Lazy, Quick, Slow }
public class Animal: ISeed<Animal>
{
	public AnimalMood Mood { get; set; }
	public int Age { get; set; }
	public string Name { get; set; }

	public override string ToString() => $"{Name} the {Mood} {Age}yr";
	
	public bool Seeded {get; set;} = false;
	public Animal Seed(SeedGenerator _seeder)
	{
		Mood = _seeder.FromEnum<AnimalMood>();
		Age = _seeder.Next(0, 10);
		Name = _seeder.PetName;
		Seeded = true;
		return this;
	}
	public Animal() { }
	public Animal(Animal org)
	{
		Mood = org.Mood;
		Age = org.Age;
		Name = org.Name;
	}
}

public class NordicAnimal: Animal, ISeed<NordicAnimal>
{
	public NordicAnimalKind Kind { get; set; }
	public bool CanSwim { get; set; }

	public override string ToString() => $"{base.ToString()} the {Kind} (CanSwim: {CanSwim})";	
	public new NordicAnimal Seed(SeedGenerator _seeder)
	{
		base.Seed(_seeder);
		Kind = _seeder.FromEnum<NordicAnimalKind>();
		CanSwim = _seeder.Bool;
		return this;
	}

	public NordicAnimal() { }
	public NordicAnimal(NordicAnimal org): base(org)
	{
		Kind = org.Kind;
		CanSwim = org.CanSwim;
	}
}

public class AfricanAnimal: Animal, ISeed<AfricanAnimal>
{
	public AfricanAnimalKind Kind { get; set; }
	public int WeightKg { get; set; }

	public override string ToString() => $"{base.ToString()} the {Kind} (WeightKg: {WeightKg})";	
	public new AfricanAnimal Seed(SeedGenerator _seeder)
	{
		base.Seed(_seeder);
		Kind = _seeder.FromEnum<AfricanAnimalKind>();
		WeightKg = _seeder.Next(50, 5000);
		return this;
	}

	public AfricanAnimal() { }
	public AfricanAnimal(AfricanAnimal org): base(org)
	{
		Kind = org.Kind;
		WeightKg = org.WeightKg;
	}
}

public class HunterBird: Animal, ISeed<HunterBird>
{
	public HunterBirdKind Kind { get; set; }
	public int WingspanCm { get; set; }

	public override string ToString() => $"{base.ToString()} the {Kind} (WingspanCm: {WingspanCm})";	

	public HunterBird Hunt()
	{
		Mood = AnimalMood.Quick;
		System.Console.WriteLine($"{Name} is hunting and {Mood}!");
		return this;
	}
	public HunterBird Fly()
	{
		Mood = AnimalMood.Happy;
		System.Console.WriteLine($"{Name} is flying and {Mood}!");
		return this;
	}
	public HunterBird Rest()
	{
		Mood = AnimalMood.Sleepy;
		System.Console.WriteLine($"{Name} is resting and {Mood}!");
		return this;
	}
	public new HunterBird Seed(SeedGenerator _seeder)
	{
		base.Seed(_seeder);
		Kind = _seeder.FromEnum<HunterBirdKind>();
		WingspanCm = _seeder.Next(50, 250);
		return this;
	}

	public HunterBird() { }
	public HunterBird(HunterBird org): base(org)
	{
		Kind = org.Kind;
		WingspanCm = org.WingspanCm;
	}
}

