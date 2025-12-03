````markdown
# Copy Constructor Exercises - Zoo Class

Based on the existing `Zoo` and `Animal` classes in the Models folder.

---

## Part 3: Copy Constructors and Deep vs Shallow Copy

### Background: Understanding Copy Strategies

When creating a copy of an object that contains reference types (like `List<Animal>`), you have three main strategies:

1. **Reference Copy (Assignment)**: Both variables point to the same object in memory
2. **Shallow Copy**: Creates a new object, but internal collections still reference the same items
3. **Deep Copy**: Creates a new object with new collections containing copies of all items

---


### Exercise 7: Implement Shallow Copy Constructor (Version 1)

**Objective:** Create a copy constructor that performs a shallow copy of the Zoo.

**Task:**
1. In the `Zoo` class, add a copy constructor with shallow copy behavior:
```csharp
// Shallow copy constructor - shares the same list reference
public Zoo(Zoo original)
{
    Name = original.Name;
    ListOfAnimal = original.ListOfAnimal;  // Shallow: same list reference
}
```

2. In `Program.cs`:
   - Create `originalZoo` with Name = "City Zoo" and 5 animals
   - Create a shallow copy: `var shallowCopy = new Zoo(originalZoo);`
   - Change the name of `shallowCopy` to "Shallow Copy Zoo"
   - Add 2 more animals to `shallowCopy.ListOfAnimal`
   - Display both zoos with their names and animal counts

**Expected Output:**
```
Original Zoo Name: City Zoo
Original Zoo Animal Count: 7
Shallow Copy Zoo Name: Shallow Copy Zoo
Shallow Copy Zoo Animal Count: 7
```

**Questions:**
- Why does the `originalZoo` have 7 animals even though you only added animals to `shallowCopy`?
- Why do the names differ but the animal counts are the same?
- What part is "copied" and what part is "shared"?

**Key Learning:**
Shallow copy creates a new `Zoo` object (so `Name` is independent), but `ListOfAnimal` still references the same list. Adding animals affects both zoos.

---

### Exercise 8: Implement Shallow Copy with New List (Version 2)

**Objective:** Create a shallow copy that creates a new list, but with the same animal references.

**Task:**
1. Update the `Zoo` copy constructor to create a new list instance:
```csharp
// Shallow copy constructor - new list, but same animal references
public Zoo(Zoo original)
{
    Name = original.Name;
    ListOfAnimal = new List<Animal>(original.ListOfAnimal);  // New list, same animals
}
```

2. In `Program.cs`:
   - Create `originalZoo` with Name = "City Zoo" and 5 seeded animals
   - Create a shallow copy: `var shallowCopy = new Zoo(originalZoo);`
   - Change `shallowCopy.Name` to "Shallow Copy Zoo"
   - Add 2 more NEW animals to `shallowCopy.ListOfAnimal`
   - Modify the first animal's name in `shallowCopy.ListOfAnimal[0].Name = "Modified Animal"`
   - Display both zoos with their full content (using ToString())

**Expected Output:**
```
Animals in Zoo City Zoo:
Modified Animal the Happy Wolf 3yr (CanSwim: true)
Bella the Sad Bear 5yr (CanSwim: false)
...
Animal Count: 5

Animals in Zoo Shallow Copy Zoo:
Modified Animal the Happy Wolf 3yr (CanSwim: true)
Bella the Sad Bear 5yr (CanSwim: false)
...
[2 additional animals]
Animal Count: 7
```

**Questions:**
- Why do the zoos have different animal counts now?
- Why did modifying the first animal's name affect BOTH zoos?
- What is copied and what is shared in this approach?

**Key Learning:**
The list is separate (different counts possible), but the list contains references to the same animal objects. Modifying an animal affects both zoos.

---

### Exercise 9: Implement Deep Copy Constructor Using Animal Copy Constructors

**Objective:** Create a true deep copy where everything is independent by utilizing the existing copy constructors in the Animal class hierarchy.

**Important:** This exercise relies on the fact that `Animal`, `NordicAnimal`, `AfricanAnimal`, and `HunterBird` all have copy constructors already implemented (see Animal.cs). We'll use pattern matching to call the appropriate copy constructor for each animal type.

**Task:**
1. Update the `Zoo` copy constructor to perform a deep copy using pattern matching to call the respective Animal class copy constructors:
```csharp
// Deep copy constructor - new list with new animal instances
// Uses the copy constructors from Animal, NordicAnimal, AfricanAnimal, and HunterBird
public Zoo(Zoo original)
{
    Name = original.Name;
    ListOfAnimal = new List<Animal>();
    
    // Deep copy: create new animal instances using their respective copy constructors
    foreach (var animal in original.ListOfAnimal)
    {
        Animal newAnimal = animal switch
        {
            NordicAnimal nordic => new NordicAnimal(nordic),    // Calls NordicAnimal copy constructor
            AfricanAnimal african => new AfricanAnimal(african),  // Calls AfricanAnimal copy constructor
            HunterBird bird => new HunterBird(bird),             // Calls HunterBird copy constructor
            _ => new Animal(animal)                              // Calls Animal copy constructor
        };
        ListOfAnimal.Add(newAnimal);
    }
}
```

2. In `Program.cs`:
   - Create `originalZoo` with Name = "City Zoo" and 5 mixed animals
   - Create a deep copy: `var deepCopy = new Zoo(originalZoo);`
   - Change `deepCopy.Name` to "Deep Copy Zoo"
   - Add 2 more animals to `deepCopy.ListOfAnimal`
   - Modify the first animal in deepCopy: `deepCopy.ListOfAnimal[0].Name = "Deep Copy Animal"`
   - Modify the age: `deepCopy.ListOfAnimal[0].Age = 99`
   - Display both zoos completely

**Expected Output:**
```
Animals in Zoo City Zoo:
Max the Happy Wolf 3yr (CanSwim: true)
Bella the Sad Bear 5yr (CanSwim: false)
...
Animal Count: 5

Animals in Zoo Deep Copy Zoo:
Deep Copy Animal the Happy Wolf 99yr (CanSwim: true)
Bella the Sad Bear 5yr (CanSwim: false)
...
[2 additional animals]
Animal Count: 7
```

**Questions:**
- Why doesn't modifying animals in `deepCopy` affect `originalZoo`?
- What is the cost/benefit tradeoff of deep copy vs shallow copy?
- Why do we need a pattern matching switch statement in the deep copy constructor?
- How does each Animal class copy constructor ensure all properties are copied correctly?

**Key Learning:**
Deep copy creates completely independent objects. Changes to one don't affect the other. This requires using copy constructors all the way down the object graph. The pattern matching switch expression allows us to call the correct derived class copy constructor based on the runtime type of each animal, ensuring all properties (base and derived) are properly copied.

---

````
