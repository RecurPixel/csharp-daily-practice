// Note: This is not an optimal program and shoud only be refered for learning purpose.


class MultiExceptionHandling
{
    public static void Main(string[] args)
    {
        int[] nums = new int[10];
        Random r = new Random();
        for (int i = 0; i < 10; i++)
        {
            nums[i] = r.Next();
        }


        int index = 0;

        while (true)
        {
            int divisor;
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Ender Divisor to Divide {0} :",nums[index]);
                if(!int.TryParse(Console.ReadLine(), out divisor))
                {
                    throw new FormatException();
                }

                Console.WriteLine("{0} / {1} = {2}", nums[index], divisor, nums[index] / divisor);

                index++;
            }
            catch (FormatException fex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + fex.Message);
            }
            catch (DivideByZeroException dex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + dex.Message);
            }
            catch (IndexOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All numbers Divided. Program Complete.");
                break;
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Process Complete");
            }
                
        }
    }
}