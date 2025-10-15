// * Read an integer from the user and calculate its square root.
// * Handle negative input (`ArgumentOutOfRangeException`) and invalid format (`FormatException`).

// **📝 Bonus:**
// Use nested try-catch blocks to separate **user input validation** from **calculation**.


class NestedExceptionHandling
{
    protected static double calculate(int n)
    {
        return Math.Sqrt(n);
    }
    public static void Main(string[] args)
    {
        try
        {
            int num;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter a positive number to find square root:");
            if (!int.TryParse(Console.ReadLine(), out num))
            {
                throw new FormatException();
            }
            try
            {
                if(num < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                double output = calculate(num);
                Console.WriteLine("sqrt({0}) = {1}",num, output);

            }catch(ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
            }
            
            
        }catch(FormatException ex){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}