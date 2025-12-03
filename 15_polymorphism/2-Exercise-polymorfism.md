# Inheritance and Polymorphism Exercises

Based on the existing `Animal` and `Zoo` classes in the Models folder.

---

## Part 2: Polymorphism Exercises

### Exercise 4: Polymorphic Zoo Collection
**Objective:** Understand polymorphism with heterogeneous collections.

**Task:**
1. In `Program.cs`, create a `Zoo` instance
2. Create at least 5 instances of `NordicAnimal`, `AfricanAnimal`, and `HunterBird` each using the Seed method seeder.ItemsToList<...>()
3. Add each type to the Zoo's `ListOfAnimal` collection
4. Display all animals using the Zoo's `ToString()` method
5. Observe how each animal type displays differently despite being stored as `Animal` references

**Questions to answer:**
- What allows different animal types to be stored in the same list?
- Why does each animal display its specific information despite being in a `List<Animal>`?

---

### Exercise 5: Virtual Methods and Method Overriding
**Objective:** Implement virtual methods to demonstrate polymorphism.

**Task:**
1. In the `Animal` base class, add a virtual method `MakeSound()` that returns "Generic animal sound"
2. In `NordicAnimal`, override `MakeSound()` to return different sounds based on `Kind`:
   - Wolf: "Howl!"
   - Bear: "Roar!"
   - Moose: "Bellow!"
   - Others: "Animal sound..."
3. In `AfricanAnimal`, override `MakeSound()` based on its `Kind`:
   - Lion: "Roar!"
   - Elephant: "Trumpet!"
   - Monkey: "Screech!"
   - Others: "Animal sound..."
4. In `HunterBird`, override `MakeSound()` to return "Screech!" for all birds
5. In `Program.cs`, iterate through the Zoo's animals and call `MakeSound()` on each
6. Print both the animal's ToString() and MakeSound() output

**Expected Output Example:**
```
Milo the Happy Wolf 3yr, Can swim: true - Sound: Howl!
Simba the Lazy Lion 5yr, Weight: 190.5 kg - Sound: Roar!
Max the Quick Eagle 2yr, Wingspan: 180cm - Sound: Screech!
```

---

### Exercise 6: Virtual vs Non-Virtual Seed Methods
**Objective:** Understand the critical difference between virtual and non-virtual methods in polymorphism.

**Background:**
Currently, the `Animal.Seed()` method is **not virtual**. When you store derived class instances (like `NordicAnimal`) in a `List<Animal>` and call `Seed()`, you might not get the behavior you expect.

**Task - Part A: Current Setup (Non-Virtual)**
1. Create a method `ReseedAllAnimals(List<Animal> animals, SeedGenerator seeder)` that loops through the list and calls `.Seed(seeder)` on each animal
2. Create a Zoo with mixed animal types (NordicAnimal, AfricanAnimal, HunterBird)
3. Call your `ReseedAllAnimals` method
4. Display all animals and observe which properties got reseeded

**Observation:** Notice that only the base `Animal` properties (Name, Age, Mood) are reseeded. The derived class properties (Kind, CanSwim, WeightKg, etc.) are NOT reseeded because the non-virtual method uses compile-time binding.

**Task - Part B: Refactor to Virtual/Override**
1. Change `Animal.Seed()` to be `virtual`
2. In `NordicAnimal`, `AfricanAnimal`, and `HunterBird`, change the `Seed()` method from `new` to `override`
3. Run the same `ReseedAllAnimals` method again
4. Display all animals and observe the difference

**Observation:** Now ALL properties are reseeded because virtual methods use runtime polymorphism (late binding).

**Expected Output Comparison:**

Non-virtual (current setup):
```
Before reseed: Max the Happy Wolf 3yr, Can swim: true, Kind: Wolf
After reseed:  Bella the Sad 7yr, Can swim: true, Kind: Wolf
// Notice: Only Name, Age, Mood changed. Kind and CanSwim stayed the same!
```

Virtual/Override:
```
Before reseed: Max the Happy Wolf 3yr, Can swim: true, Kind: Wolf
After reseed:  Luna the Quick Bear 2yr, Can swim: false, Kind: Bear
// Notice: ALL properties changed including Kind and CanSwim!
```

**Key Learning:**
- **Non-virtual methods** use compile-time (static) binding - the method is chosen based on the declared type (`Animal`)
- **Virtual methods** use runtime (dynamic) binding - the method is chosen based on the actual type (`NordicAnimal`, `AfricanAnimal`, etc.)
- This is why virtual/override is crucial for proper polymorphic behavior!

---

