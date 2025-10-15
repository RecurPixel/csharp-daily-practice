// * Create a custom exception `InvalidAgeException`.
// * Ask the user for their age and throw the exception if the age < 18.

// **📝 Bonus:**
// Add a property to your exception class to store and display the entered age.


class InvalidAgeException: ArgumentException
{
    public int AttemptedAge { get; }
    public InvalidAgeException() 
        : base("Age validation failed. Age must be 18 or older.")
    {
    }
    public InvalidAgeException(string message) 
        : base(message)
    {
    }
    public InvalidAgeException(string message, Exception inner) 
        : base(message, inner)
    {
    }
    
    public InvalidAgeException(int attemptedAge) 
        : base($"Age validation failed. The entered age ({attemptedAge}) is below the minimum requirement of 18.")
    {
        this.AttemptedAge = attemptedAge;
    }
}

class AgeValidation
{
    public static void Main(string[] args)
    {
        try
        {
            int age;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("What is your age? : ");

            if (!int.TryParse(Console.ReadLine(), out age))
            {
                throw new FormatException("The input provided was not a valid number.");
            }

            if (age < 18)
            {
                throw new InvalidAgeException(age);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Valid Age!");
        }catch(FormatException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nInput Format Error: {ex.Message}");
        }catch(InvalidAgeException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nAGE VALIDATION FAILED: {ex.Message}");
            Console.WriteLine($"Constraint: Age must be 18+. You entered: {ex.AttemptedAge}");
        }catch(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\nUnexpected System Error: {ex.Message}");
        }
    }   
}
