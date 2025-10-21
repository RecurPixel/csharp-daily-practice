// **Concepts:** StreamReader, Loops, Exception Handling  
// - Read contents of `log.txt` line-by-line and display them.  
// - Handle missing file exception gracefully.  
// 🧩 **Bonus:** Count total lines (entries).


class LogReader
{
    public const string logFilePath = "log.txt";
    public static void Main(string[] args)
    {
        try
        {
            using(StreamReader sr = new StreamReader(logFilePath))
            {
                int lineCount = 0;
                string? line;
                // while (!sr.EndOfStream)
                // {
                //     string line = sr.ReadLine();
                //     Console.WriteLine(line);
                //     lineCount++;
                // }
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    lineCount++;
                }
                Console.WriteLine($"Total Lines: {lineCount}");
            }
            
        }catch (FileNotFoundException) {
            Console.WriteLine($"\nFile not found. Please ensure '{logFilePath}' exists.");
        }catch(IOException ex)
        {
            Console.WriteLine("\nError: Unable to read file. Details: " + ex.Message);
        }catch(Exception ex)
        {
            Console.WriteLine("\nSomething Went Wrong. Details: " + ex.Message);
        }
        
    }
}