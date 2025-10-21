# C# Daily Practice

## 🧩 **Level 1: Basics Variables, Data Types, Operators, Constol Structure**

### ✅ **Program 1: Simple Calculator**

**Topics**: Variables, Data Types, Arithmetic Operators, If-Else, Switch Statement

**Instructions**:

* Prompt the user to enter two numbers.
* Ask the user to choose an operation: `+`, `-`, `*`, `/`.
* Use a `switch` statement to perform the operation.
* Display the result.
* Handle division by zero with a proper error message.

📝 **Bonus**: Validate that the input is numeric using `int.TryParse()`.

---

### ✅ **Program 2: Number Guessing Game**

**Topics**: Variables, Random Numbers, Loops, If-Else, User Input

**Instructions**:

* Generate a random number between 1 and 100 using `Random`.
* Let the user guess the number.
* After each guess, tell them if the guess is too low, too high, or correct.
* Count how many attempts the user took.
* When guessed correctly, display the number of attempts.

📝 **Bonus**: Add a maximum number of attempts (e.g., 10), then end the game if they don’t guess in time.

---

### ✅ **Program 3: Even or Odd Checker**

**Topics**: Variables, Data Types, Modulus Operator, If-Else

**Instructions**:

* Prompt the user to enter a number.
* Check if the number is even or odd using the modulus operator `%`.
* Display the result.

📝 **Bonus**: Loop this check so the user can keep testing different numbers until they type "exit".

---

### ✅ **Program 4: Grade Calculator**

**Topics**: Variables, If-Else or Switch, Comparison Operators

**Instructions**:

* Ask the user to enter a numeric score (0 to 100).
* Convert the score into a grade using these rules:

  * 90-100: A
  * 80-89: B
  * 70-79: C
  * 60-69: D
  * Below 60: F
* Display the grade.

📝 **Bonus**: Prevent invalid scores like negative numbers or numbers over 100.

---

### ✅ **Program 5: Multiplication Table Generator**

**Topics**: Loops (for/while), Variables, Console Output

**Instructions**:

* Ask the user to input a number.
* Use a `for` loop to print its multiplication table up to 12.
  Example for 5:

  ```
  5 x 1 = 5
  5 x 2 = 10
  ...
  5 x 12 = 60
  ```

📝 **Bonus**: Ask for a "range" too (e.g., up to what number they want the table).
s

---

## 🧩 **Level 2: Methods, Parameters, Arrays & Strings**

### ✅ **Program 6: Sum and Average Calculator (Using Methods & Arrays)**

**Topics:** Methods, Parameters, Arrays, Loops, Return Values

**Instructions:**

1. Ask the user how many numbers they want to enter.
2. Store the numbers in an array.
3. Write a method `CalculateSum(int[] numbers)` that returns the sum.
4. Write another method `CalculateAverage(int[] numbers)` that returns the average.
5. Display both results.

📝 **Bonus:** Add a method to find the **maximum and minimum** numbers.

**Core Learning:** Passing arrays to methods and returning computed values.

---

### ✅ **Program 7: Palindrome Checker (String Manipulation & Methods)**

**Topics:** Strings, Loops, Methods, Conditionals

**Instructions:**

1. Ask the user to enter a word or phrase.
2. Create a method `IsPalindrome(string input)` that:

   * Removes spaces and converts to lowercase.
   * Checks if the string reads the same backward.
3. Return `true` or `false` and display the result.

📝 **Bonus:** Allow user to test multiple strings until they type “exit”.

**Core Learning:** String processing, clean comparisons, logical reasoning.

---

### ✅ **Program 8: Word Counter (String Split & Loops)**

**Topics:** Strings, Arrays, Loops, Methods

**Instructions:**

1. Ask the user to input a sentence.
2. Create a method `CountWords(string sentence)` that splits the string using spaces and counts the number of words.
3. Display the total word count.

📝 **Bonus:** Count **unique words** (hint: use `ToLower()` and basic array comparisons).

**Core Learning:** Working with `string.Split()`, array traversal, and basic text analysis.

---

### ✅ **Program 9: Simple Menu System (Methods + Control Structures)**

**Topics:** Methods, Switch Statements, Loops, Parameters

**Instructions:**

1. Display a menu like:

   ```
   1. Add
   2. Subtract
   3. Multiply
   4. Divide
   5. Exit
   ```
2. For each option, call a corresponding method:
   `Add(a, b)`, `Subtract(a, b)`, etc.
3. Continue showing the menu until the user chooses “Exit”.

📝 **Bonus:** Add input validation (e.g., handle divide by zero, non-numeric input).

**Core Learning:** Modular program design using multiple small reusable methods.

---

### ✅ **Program 10: Student Grades Summary (Arrays + Methods Integration)**

**Topics:** Arrays, Methods, Loops, Basic Logic

**Instructions:**

1. Ask how many students there are.
2. For each student, enter their marks.
3. Store all marks in an array.
4. Write methods:

   * `GetHighest(int[] marks)`
   * `GetLowest(int[] marks)`
   * `GetAverage(int[] marks)`
5. Display the overall class summary.

📝 **Bonus:**
Add a method to **assign grades** (A/B/C/D/F) based on the average score.

**Core Learning:** Combining arrays, methods, loops, and conditionals into one cohesive problem.

---

## ⚙️ **C# OOP Practice — Set 1 (Core OOP Foundations)**

### 🧱 Concepts Covered

Classes • Objects • Constructors • Destructors • Properties • Access Modifiers • Encapsulation

---

### ✅ **Program 11: Basic Class & Object**

**Topics:** Class, Object, Fields, Methods
**Instructions:**

* Create a `Car` class with fields: `brand`, `model`, and `year`.
* Add a method `DisplayInfo()` to print details.
* Create objects in `Main()` and display them.

📝 *Bonus:* Add a method to update the year and reprint details.

---

### ✅ **Program 12: Constructors and Destructors**

**Topics:** Constructors, Destructors, Initialization
**Instructions:**

* Modify the `Car` class:

  * Add a **default** and a **parameterized** constructor.
  * Print a message inside the destructor to show object cleanup.
* Create multiple car objects using both constructors.

📝 *Bonus:* Add an initialization message in the constructor.

---

### ✅ **Program 13: Encapsulation & Properties**

**Topics:** Private Fields, Getters/Setters, Properties
**Instructions:**

* Create a `BankAccount` class with fields: `accountNumber`, `balance`.
* Make fields **private** and expose **public properties** with validation (e.g., balance can’t be negative).
* Add methods `Deposit()` and `Withdraw()`.

📝 *Bonus:* Reject invalid withdrawal attempts (e.g., withdrawing more than the balance).

---

### ✅ **Program 14: Access Modifiers**

**Topics:** `public`, `private`, `protected`, `internal`
**Instructions:**

* Create a class `Person` with different members using various access modifiers.
* Try to access them from another class to observe visibility differences.

📝 *Bonus:* Demonstrate how `protected` works via inheritance (preview for next set).

---

### ✅ **Program 15: Real-World Encapsulation Example**

**Topics:** Combining Constructors, Properties, Validation
**Instructions:**

* Create an `Employee` class with properties: `Name`, `Age`, `Salary`.
* Validate inside setters:

  * `Age` must be > 18
  * `Salary` > 0
* Use a constructor for initialization and display details via a method.

📝 *Bonus:* Add a static field to count total employees created.

---

## 🧩 **C# OOP Practice — Set 2 (Advanced OOP & Polymorphism)**

### 🧠 Concepts Covered

Inheritance • Method Overloading • Method Overriding • Abstract Classes • Interfaces • Polymorphism

---

### ✅ **Program 16: Inheritance Basics**

**Topics:** Base & Derived Classes
**Instructions:**

* Create a base class `Animal` with a method `Speak()`.
* Create derived classes `Dog` and `Cat` that inherit from `Animal`.
* Call `Speak()` from each object.

📝 *Bonus:* Add shared properties like `Name` or `Age`.

---

### ✅ **Program 17: Method Overloading**

**Topics:** Same method name, different parameters
**Instructions:**

* Create a `Calculator` class with multiple `Add()` methods:

  * `Add(int, int)`
  * `Add(double, double)`
  * `Add(int, int, int)`
* Call all variants to show overloading.

📝 *Bonus:* Add an `Add(params int[] numbers)` version.

---

### ✅ **Program 18: Inheritance and Constructors**

**Topics:** Base Constructors, `base()` keyword, Initialization Order

**Instructions:**

1.  Create a base class `Vehicle` with a parameterized constructor that takes `string licensePlate` and `int wheels`.
    * Print a message inside the constructor (e.g., "Vehicle created.").
2.  Create a derived class `Car` that inherits from `Vehicle`.
3.  The `Car` constructor should also accept `licensePlate` and `wheels`, and a new parameter: `bool hasTrunk`.
4.  Use the **`base()` keyword** in the `Car` constructor to pass the `licensePlate` and `wheels` to the `Vehicle` base constructor.
    * Print a message inside the `Car` constructor (e.g., "Car created.").
5.  In `Main()`, create a `Car` object and observe the order in which the constructor messages appear.

📝 **Bonus:** Add a method `GetDescription()` to `Car` that uses a `protected` field inherited from `Vehicle` to display the plate number.

---

### ✅ **Program 19: Abstract Classes**

**Topics:** Abstract Methods, Derived Implementations
**Instructions:**

* Create an abstract class `Shape` with an abstract method `CalculateArea()`.
* Create `Circle` and `Rectangle` classes implementing it.
* Use a list of shapes and call `CalculateArea()` polymorphically.

📝 *Bonus:* Add a common property like `Color` in `Shape`.

---

### ✅ **Program 20: Interfaces & Polymorphism**

**Topics:** Interfaces, Multiple Inheritance via Interfaces
**Instructions:**

* Create interfaces `IPlayable` and `IRecordable` with methods `Play()` and `Record()`.
* Create a class `MediaPlayer` that implements both.
* Demonstrate calling both interface methods through their references.

📝 *Bonus:* Add another class `AudioRecorder` that implements only `IRecordable` and show polymorphic behavior.

---

## ⚙️ **C# Exception Handling — Set 1 (Exception Handling & Collections)**

### 🧱 Concepts Covered

This level focuses on writing **robust** and **data-structured** C# programs.
You’ll learn to handle runtime errors gracefully using **Exception Handling**, and master **Collections**, the backbone of algorithms and data structures.

---

### ✅ **Problem 21: Safe Division Calculator**

**Concepts:** `try-catch`, `DivideByZeroException`, `FormatException`

* Write a program that performs division of two numbers entered by the user.
* Handle exceptions such as `DivideByZeroException` and `FormatException` using try-catch blocks.

**📝 Bonus:**
Add input validation using `TryParse` and a `finally` block to display `"Operation complete"`.

---

### ✅ **Problem 22: Multi-Exception Handling**

**Concepts:** multiple catch blocks, `IndexOutOfRangeException`

* Create a program that takes an array of numbers and divides each by a user-given divisor.
* Handle exceptions:

  * `DivideByZeroException`
  * `IndexOutOfRangeException`
  * `FormatException`

**📝 Bonus:**
Add a `finally` block that always prints `"Processing finished"`.

---

### ✅ **Problem 23: Nested Exception Handling**

**Concepts:** nested try-catch, argument validation

* Read an integer from the user and calculate its square root.
* Handle negative input (`ArgumentOutOfRangeException`) and invalid format (`FormatException`).

**📝 Bonus:**
Use nested try-catch blocks to separate **user input validation** from **calculation**.

---

### ✅ **Problem 24: Custom Exception – Age Validation**

**Concepts:** custom exception class

* Create a custom exception `InvalidAgeException`.
* Ask the user for their age and throw the exception if the age < 18.

**📝 Bonus:**
Add a property to your exception class to store and display the entered age.

---

### ✅ **Problem 25: Exception Handling with File I/O**

**Concepts:** `FileNotFoundException`, `IOException`

* Read a text file and print its contents.
* Handle file-related exceptions gracefully.

**📝 Bonus:**
Allow the user to input the file path and **retry** if the file is not found.

---

## 📚 Set 2 – Collections (5 Problems)

### ✅ **Problem 26: Array vs List Comparison**

**Concepts:** `Array`, `List<int>`

* Store 5 numbers using both an array and a list.
* Show how lists allow adding/removing elements while arrays do not.

**📝 Bonus:**
Handle index out-of-range errors using exception handling.

---

### ✅ **Problem 27: Queue & Stack Operations**

**Concepts:** `Queue<T>`, `Stack<T>`

* Create a menu-driven console app that:

  * Adds elements
  * Removes elements
  * Views elements
* Demonstrate FIFO vs LIFO behavior.

**📝 Bonus:**
Handle invalid removal attempts with try-catch.

---

### ✅ **Problem 28: Dictionary Lookup**

**Concepts:** `Dictionary<TKey, TValue>`, `KeyNotFoundException`

* Build a dictionary of countries and capitals.
* Allow the user to enter a country and display its capital.
* Handle invalid keys.

**📝 Bonus:**
Allow adding new key-value pairs dynamically.

---

### ✅ **L3-M01: Library ledger**

**Concepts:** All concepts coverd so far.

* A mini project to refresh mind and alleviate information load on brain.
* Covers almost all covered concepts.
* No need for perfect implementation just working one is needed
* Check L3-M01-library-ledger/README.md for more information.

---

### ✅ **Problem 29: HashSet and SortedSet Practice**

**Concepts:** `HashSet<T>`, `SortedSet<T>`

* Create two sets of favorite numbers.
* Demonstrate:

  * Union
  * Intersection
  * Difference
* Then show sorted results using `SortedSet`.

**📝 Bonus:**
Show how `HashSet` automatically prevents duplicates.

---

## 🧭 Level 4 — Advanced C# Essentials (Problems 31–40)

### 🎯 Focus
- Enums & Structs  => done
- File I/O (Text, Binary, Streams)  
- Advanced Arrays & Strings  
- Core Utilities (`DateTime`, `Math`, etc.)  
- Integration of previous concepts  

---

## **Problem 31 — Enum-Based Task Manager**
**Concepts:** Enums, Structs  
- Define a `TaskStatus` enum → `Pending`, `InProgress`, `Completed`.  
- Create a `Task` struct → `Id`, `Title`, `Status`.  
- Store tasks in a `List<Task>` and print formatted output.  
🧩 **Bonus:** Filter tasks by `Status` using simple loops.

---

## **Problem 32 — Temperature Converter (Struct Practice)**
**Concepts:** Structs, Methods, Static Methods  
- Create a `Temperature` struct that holds Celsius/Fahrenheit.  
- Implement conversion methods: `ToFahrenheit()`, `ToCelsius()`.  
🧩 **Bonus:** Overload operators `==`, `!=` to compare two temperatures.

---

## **Problem 33 — Log Writer (File I/O – Write)**
**Concepts:** FileStream, StreamWriter, Exception Handling  
- Ask the user for a message.  
- Save it to `log.txt` with date and time.  
🧩 **Bonus:** Append new entries instead of overwriting.

---

## **Problem 34 — Log Reader (File I/O – Read)**
**Concepts:** StreamReader, Loops, Exception Handling  
- Read contents of `log.txt` line-by-line and display them.  
- Handle missing file exception gracefully.  
🧩 **Bonus:** Count total lines (entries).

---
