// **Concepts:** `multicast delegate`, `+=`, `-=`

// * Create a delegate `Logger` that points to multiple methods like `Info`, `Warning`, and `Error`.
// * Each method prints a log message with different formatting.
// * Demonstrate adding and removing methods dynamically.

// **📝 Bonus:**
// Use a timestamp (`DateTime.Now`) in the log output.

class MuliCastDelegatePractice
{
    public delegate void Logger(string message);

    public static void Info(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Info: Info method Invoded!. Message {message}; [{DateTime.Now.ToString()}]");
        Console.ResetColor();
    }

    public static void Warning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Warning: Warning method Invoded!. Message {message}; [{DateTime.Now.ToString()}]");
        Console.ResetColor();
    }

    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: Error method Invoded!. Message {message}; [{DateTime.Now.ToString()}]");
        Console.ResetColor();
    }

    public static void Main()
    {
        Logger loggerD = Info;
        loggerD += Warning;
        loggerD += Error;

        loggerD.Invoke("Invoking Delegate with all Methods.");

        loggerD -= Warning;
        loggerD -= Error;


        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nAfter Removing Methods reference from delegate");
        loggerD.Invoke("Invoking Delegate after removing few methods. ");
        Console.ResetColor();
    }


}