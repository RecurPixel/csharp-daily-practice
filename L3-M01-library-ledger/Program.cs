// Note:
// 1. This program has many flaws and can be further improved
// 2. These flaws are kept purposefully. To reflect later and because few topics are not covered yet.
// 3. Few areas of implement.
//     - Better file handling
//     - beter exception handling
//     - Helper functions implementation can be improved and make them generic
//     - better use of Dictionary and using book id for search instead of bookname(could provide better lookup)



using System.Text.Json;
using System.IO;

public enum BookGenre
{
    Fantasy,
    SiFi,
    Documentry

}
class BookNotFoundException : Exception
{
    public int Id { get; }
    public BookNotFoundException() : base("Book Not Found. Please try another book.") { }

    public BookNotFoundException(string message) : base(message) { }

    public BookNotFoundException(string message, Exception inner) : base(message, inner) { }

    public BookNotFoundException(int id) : base($"Book not found. Book with Id {id} does not exist.")
    {
        this.Id = id;
    }

}

class MemberNotFoundException : Exception
{
    public int Id { get; }
    public MemberNotFoundException() : base("Member Not Found. Please Try Again.") { }

    public MemberNotFoundException(string message) : base(message) { }

    public MemberNotFoundException(string message, Exception inner) : base(message, inner) { }

    public MemberNotFoundException(int id) : base($"Member not found. Member with Id {id} does not exist.")
    {
        this.Id = id;
    }
}

class BookAlreadyBorrowedException : Exception
{
    public int BookId { get; }
    public int MemberId { get; }
    public BookAlreadyBorrowedException() : base("Book Already Borrowed. Please try again later.") { }

    public BookAlreadyBorrowedException(string message) : base(message) { }

    public BookAlreadyBorrowedException(string message, Exception inner) : base(message, inner) { }

    public BookAlreadyBorrowedException(int bookId, int memberId) : base($"Book already borrowed. Book with Id {bookId} was borrowed by Member with id {memberId}.")
    {
        this.BookId = bookId;
        this.MemberId = memberId;
    }

}


class Book
{
    public Book() { }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; }

    public Book(int id, string title, string author, bool isAvailable)
    {
        this.Id = id;
        this.Title = title;
        this.Author = author;
        this.IsAvailable = isAvailable;
    }

    public override string ToString()
    {
        // Added availability status to output for better list clarity
        string status = IsAvailable ? "Available" : "Checked Out";
        return $"[ID: {Id}] Title: {Title}, Author: {Author} ({status})";
    }

}

class Member
{
    public Member()
    {
        // Initialize list in default constructor
        BorrowedBooks = new List<Book>();
    }
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Book> BorrowedBooks { get; set; } = new List<Book>();

    public Member(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public override string ToString()
    {
        return $"[ID: {Id}] Member: {Name}. Books borrowed: {BorrowedBooks.Count}.";
    }

}

class Library
{
    public Dictionary<int, Book> Books { get; set; } = new Dictionary<int, Book>();
    public Dictionary<int, Member> Members { get; set; } = new Dictionary<int, Member>();

    public Library() { }

    public bool AddBook(Book book)
    {
        if (this.Books.TryAdd(book.Id, book))
        {
            Console.WriteLine($"\nSUCCESS: Book '{book.Title}' added with ID: {book.Id}.");
            return true;
        }
        else
        {
            Console.WriteLine($"\nERROR: Unable to add book. Book with ID {book.Id} already exists.");
            return false;
        }
    }

    public bool AddMember(Member member)
    {
        if (this.Members.TryAdd(member.Id, member))
        {
            Console.WriteLine($"\nSUCCESS: Member '{member.Name}' added with ID: {member.Id}.");
            return true;
        }
        else
        {
            Console.WriteLine($"\nERROR: Unable to add member. Member with ID {member.Id} already exists.");
            return false;
        }
    }

    public void ListAvailableBooks()
    {
        Console.WriteLine("Available Books");
        Console.WriteLine("===============");
        bool found = false;
        foreach (KeyValuePair<int, Book> book in Books)
        {
            if (book.Value.IsAvailable)
            {
                Console.WriteLine(book.Value.ToString());
                found = true;
            }
        }
        if (!found)
        {
             Console.WriteLine("No books currently available.");
        }
        Console.WriteLine("===============");
    }

    public bool BorrowBook(int bookId, int memberId)
    {
        if (!Books.TryGetValue(bookId, out Book book))
        {
            throw new BookNotFoundException(bookId);
        }

        if (!Members.TryGetValue(memberId, out Member member))
        {
            throw new MemberNotFoundException(memberId);
        }

        if (!book.IsAvailable)
        {
            throw new BookAlreadyBorrowedException(bookId, 0); 
        }

        foreach (Book borrowedBook in member.BorrowedBooks)
        {
            if (borrowedBook.Id == bookId)
            {
                throw new BookAlreadyBorrowedException(bookId, memberId);
            }
        }

        book.IsAvailable = false;

        member.BorrowedBooks.Add(book);

        Console.WriteLine($"\nSUCCESS: '{book.Title}' borrowed by {member.Name}.");
        return true;
    }

    public bool ReturnBook(int bookId, int memberId)
    {

        if (!Books.TryGetValue(bookId, out Book book))
        {
            throw new BookNotFoundException(bookId);
        }

        if (!Members.TryGetValue(memberId, out Member member))
        {
            throw new MemberNotFoundException(memberId);
        }

        Book bookToRemove = null;
        foreach (Book borrowedBook in member.BorrowedBooks)
        {
            if (borrowedBook.Id == bookId)
            {
                bookToRemove = borrowedBook;
                break; // Exit loop immediately once found
            }
        }



        if (bookToRemove != null)
        {
            // 1. Remove the book from the member's list
            member.BorrowedBooks.Remove(bookToRemove);

            // 2. Update the book's availability status
            book.IsAvailable = true;

            Console.WriteLine($"\nSUCCESS: Book '{book.Title}' returned by {member.Name}.");
            return true;
        }
        else
        {
            Console.WriteLine($"\nERROR: Member {member.Name} did not have book '{book.Title}' checked out.");
            return false;
        }

    }
}

class LibraryLedger
{

    private static int _nextBookId = 1001;
    private static int _nextMemberId = 101; 
    private static int GetValidIntInput()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > 5)
        {
            Console.WriteLine("Enter Valid Input: ");
        }
        return input;

    }

    private static string GetValidStringInput(string msg = "Input: ")
    {
        Console.Write(msg);
        string input = Console.ReadLine();
        return input;
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\n====Menu====");
        Console.WriteLine("1: Add Book");
        Console.WriteLine("2: Add Member");
        Console.WriteLine("3: List Available Books");
        Console.WriteLine("4: Borrow Book");
        Console.WriteLine("5: Return Book");
        Console.WriteLine("0: Exit");
        Console.WriteLine("====Menu====\n");
    }


    public static void Main(string[] args)
    {
        bool exitProgram = false;
        string fileName = "library.json";
        string jsonStringFromFile = File.ReadAllText(fileName);
        Library l = JsonSerializer.Deserialize<Library>(jsonStringFromFile);

        while (!exitProgram)
        {
            int menuChoice;
            ShowMenu();
            menuChoice = GetValidIntInput();

            switch (menuChoice)
            {
                case 1:
                    try
                    {
                        int id = _nextBookId++;
                        string title, author;
                        bool isAvailable = true;

                        title = GetValidStringInput("Please Enter Book Title:");
                        author = GetValidStringInput("Please Enter Author Name:");

                        Book b = new Book(id, title, author, isAvailable);
                        l.AddBook(b);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        int id = _nextMemberId++;
                        string name;

                        name = GetValidStringInput("Please Enter Member Name:");

                        Member m = new Member(id, name);
                        l.AddMember(m);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 3:
                    try
                    {
                        l.ListAvailableBooks();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 4:
                    try
                    {
                        int bookId = 0;
                        int memberId = 0;
                        string bookTitle = GetValidStringInput("Please Enter Book Title:");
                        string memberName = GetValidStringInput("Please Enter Member Name:");
                        foreach (KeyValuePair<int, Book> b in l.Books)
                        {
                            if (b.Value.Title == bookTitle)
                            {
                                bookId = b.Key;
                                break;
                            }
                        }
                        foreach (KeyValuePair<int, Member> m in l.Members)
                        {
                            if (m.Value.Name == memberName)
                            {
                                memberId = m.Key;
                                break;
                            }
                        }
                        l.BorrowBook(bookId, memberId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 5:
                    try
                    {
                        int bookId = 0;
                        int memberId = 0;
                        string bookTitle = GetValidStringInput("Please Enter Book Title:");
                        string memberName = GetValidStringInput("Please Enter Member Name:");
                        foreach (KeyValuePair<int, Book> b in l.Books)
                        {
                            if (b.Value.Title == bookTitle)
                            {
                                bookId = b.Key;
                                break;
                            }
                        }
                        foreach (KeyValuePair<int, Member> m in l.Members)
                        {
                            if (m.Value.Name == memberName)
                            {
                                memberId = m.Key;
                                break;
                            }
                        }
                        l.ReturnBook(bookId, memberId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    exitProgram = true;
                    break;
            }
        }
        string jsonString = JsonSerializer.Serialize(l);
        Console.WriteLine(jsonString);
        File.WriteAllText(fileName, jsonString);            
        
    }
}