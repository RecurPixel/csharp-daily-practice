// * Write a program that performs division of two numbers entered by the user.
// * Handle exceptions such as `DivideByZeroException` and `FormatException` using try-catch blocks.

// **📝 Bonus:**
// Add input validation using `TryParse` and a `finally` block to display `"Operation complete"`.


class SafeDivisionCalculator
{

    public static void Main(string[] args)
    {
        bool isValid = false;

        while(!isValid)
        {
            try
            {
                int n1;
                int n2;

                Console.ResetColor();
                Console.Write("Enter First number: ");

                if (!int.TryParse(Console.ReadLine(), out n1))
                {
                    throw new FormatException();
                }

                Console.Write("Enter Second number: ");
                if (!int.TryParse(Console.ReadLine(), out n2))
                {
                    throw new FormatException();   
                }

                try
                {
                    int c = n1 / n2;
                    Console.WriteLine("{0} / {1} = {2}", n1, n2, c);
                    isValid = true;
                }
                catch (DivideByZeroException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Program complete");
            }    
        }

        
    }
}