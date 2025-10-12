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
