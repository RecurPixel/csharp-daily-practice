class BookNotFoundException: Exception
{
    public BookNotFoundException()
    {
        
    }
}

class MemberNotFoundException: Exception
{
    public MemberNotFoundException()
    {
        
    }
}

class BookAlreadyBorrowedException: Exception
{
    public BookAlreadyBorrowedException()
    {
        
    }
}


class Book
{
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
        return $"Book: Title = {Title}, Id = {Id}, Author = {Author}";
    }

}

class Member
{
    public int Id { get; set; }
    public string Name { get; set; }

    protected List<Book> BorrowedBooks = new List<Book>();

    public Member(int id, string name, List<Book> borrowedBooks)
    {
        this.Id = id;
        this.Name = name;
        this.BorrowedBooks = borrowedBooks;
    }

    public override string ToString()
    {
        return $"Member: Name = {Name}, Id = {Id}";
    }

}

class Library
{
    private Dictionary<int, Book> Books = new Dictionary<int, Book>();
    private Dictionary<int, Member> Members = new Dictionary<int, Member>();

    public bool AddBook(Book book)
    {
        try
        {
            this.Books.Add(book.Id, book);
            return true;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: Unable to add book" + ex.Message);
            return false;
        }
    }

    public bool AddMember(Member member)
    {
        try
        {
            this.Members.Add(member.Id, member);
            return true;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: Unable to add Member" + ex.Message);
            return false;
        }
    }

    protected bool ListAvailableBooks()
    {
        Console.WriteLine("Available Books");
        foreach (KeyValuePair<int, Book> book in Books)
        {
            if (book.IsAvailable)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }

    public bool BorrowBook(int bookId, int memberId)
    {
        if (!Books.TryGetValue(bookId, out Book book) && !Members.TryGetValue(memberId, out Member member))
        {
            Console.WriteLine($"\nError: Book ID {bookId} or Member ID {memberId} not found");
        }

        if (!book.IsAvailable)
        {
            Console.WriteLine($"\nERROR: Book '{book.Title}' is currently not available.");
            return false;
        }

        book.IsAvailable = false;

        member.BorrowedBooks.Add(book);
        
        Console.WriteLine($"\nSUCCESS: '{book.Title}' borrowed by {member.Name}.");
        return true;
    }
    
    public bool ReturnBook(int bookId, int memberId)
    {

        if (!Books.TryGetValue(bookId, out Book book) || !Members.TryGetValue(memberId, out Member member))
        {
            Console.WriteLine($"\nERROR: Book ID {bookId} or Member ID {memberId} not found.");
            return false;
        }

        // this can be done with foreach loop as well
        Book bookToRemove = member.BorrowedBooks.Find(b => b.Id == bookId);

        

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