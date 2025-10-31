# 🎯 C# Complete Learning Plan – 100 Problems

> **A structured, progressive path to master C# from basics to advanced concepts.**  
> Each level contains 10 problems building upon previous knowledge.  
> Mark problems as ✅ when completed.

---

## 🧭 Level 1 – Basics, Variables, Operators, Control Structures (Problems 1–10)

**Learning Goals:** Understand C# syntax, program structure, variables, data types, operators, and control flow

---

### ✅ Problem 1: Simple Calculator

**Topics:** Variables, Data Types, Arithmetic Operators, If-Else, Switch Statement

**Instructions:**
* Prompt the user to enter two numbers.
* Ask the user to choose an operation: `+`, `-`, `*`, `/`.
* Use a `switch` statement to perform the operation.
* Display the result.
* Handle division by zero with a proper error message.

📝 **Bonus:** Validate that the input is numeric using `int.TryParse()`.

---

### ✅ Problem 2: Number Guessing Game

**Topics:** Variables, Random Numbers, Loops, If-Else, User Input

**Instructions:**
* Generate a random number between 1 and 100 using `Random`.
* Let the user guess the number.
* After each guess, tell them if the guess is too low, too high, or correct.
* Count how many attempts the user took.
* When guessed correctly, display the number of attempts.

📝 **Bonus:** Add a maximum number of attempts (e.g., 10), then end the game if they don't guess in time.

---

### ✅ Problem 3: Even or Odd Checker

**Topics:** Variables, Data Types, Modulus Operator, If-Else

**Instructions:**
* Prompt the user to enter a number.
* Check if the number is even or odd using the modulus operator `%`.
* Display the result.

📝 **Bonus:** Loop this check so the user can keep testing different numbers until they type "exit".

---

### ✅ Problem 4: Grade Calculator

**Topics:** Variables, If-Else or Switch, Comparison Operators

**Instructions:**
* Ask the user to enter a numeric score (0 to 100).
* Convert the score into a grade using these rules:
  * 90-100: A
  * 80-89: B
  * 70-79: C
  * 60-69: D
  * Below 60: F
* Display the grade.

📝 **Bonus:** Prevent invalid scores like negative numbers or numbers over 100.

---

### ✅ Problem 5: Multiplication Table Generator

**Topics:** Loops (for/while), Variables, Console Output

**Instructions:**
* Ask the user to input a number.
* Use a `for` loop to print its multiplication table up to 12.
  Example for 5:
  ```
  5 x 1 = 5
  5 x 2 = 10
  ...
  5 x 12 = 60
  ```

📝 **Bonus:** Ask for a "range" too (e.g., up to what number they want the table).

---

### ✅ Problem 6: Sum and Average Calculator

**Topics:** Methods, Parameters, Arrays, Loops, Return Values

**Instructions:**
1. Ask the user how many numbers they want to enter.
2. Store the numbers in an array.
3. Write a method `CalculateSum(int[] numbers)` that returns the sum.
4. Write another method `CalculateAverage(int[] numbers)` that returns the average.
5. Display both results.

📝 **Bonus:** Add a method to find the **maximum and minimum** numbers.

---

### ✅ Problem 7: Palindrome Checker

**Topics:** Strings, Loops, Methods, Conditionals

**Instructions:**
1. Ask the user to enter a word or phrase.
2. Create a method `IsPalindrome(string input)` that:
   * Removes spaces and converts to lowercase.
   * Checks if the string reads the same backward.
3. Return `true` or `false` and display the result.

📝 **Bonus:** Allow user to test multiple strings until they type "exit".

---

### ✅ Problem 8: Word Counter

**Topics:** Strings, Arrays, Loops, Methods

**Instructions:**
1. Ask the user to input a sentence.
2. Create a method `CountWords(string sentence)` that splits the string using spaces and counts the number of words.
3. Display the total word count.

📝 **Bonus:** Count **unique words** (hint: use `ToLower()` and basic array comparisons).

---

### ✅ Problem 9: Simple Menu System

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
2. For each option, call a corresponding method: `Add(a, b)`, `Subtract(a, b)`, etc.
3. Continue showing the menu until the user chooses "Exit".

📝 **Bonus:** Add input validation (e.g., handle divide by zero, non-numeric input).

---

### ✅ Problem 10: Student Grades Summary

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

📝 **Bonus:** Add a method to **assign grades** (A/B/C/D/F) based on the average score.

---

## 🧱 Level 2 – Object-Oriented Programming Foundations (Problems 11–20)

**Learning Goals:** Build reusable code with classes, objects, constructors, destructors, encapsulation, and inheritance

---

### ✅ Problem 11: Basic Class & Object

**Topics:** Class, Object, Fields, Methods

**Instructions:**
* Create a `Car` class with fields: `brand`, `model`, and `year`.
* Add a method `DisplayInfo()` to print details.
* Create objects in `Main()` and display them.

📝 **Bonus:** Add a method to update the year and reprint details.

---

### ✅ Problem 12: Constructors and Destructors

**Topics:** Constructors, Destructors, Initialization

**Instructions:**
* Modify the `Car` class:
  * Add a **default** and a **parameterized** constructor.
  * Print a message inside the destructor to show object cleanup.
* Create multiple car objects using both constructors.

📝 **Bonus:** Add an initialization message in the constructor.

---

### ✅ Problem 13: Encapsulation & Properties

**Topics:** Private Fields, Getters/Setters, Properties

**Instructions:**
* Create a `BankAccount` class with fields: `accountNumber`, `balance`.
* Make fields **private** and expose **public properties** with validation (e.g., balance can't be negative).
* Add methods `Deposit()` and `Withdraw()`.

📝 **Bonus:** Reject invalid withdrawal attempts (e.g., withdrawing more than the balance).

---

### ✅ Problem 14: Access Modifiers

**Topics:** `public`, `private`, `protected`, `internal`

**Instructions:**
* Create a class `Person` with different members using various access modifiers.
* Try to access them from another class to observe visibility differences.

📝 **Bonus:** Demonstrate how `protected` works via inheritance (preview for next set).

---

### ✅ Problem 15: Real-World Encapsulation Example

**Topics:** Combining Constructors, Properties, Validation

**Instructions:**
* Create an `Employee` class with properties: `Name`, `Age`, `Salary`.
* Validate inside setters:
  * `Age` must be > 18
  * `Salary` > 0
* Use a constructor for initialization and display details via a method.

📝 **Bonus:** Add a static field to count total employees created.

---

### ✅ Problem 16: Inheritance Basics

**Topics:** Base & Derived Classes

**Instructions:**
* Create a base class `Animal` with a method `Speak()`.
* Create derived classes `Dog` and `Cat` that inherit from `Animal`.
* Call `Speak()` from each object.

📝 **Bonus:** Add shared properties like `Name` or `Age`.

---

### ✅ Problem 17: Method Overloading

**Topics:** Same method name, different parameters

**Instructions:**
* Create a `Calculator` class with multiple `Add()` methods:
  * `Add(int, int)`
  * `Add(double, double)`
  * `Add(int, int, int)`
* Call all variants to show overloading.

📝 **Bonus:** Add an `Add(params int[] numbers)` version.

---

### ✅ Problem 18: Inheritance and Constructors

**Topics:** Base Constructors, `base()` keyword, Initialization Order

**Instructions:**
1. Create a base class `Vehicle` with a parameterized constructor that takes `string licensePlate` and `int wheels`.
   * Print a message inside the constructor (e.g., "Vehicle created.").
2. Create a derived class `Car` that inherits from `Vehicle`.
3. The `Car` constructor should also accept `licensePlate` and `wheels`, and a new parameter: `bool hasTrunk`.
4. Use the **`base()` keyword** in the `Car` constructor to pass the `licensePlate` and `wheels` to the `Vehicle` base constructor.
   * Print a message inside the `Car` constructor (e.g., "Car created.").
5. In `Main()`, create a `Car` object and observe the order in which the constructor messages appear.

📝 **Bonus:** Add a method `GetDescription()` to `Car` that uses a `protected` field inherited from `Vehicle` to display the plate number.

---

### ✅ Problem 19: Abstract Classes

**Topics:** Abstract Methods, Derived Implementations

**Instructions:**
* Create an abstract class `Shape` with an abstract method `CalculateArea()`.
* Create `Circle` and `Rectangle` classes implementing it.
* Use a list of shapes and call `CalculateArea()` polymorphically.

📝 **Bonus:** Add a common property like `Color` in `Shape`.

---

### ✅ Problem 20: Interfaces & Polymorphism

**Topics:** Interfaces, Multiple Inheritance via Interfaces

**Instructions:**
* Create interfaces `IPlayable` and `IRecordable` with methods `Play()` and `Record()`.
* Create a class `MediaPlayer` that implements both.
* Demonstrate calling both interface methods through their references.

📝 **Bonus:** Add another class `AudioRecorder` that implements only `IRecordable` and show polymorphic behavior.

---

## ⚙️ Level 3 – Exception Handling & Collections (Problems 21–30)

**Learning Goals:** Handle runtime errors gracefully using try-catch and master C# collections

---

### ✅ Problem 21: Safe Division Calculator

**Concepts:** `try-catch`, `DivideByZeroException`, `FormatException`

**Instructions:**
* Write a program that performs division of two numbers entered by the user.
* Handle exceptions such as `DivideByZeroException` and `FormatException` using try-catch blocks.

📝 **Bonus:** Add input validation using `TryParse` and a `finally` block to display `"Operation complete"`.

---

### ✅ Problem 22: Multi-Exception Handling

**Concepts:** multiple catch blocks, `IndexOutOfRangeException`

**Instructions:**
* Create a program that takes an array of numbers and divides each by a user-given divisor.
* Handle exceptions:
  * `DivideByZeroException`
  * `IndexOutOfRangeException`
  * `FormatException`

📝 **Bonus:** Add a `finally` block that always prints `"Processing finished"`.

---

### ✅ Problem 23: Nested Exception Handling

**Concepts:** nested try-catch, argument validation

**Instructions:**
* Read an integer from the user and calculate its square root.
* Handle negative input (`ArgumentOutOfRangeException`) and invalid format (`FormatException`).

📝 **Bonus:** Use nested try-catch blocks to separate **user input validation** from **calculation**.

---

### ✅ Problem 24: Custom Exception – Age Validation

**Concepts:** custom exception class

**Instructions:**
* Create a custom exception `InvalidAgeException`.
* Ask the user for their age and throw the exception if the age < 18.

📝 **Bonus:** Add a property to your exception class to store and display the entered age.

---

### ✅ Problem 25: Exception Handling with File I/O

**Concepts:** `FileNotFoundException`, `IOException`

**Instructions:**
* Read a text file and print its contents.
* Handle file-related exceptions gracefully.

📝 **Bonus:** Allow the user to input the file path and **retry** if the file is not found.

---

### ✅ Problem 26: Array vs List Comparison

**Concepts:** `Array`, `List<int>`

**Instructions:**
* Store 5 numbers using both an array and a list.
* Show how lists allow adding/removing elements while arrays do not.

📝 **Bonus:** Handle index out-of-range errors using exception handling.

---

### ✅ Problem 27: Queue & Stack Operations

**Concepts:** `Queue<T>`, `Stack<T>`

**Instructions:**
* Create a menu-driven console app that:
  * Adds elements
  * Removes elements
  * Views elements
* Demonstrate FIFO vs LIFO behavior.

📝 **Bonus:** Handle invalid removal attempts with try-catch.

---

### ✅ Problem 28: Dictionary Lookup

**Concepts:** `Dictionary<TKey, TValue>`, `KeyNotFoundException`

**Instructions:**
* Build a dictionary of countries and capitals.
* Allow the user to enter a country and display its capital.
* Handle invalid keys.

📝 **Bonus:** Allow adding new key-value pairs dynamically.

---

### ✅ **L3-M01: Library ledger**

**Concepts:** All concepts covered so far.

* A mini project to refresh mind and alleviate information load on brain.
* Covers almost all covered concepts.
* No need for perfect implementation just working one is needed
* Check L3-M01-library-ledger/README.md for more information.

---

### ✅ Problem 29: HashSet and SortedSet Practice

**Concepts:** `HashSet<T>`, `SortedSet<T>`

**Instructions:**
* Create two sets of favorite numbers.
* Demonstrate:
  * Union
  * Intersection
  * Difference
* Then show sorted results using `SortedSet`.

📝 **Bonus:** Show how `HashSet` automatically prevents duplicates.

---

### ✅ Problem 30: Mini Address Book (Integrated Practice)

**Concepts:** `Dictionary<string, List<string>>`, exception handling, integration

**Instructions:**
* Create a console-based address book.
* Key = person's name
* Value = list of phone numbers
* Allow:
  * Add contact
  * Remove contact
  * Search contact
* Use exception handling for invalid or empty inputs.

📝 **Bonus:** Use `try-catch-finally` to manage errors and always print a summary after each operation.

---

## 📁 Level 4 – Advanced C# Essentials (Problems 31–40)

**Learning Goals:** Work with structs, enums, file I/O, strings, arrays, DateTime, and integrate previous concepts

---

### ✅ Problem 31: Enum-Based Task Manager

**Concepts:** Enums, Structs

**Instructions:**
* Define a `TaskStatus` enum → `Pending`, `InProgress`, `Completed`.
* Create a `Task` struct → `Id`, `Title`, `Status`.
* Store tasks in a `List<Task>` and print formatted output.

📝 **Bonus:** Filter tasks by `Status` using simple loops.

---

### ✅ Problem 32: Temperature Converter (Struct Practice)

**Concepts:** Structs, Methods, Static Methods

**Instructions:**
* Create a `Temperature` struct that holds Celsius/Fahrenheit.
* Implement conversion methods: `ToFahrenheit()`, `ToCelsius()`.

📝 **Bonus:** Overload operators `==`, `!=` to compare two temperatures.

---

### ✅ Problem 33: Log Writer (File I/O – Write)

**Concepts:** FileStream, StreamWriter, Exception Handling

**Instructions:**
* Ask the user for a message.
* Save it to `log.txt` with date and time.

📝 **Bonus:** Append new entries instead of overwriting.

---

### ✅ Problem 34: Log Reader (File I/O – Read)

**Concepts:** StreamReader, Loops, Exception Handling

**Instructions:**
* Read contents of `log.txt` line-by-line and display them.
* Handle missing file exception gracefully.

📝 **Bonus:** Count total lines (entries).

---

### ✅ Problem 35: Copy Text File

**Concepts:** FileStream, Byte Operations

**Instructions:**
* Copy contents from one file to another using `FileStream`.

📝 **Bonus:** Allow copying of `.txt` and `.csv` files.

---

### ✅ Problem 36: Student Records (Struct + File I/O)

**Concepts:** Struct, Arrays, File Writing

**Instructions:**
* Define a `Student` struct → `Id`, `Name`, `Marks`.
* Input multiple students and save their data to a file.

📝 **Bonus:** Load data and calculate average marks.

---

### ✅ Problem 37: String Analyzer

**Concepts:** String Functions, Char Arrays

**Instructions:**
* Ask user for input string.
* Display: total characters, words, vowels, consonants, spaces.

📝 **Bonus:** Reverse string manually without built-in functions.

---

### ✅ Problem 38: Matrix Operations

**Concepts:** Multidimensional Arrays

**Instructions:**
* Input two 2D arrays.
* Perform addition, subtraction, multiplication.

📝 **Bonus:** Validate dimensions and handle exceptions.

---

### ✅ Problem 39: Date & Time Utility

**Concepts:** `DateTime`, `TimeSpan`, Formatting

**Instructions:**
* Ask user for their birth date.
* Calculate and display age in years, months, and days.

📝 **Bonus:** Show days until next birthday.

---

### ✅ Problem 40: File-Based To-Do List

**Concepts:** Enums + File I/O + Collections + Exception Handling

**Instructions:**
* Use `TaskStatus` enum from Problem 31.
* Allow adding, removing, completing tasks.
* Save and load tasks from a `todo.txt` file.

📝 **Bonus:** Show summary grouped by task status.

---

## ⚡ Level 5 – Delegates, Events, and Lambdas (Problems 41–50)

**Learning Goals:** Master delegates, events, lambda expressions, and event-driven programming

---

### ✅ Problem 41: Basic Delegate Invocation

**Concepts:** `delegate`, `method reference`, `invocation`

**Instructions:**
* Define a delegate that takes two integers and returns their sum.
* Create a static method that performs the addition.
* Assign the method to the delegate and invoke it.

📝 **Bonus:** Display the method name being invoked using `Delegate.Method.Name`.

---

### ✅ Problem 42: Multicast Delegate Logger

**Concepts:** `multicast delegate`, `+=`, `-=`

**Instructions:**
* Create a delegate `Logger` that points to multiple methods like `Info`, `Warning`, and `Error`.
* Each method prints a log message with different formatting.
* Demonstrate adding and removing methods dynamically.

📝 **Bonus:** Use a timestamp (`DateTime.Now`) in the log output.

---

### ✅ Problem 43: Delegate as a Parameter

**Concepts:** passing delegates, flexible callbacks

**Instructions:**
* Create a function `ProcessNumbers(List<int> numbers, Delegate operation)` that applies an operation to each number.
* Pass different delegate methods for operations like doubling, squaring, or negating.

📝 **Bonus:** Show how to use anonymous methods instead of named methods.

---

### ✅ Problem 44: Event-Driven Download Simulator

**Concepts:** `event`, `delegate`, `event handler pattern`

**Instructions:**
* Create a `FileDownloader` class with an event `DownloadCompleted`.
* Simulate a file download using `Thread.Sleep` or a simple loop.
* Raise the event when the "download" finishes and display a message in the subscriber class.

📝 **Bonus:** Add progress notifications using a second event `ProgressChanged`.

---

### ✅ Problem 45: Custom Event Publisher-Subscriber

**Concepts:** `custom event`, `event keyword`, `EventArgs`

**Instructions:**
* Build a simple event system for a "Stock Price Tracker."
* `Stock` class raises an event when the price changes.
* `Investor` class subscribes and prints a message when notified.

📝 **Bonus:** Include old and new price values in the event arguments.

---

### ✅ Problem 46: Anonymous Methods and Inline Delegates

**Concepts:** `anonymous method`, inline delegate syntax

**Instructions:**
* Write a program that filters even numbers from a list using an anonymous method.
* Use a delegate `FilterDelegate` that takes an integer and returns a bool.

📝 **Bonus:** Display how many numbers were filtered.

---

### ✅ Problem 47: Lambda Expression Practice

**Concepts:** `lambda expressions`, `Func`, `Action`, `Predicate`

**Instructions:**
* Demonstrate all three types of built-in delegates using lambdas:
  * `Action<string>` → Prints a message.
  * `Func<int, int, int>` → Returns sum of two integers.
  * `Predicate<int>` → Checks if a number is even.

📝 **Bonus:** Store multiple lambdas in a list and invoke them sequentially.

---

### ✅ Problem 48: Sorting and Filtering with Delegates

**Concepts:** combining delegates with collections

**Instructions:**
* Given a list of employee objects (Name, Age, Salary):
  * Use a delegate or lambda to sort employees by salary.
  * Use another delegate to filter employees older than 30.

📝 **Bonus:** Use `List<T>.FindAll()` and `Comparison<T>` delegate.

---

### ✅ Problem 49: Event-Based Timer

**Concepts:** `event-driven design`, `timer`, `callback`

**Instructions:**
* Create a custom `Timer` class that raises an event every second.
* The subscriber prints elapsed seconds.
* Stop after 5 ticks.

📝 **Bonus:** Show how to unsubscribe from the event mid-way.

---

### ✅ Problem 50: Event Notification System

**Concepts:** combining multiple concepts – delegates, events, lambdas, OOP

**Instructions:**
* Design a mini **Notification System**:
  * `Notifier` class – raises an event `OnNotify`.
  * `EmailService`, `SMSService`, and `PushService` subscribe to it.
  * When a notification is triggered, all subscribers respond.

📝 **Bonus:** Add filtering so some services only respond to certain message types (e.g., "Alert", "Info", "Warning").

---

## 🧩 Level 6 – Generics, Nullable Types & Advanced Class Features (Problems 51–60)

**Learning Goals:** Master generics, nullable types, static/partial/extension methods, pattern matching, and anonymous types

---

### ✅ Problem 51: Generic Value Swapper

**Concepts:** `Generic Method`, `Type Parameter`, `Constraints`

**Instructions:**
* Create a generic method `Swap<T>(ref T a, ref T b)` that swaps two variables of any type.
* Demonstrate its use with integers, strings, and custom objects.

📝 **Bonus:** Add type constraints (e.g., `where T : struct`) and handle nullables gracefully using `?.` and `??`.

---

### ✅ Problem 52: Generic Repository Simulator

**Concepts:** `Generic Class`, `List<T>`, `where T : class`

**Instructions:**
* Simulate a simple data repository using a generic class `Repository<T>` that supports:
  * `Add`, `Remove`, `GetAll` methods
  * Generic type constraint: only accepts class types

📝 **Bonus:** Add basic error handling for null references and print all repository contents neatly.

---

### ✅ Problem 53: Nullable Product Pricing

**Concepts:** `Nullable<T>`, `HasValue`, `??`, `?.`

**Instructions:**
* Write a program that reads a product name and an optional discount percentage.
* If the discount is null, assign it a default value using `??`.
* Show the final price and demonstrate safe operations with nullables.

📝 **Bonus:** Combine with exception handling from Level 3 – handle invalid numeric input gracefully.

---

### ✅ Problem 54: Static Utility Library

**Concepts:** `Static Class`, `Static Method`, `Encapsulation`

**Instructions:**
* Create a static class `MathHelper` with methods:
  * `Square(int number)`
  * `Cube(int number)`
  * `IsPrime(int number)`
* Use these methods in `Main()` and log exceptions if invalid input is entered.

📝 **Bonus:** Integrate the logger from your earlier problem (Level 3 or 4) to store exceptions in a text file.

---

### ✅ Problem 55: Partial Class Implementation

**Concepts:** `Partial Class`, `Code Organization`

**Instructions:**
* Split a class `Employee` into two files:
  * One file handles personal info (name, age)
  * Another handles job details (designation, salary)
* Create an instance of the class and print combined info.

📝 **Bonus:** Add input validation and exceptions for missing fields.

---

### ✅ Problem 56: Extension Method Playground

**Concepts:** `Extension Methods`, `this` keyword, `String` manipulation

**Instructions:**
* Write an extension method `ToTitleCase(this string str)` that capitalizes the first letter of each word.
* Demonstrate by applying it to a list of names entered by the user.

📝 **Bonus:** Chain multiple extension methods (like `ToTitleCase()` + `TrimAll()`) for practice.

---

### ✅ Problem 57: Anonymous Type and LINQ Intro

**Concepts:** `Anonymous Types`, `var`, `LINQ Select`, `Where`

**Instructions:**
* Create a list of products and use LINQ to project anonymous types that only include `Name` and `Price`.
* Filter out products below a certain price threshold.

📝 **Bonus:** Format and print the results neatly with alignment.

---

### ✅ Problem 58: Index & Range Operators

**Concepts:** `Index`, `Range`, `from end`, slicing

**Instructions:**
* Take an array of integers and print:
  * The last 3 numbers using `^` (from end)
  * A slice of middle elements using `Range`

📝 **Bonus:** Use user input to dynamically choose slicing range.

---

### ✅ Problem 59: Pattern Matching in Switch

**Concepts:** `Pattern Matching`, `switch`, `is`, relational patterns

**Instructions:**
* Ask the user for input of different types (number, string, bool).
* Use **pattern matching** in a `switch` statement to determine the type and respond accordingly.

📝 **Bonus:** Add a type hierarchy (e.g., `Shape` → `Circle`, `Square`) and apply pattern matching for derived types.

---

### ✅ Problem 60: Generic Event Logger

**Concepts:** `Generic Delegate`, `Event`, `Type Safety`

**Instructions:**
* Create a generic event-based logger:
  * Declare a generic delegate `Logger<T>(T message)`
  * Raise events of different types (`string`, `int`, `DateTime`)
  * Handle events using lambda expressions

📝 **Bonus:** Integrate nullables and pattern matching for advanced event filtering.

---

## 🧮 Level 7 – LINQ, JSON, Regex & Data Manipulation (Problems 61–70)

**Learning Goals:** Master LINQ queries, JSON serialization/deserialization, regular expressions, and data pipelines

---

### ✅ Problem 61: Filtering and Sorting Products with LINQ

**Concepts:** `LINQ`, `Where`, `OrderBy`, `Select`

**Instructions:**
* Create a list of products (name, category, price).
* Use LINQ to:
  * Filter products above a certain price
  * Sort them by category, then by price

📝 **Bonus:** Group products by category and print summaries.

---

### ✅ Problem 62: LINQ Aggregation Dashboard

**Concepts:** `LINQ`, `Sum`, `Average`, `GroupBy`, `Count`

**Instructions:**
* Given a collection of sales records (product name, units sold, revenue), compute:
  * Total revenue
  * Average sale per product
  * Highest-selling item

📝 **Bonus:** Handle potential division by zero or empty data using `DefaultIfEmpty()`.

---

### ✅ Problem 63: LINQ with Complex Types

**Concepts:** LINQ with nested objects

**Instructions:**
* Create classes `Customer` and `Order`. Each customer has multiple orders.
* Use LINQ to:
  * List all customers with total order amounts
  * Find the top spender
  * Display orders above a certain amount

📝 **Bonus:** Format output in table-like alignment.

---

### ✅ Problem 64: Simple JSON Serializer

**Concepts:** `System.Text.Json`, `JsonSerializer.Serialize`

**Instructions:**
* Serialize a list of employees into a JSON file.
* Show a message when the file is created successfully.

📝 **Bonus:** Include a timestamp in the JSON file name using `DateTime.Now`.

---

### ✅ Problem 65: JSON Deserializer and Query

**Concepts:** `JsonSerializer.Deserialize`, LINQ on deserialized objects

**Instructions:**
* Deserialize the employee file created in the previous problem.
* Filter and print all employees whose salary is above a user-specified threshold.

📝 **Bonus:** Gracefully handle `FileNotFoundException` and malformed JSON using exception handling.

---

### ✅ Problem 66: JSON CRUD Operations

**Concepts:** Read/Write JSON, File Handling, LINQ Updates

**Instructions:**
* Create a small menu-based program that allows:
  * Adding a record
  * Updating a record
  * Deleting a record
  * Saving data back to JSON

📝 **Bonus:** Use `try-finally` to ensure file closure and show user-friendly messages.

---

### ✅ Problem 67: Regex Email and Phone Validator

**Concepts:** `Regex`, pattern matching

**Instructions:**
* Write a console program that asks the user to input an email and phone number.
* Use regex to validate both inputs and print whether they are valid.

📝 **Bonus:** Ask the user to retry until both inputs are valid using a loop and exception handling.

---

### ✅ Problem 68: Regex Data Extractor

**Concepts:** `Regex.Match`, `Groups`, `Named Captures`

**Instructions:**
* Given a string like `"Name: John Age: 29 Email: john@mail.com"`, extract each field using Regex.
* Print results in a neat format.

📝 **Bonus:** Store the extracted data in a custom object and serialize it to JSON.

---

### ✅ Problem 69: LINQ + JSON Mini Report

**Concepts:** Combining LINQ + JSON

**Instructions:**
* Deserialize a product JSON file, then use LINQ to:
  * Find the cheapest and most expensive product
  * Calculate total inventory value
  * Export a summary JSON file

📝 **Bonus:** Add nullable handling (`?.`, `??`) to prevent runtime crashes.

---

### ✅ Problem 70: Data Pipeline Integrator

**Concepts:** LINQ + JSON + Regex + Exception Handling Integration

**Instructions:**
* Build a small data pipeline that:
  1. Reads unstructured text from a `.txt` file (containing names, emails, and ages)
  2. Extracts structured info using **Regex**
  3. Converts data into objects and serializes them as **JSON**
  4. Queries the final data with **LINQ** for specific results

📝 **Bonus:** Add progress notifications using events or delegates from Level 5.

---

## ⚙️ Level 8 – Asynchronous Programming, Multithreading & Parallelism (Problems 71–80)

**Learning Goals:** Master async/await, threading, task-based programming, and parallel processing

---

### ✅ Problem 71: Basic Thread Creation

**Concepts:** `Thread`, `ThreadStart`

**Instructions:**
* Write a program that creates two threads – one prints numbers 1–10, another prints letters A–J.
* Run both simultaneously and observe the interleaved output.

📝 **Bonus:** Use `Thread.Sleep()` to control pacing and demonstrate scheduling differences.

---

### ✅ Problem 72: Thread Synchronization with Lock

**Concepts:** `lock`, shared resource

**Instructions:**
* Simulate a bank account accessed by two threads performing deposits and withdrawals.
* Use `lock` to prevent data corruption.

📝 **Bonus:** Show what happens when the lock is removed.

---

### ✅ Problem 73: ThreadPool Example

**Concepts:** `ThreadPool.QueueUserWorkItem`

**Instructions:**
* Simulate ten download tasks using the thread pool.
* Print start and completion messages for each task.

📝 **Bonus:** Time the execution and compare with manually created threads.

---

### ✅ Problem 74: Task-Based Asynchronous Programming

**Concepts:** `Task`, `Task.Run`, `Wait`, `WhenAll`

**Instructions:**
* Run three independent computations (e.g., factorial, Fibonacci, prime check) in parallel tasks.
* Await all results and display total execution time.

📝 **Bonus:** Compare the synchronous vs asynchronous runtime.

---

### ✅ Problem 75: Async/Await Basics

**Concepts:** `async`, `await`, `Task.Delay`

**Instructions:**
* Write an async method `DownloadFileAsync()` that simulates file download with delay.
* Print progress updates using events or callbacks.

📝 **Bonus:** Add a cancellation option using `CancellationTokenSource`.

---

### ✅ Problem 76: Exception Handling in Async Methods

**Concepts:** Exception propagation in async code

**Instructions:**
* Modify the previous problem to throw exceptions for invalid URLs.
* Catch and handle them gracefully in the calling method.

📝 **Bonus:** Use `AggregateException` to handle multiple task failures.

---

### ✅ Problem 77: Parallel.For and Parallel.ForEach

**Concepts:** `Parallel` class, parallel loops

**Instructions:**
* Given a list of numbers, compute their squares in parallel using `Parallel.ForEach`.
* Display thread IDs to show parallel execution.

📝 **Bonus:** Measure performance difference with sequential loops.

---

### ✅ Problem 78: Producer–Consumer Problem

**Concepts:** `BlockingCollection`, concurrency coordination

**Instructions:**
* Simulate producers adding items to a queue and consumers processing them.
* Show synchronization using `BlockingCollection`.

📝 **Bonus:** Add graceful shutdown using cancellation tokens.

---

### ✅ Problem 79: Async File I/O

**Concepts:** `FileStream`, `StreamReader`, `StreamWriter`, async I/O

**Instructions:**
* Create a program that reads a large file asynchronously, counts total lines, and writes the summary to another file.

📝 **Bonus:** Report progress using events or delegates.

---

### ✅ Problem 80: Async Data Pipeline

**Concepts:** Combining async + LINQ + JSON

**Instructions:**
* Simulate fetching JSON data asynchronously (use delay).
* Deserialize it and process it using LINQ queries while keeping the UI responsive (console messages).

📝 **Bonus:** Use `ConfigureAwait(false)` and explain its purpose in comments.

---

## 🧠 Level 9 – Reflection, Attributes, and Dynamic Features (Problems 81–90)

**Learning Goals:** Master reflection, custom attributes, metadata inspection, and dynamic programming

---

### ✅ Problem 81: Reflection Inspector

**Concepts:** `Reflection`, `System.Type`, `Assembly`

**Instructions:**
* Create a program that accepts a class name as input and prints all its methods, properties, and fields using reflection.
* Test with your previous classes.

📝 **Bonus:** Print custom attribute details if any are found.

---

### ✅ Problem 82: Custom Attribute and Reflection

**Concepts:** `Attributes`, `Reflection`, `Metadata`

**Instructions:**
* Create a custom attribute `[Developer("name", version)]`.
* Apply it to multiple classes.
* Use reflection to list all classes and their developer info.

📝 **Bonus:** Filter and display only classes developed by a specific author.

---

### ✅ Problem 83: Type Validator Using Reflection

**Concepts:** `Reflection`, `Custom Exceptions`, `Validation`

**Instructions:**
* Create a program that takes an object and checks if all public properties are non-null using reflection.
* Throw a custom exception if any property is null.

📝 **Bonus:** Use `[Required]` attribute to mark properties that must not be null.

---

### ✅ Problem 84: Basic Unit Testing Simulation

**Concepts:** `Unit Testing`, `Assertions`, `Encapsulation`

**Instructions:**
* Write a simple test framework that runs all methods starting with `Test` in a class.
* Print "✅ Passed" or "❌ Failed" for each test.

📝 **Bonus:** Count and display total tests run, passed, and failed.

---

### ✅ Problem 85: Metadata Logger

**Concepts:** `Attributes`, `File I/O`, `Reflection`

**Instructions:**
* Create a `[Log]` attribute that logs method execution to a file.
* When a `[Log]`-marked method is executed, append its name and timestamp to a log file.

📝 **Bonus:** Include parameters and return value in the log entry.

---

### ✅ Problem 86: Generic Repository Simulation

**Concepts:** `Generics`, `Interfaces`, `OOP`

**Instructions:**
* Create an interface `IRepository<T>` with methods `Add`, `Remove`, `GetAll`.
* Implement it for a `User` class using an internal list.

📝 **Bonus:** Add persistence by saving and loading data to/from a JSON file.

---

### ✅ Problem 87: Reflection-Based Factory

**Concepts:** `Reflection`, `Object Creation`, `Dynamic Loading`

**Instructions:**
* Implement a factory that creates an instance of a class by its name string using reflection.
* Demonstrate with multiple classes.

📝 **Bonus:** Allow the factory to create classes from a loaded assembly file.

---

### ✅ Problem 88: Attribute-Based Command Runner

**Concepts:** `Attributes`, `Reflection`, `Dynamic Invocation`

**Instructions:**
* Define a `[Command("name")]` attribute for methods.
* Build a console app that lists available commands and executes them when user types the command name.

📝 **Bonus:** Support command parameters dynamically.

---

### ✅ Problem 89: Dynamic Type Loader (Assembly)

**Concepts:** `Assembly Loading`, `Reflection`, `Dynamic Types`

**Instructions:**
* Create a program that loads an external assembly (DLL) at runtime.
* List all types in the assembly and allow instantiation of classes by name.

📝 **Bonus:** Invoke methods on dynamically created instances.

---

### ✅ Problem 90: Attribute-Based Command Executor

**Concepts:** `Attributes`, `Reflection`, `Command Pattern`

**Instructions:**
* Expand Problem 88 to support:
  * Command aliases (e.g., `[Command("help", "h", "?")]`)
  * Parameter validation
  * Help text generation from attributes

📝 **Bonus:** Add error handling for invalid commands and missing parameters.

---

## 🚀 Level 10 – Advanced Async & Integration (Problems 91–100)

**Learning Goals:** Combine async pipelines, PLINQ, orchestration, and integrate all learned concepts

---

### ✅ Problem 91: Simple Async Downloader

**Concepts:** `async/await`, `HttpClient`, `I/O`

**Instructions:**
* Write an asynchronous method that downloads the HTML content of a given URL.
* Display the size (in bytes) and first 200 characters of the response.

📝 **Bonus:** Allow downloading multiple URLs in sequence asynchronously.

---

### ✅ Problem 92: Parallel URL Fetcher

**Concepts:** `Task`, `Task.WhenAll`, `async/await`

**Instructions:**
* Extend the previous program to fetch multiple URLs **in parallel** using `Task.WhenAll`.
* Print the time taken vs. sequential execution.

📝 **Bonus:** Display the fastest and slowest download.

---

### ✅ Problem 93: Background File Copier

**Concepts:** `Task.Run`, `I/O`, `Progress Reporting`

**Instructions:**
* Create a program that copies a large file using `Task.Run` so the main thread remains responsive.
* Show progress percentage in the console.

📝 **Bonus:** Add a cancellation feature using `CancellationToken`.

---

### ✅ Problem 94: Parallel Array Processor

**Concepts:** `Parallel.For`, `PLINQ`, `Performance`

**Instructions:**
* Create a large integer array and use `Parallel.For` to compute the square of each element.
* Compare time taken with a regular `for` loop.

📝 **Bonus:** Use `PLINQ` (`AsParallel()`) to perform the same operation.

---

### ✅ Problem 95: Async File Reader and Writer

**Concepts:** `FileStream`, `StreamReader`, `StreamWriter`, `async/await`

**Instructions:**
* Create a program that reads text from a file asynchronously, converts it to uppercase, and writes it to a new file.
* Display total time taken.

📝 **Bonus:** Run multiple read/write operations concurrently for multiple files.

---

### ✅ Problem 96: Multithreaded Counter

**Concepts:** `Thread`, `lock`, `Synchronization`

**Instructions:**
* Create multiple threads that increment a shared counter.
* Use `lock` to prevent race conditions and display final count.

📝 **Bonus:** Demonstrate what happens **without** `lock` to show race condition.

---

### ✅ Problem 97: Thread Pool Example

**Concepts:** `ThreadPool`, `QueueUserWorkItem`, `WaitCallback`

**Instructions:**
* Queue several work items (tasks) to the thread pool and print thread IDs being used.
* Compare with manually created threads.

📝 **Bonus:** Measure performance difference between manual threads and thread pool.

---

### ✅ Problem 98: Async Pipeline Simulation

**Concepts:** `Task Chaining`, `Dataflow Simulation`, `async/await`

**Instructions:**
* Create a 3-step data pipeline:
  1. Generate random numbers.
  2. Process them (e.g., multiply by 2).
  3. Write results to a file.
* Each step should be asynchronous.

📝 **Bonus:** Display step-wise progress and total elapsed time.

---

### ✅ Problem 99: Parallel LINQ Analyzer

**Concepts:** `PLINQ`, `LINQ`, `Performance`

**Instructions:**
* Create a program that analyzes a large list of strings (e.g., words from a file).
* Use `PLINQ` to find the most frequent word.

📝 **Bonus:** Compare performance between LINQ and PLINQ and print the difference.

---

### ✅ Problem 100: Async Task Orchestrator

**Concepts:** `async/await`, `Task.WhenAll`, `Error Handling`, `Logging`

**Instructions:**
* Create a console app that simulates multiple independent background tasks:
  * Data Fetch
  * File Write
  * API Simulation
* Run all tasks concurrently and handle exceptions gracefully.

📝 **Bonus:** Use a logging system that writes status messages asynchronously to a file.

---

## 💡 Capstone Project – Async File Manager CLI

**Integrate everything learned:**
* Async file operations (copy, move, rename, search)
* Parallel search and indexing
* Event-based progress notifications
* Reflection-based logging and command execution
* LINQ for file filtering
* JSON configuration storage

This capstone project will demonstrate mastery of all 100 problems and serve as a portfolio piece.

---

## 📊 Progress Tracking

**Level 1:** ✅✅✅✅✅✅✅✅✅✅ (10/10)  
**Level 2:** ✅✅✅✅✅✅✅✅✅✅ (10/10)  
**Level 3:** ✅✅✅✅✅✅✅✅✅✅ (10/10)  
**Level 4:** ✅✅✅✅✅✅✅✅✅✅ (10/10)  
**Level 5:** ✅✅✅✅✅✅✅✅✅✅ (10/10)  
**Level 6:** ✅✅☐☐☐☐☐☐☐☐ (2/10)  
**Level 7:** ☐☐☐☐☐☐☐☐☐☐ (0/10)  
**Level 8:** ☐☐☐☐☐☐☐☐☐☐ (0/10)  
**Level 9:** ☐☐☐☐☐☐☐☐☐☐ (0/10)  
**Level 10:** ☐☐☐☐☐☐☐☐☐☐ (0/10)

**Total Progress:** 50/100

---

## 🎯 Tips for Success

1. **Complete problems in order** – Each level builds on previous concepts
2. **Don't skip the bonus challenges** – They reinforce learning and add depth
3. **Write clean, commented code** – Practice professional coding habits
4. **Test edge cases** – Always validate input and handle errors
5. **Review previous problems** – Integrate old concepts into new solutions
6. **Build the capstone project** – It ties everything together

---

✅ **Good luck on your C# mastery journey!**