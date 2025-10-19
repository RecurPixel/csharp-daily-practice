📚 Library Ledger — Mini Project Outline

Goal: Apply Collections + Exception Handling in a real scenario while reinforcing OOP concepts and building a foundation for later expansion.

🧱 Phase 1 – Project Setup & Core Classes

Concept Focus: Basic class structure, properties, encapsulation

Tasks:

Create classes:

Book → Id, Title, Author, IsAvailable

Member → Id, Name, BorrowedBooks (List<Book>)

Use auto-implemented properties.

Add constructors for both.

Override ToString() to format output nicely.

🧩 What You Learn/Practice:
Encapsulation, constructors, auto-properties, object modeling.

📚 Phase 2 – Library Catalog Management

Concept Focus: Collections (List, Dictionary)

Tasks:

Create a Library class that holds:

Dictionary<int, Book> Books

Dictionary<int, Member> Members

Implement methods:

AddBook(Book book)

AddMember(Member member)

ListAvailableBooks()

Use loops and foreach to print data.

🧩 What You Learn/Practice:
Using collections to store and access objects, iterating over data.

⚙️ Phase 3 – Borrow and Return System

Concept Focus: Logic + Exception Handling

Tasks:

Add methods to Library:

BorrowBook(int bookId, int memberId)

ReturnBook(int bookId, int memberId)

Implement checks and throw exceptions:

BookNotFoundException

MemberNotFoundException

BookAlreadyBorrowedException

Catch these exceptions in Program.cs and print meaningful messages.

🧩 What You Learn/Practice:
Try/catch, creating custom exceptions, program flow control.

🧰 Phase 4 – Improving Robustness

Concept Focus: Validation, defensive coding, user input

Tasks:

Add helper methods to validate input.

Allow borrowing only if the book is available.

Prevent the same member from borrowing the same book twice.

Handle bad inputs gracefully with try/catch.

🧩 What You Learn/Practice:
Defensive programming, refining exception handling.

📄 Phase 5 – User Menu (Interactive Console)

Concept Focus: Control Structures + Collections Integration

Tasks:

In Program.cs, build a menu:

Add book/member

List books

Borrow/return

Exit

Use while(true) loop and switch for menu handling.

Wrap each action in try/catch for safety.

🧩 What You Learn/Practice:
Bringing together collections, loops, switch-case, exception handling, user interaction.

🧩 Optional Phase 6 – Preview of Next Level (Do Later)

Concept Focus: File I/O + Enums

Tasks:

Save/load library data to .txt or .json file.

Add an enum for BookGenre.

🧩 What You Learn/Practice:
File I/O operations, enums — acts as a sneak peek into Level 4.

🚀 Final Result

A working console-based library system that:

Manages books and members using collections,

Uses custom and built-in exceptions for robustness,

Has an expandable structure for future features (file save/load, sorting, searching, etc.).