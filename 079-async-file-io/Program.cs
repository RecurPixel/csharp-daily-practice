// ### ✅ Problem 79: Async File I/O

// **Concepts:** `FileStream`, `StreamReader`, `StreamWriter`, async I/O

// **Instructions:**
// * Create a program that reads a large file asynchronously, counts total lines, and writes the summary to another file.

// 📝 **Bonus:** Report progress using events or delegates.


using System.Reflection.Metadata;
using System.Threading.Tasks;

class AysncFileIO
{
    private const string InputFileName = "README.md";
    private const string OutFileName = "output.txt";

    public static async Task Main()
    {
        var progressHandler = new Progress<string>(message => Console.WriteLine(message));

        Task<bool> isComplete = ProcessFileAsync(progressHandler);


        // Note: Here we are not geting value from await. if we do await will unwrap it and provide returned value.
        // We can get return value from awit and check it directly or. like we have done we can simply check isComplete.Result which is task wraped value.
        await isComplete;

        if (isComplete.Result)
        {
            Console.WriteLine("Process Complete Please check output.txt");
            return;
        }
        Console.WriteLine("Unable to complete Operation");
    }
    
    private static async Task<bool> ProcessFileAsync(IProgress<string> progress)
    {
        int totalLineCount = 0;
        int emptyLineCount = 0;
        int totalWordCount = 0;

        try
        {
            progress.Report("Starting File I/O");
            await using (FileStream fs = new FileStream(InputFileName, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        var tempString = await sr.ReadLineAsync();

                        if (String.IsNullOrEmpty(tempString))
                        {
                            emptyLineCount++;
                            totalLineCount++;
                        }
                        else
                        {
                            totalLineCount++;
                            totalWordCount += tempString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();
                        }
                    }
                }
                progress.Report("File Reading Complete");

                string output = $"Total Lines: {totalLineCount}\nEmpty Lines: {emptyLineCount}\nTotal Words: {totalWordCount}";
                // Console.WriteLine(output);
                
                progress.Report("Writing to Output file");
                try
                {
                    await File.WriteAllTextAsync(OutFileName, output);
                    progress.Report("Writing Complete");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"File Not Fount. File: `{OutFileName}`");
                    return false;
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Something went wrong while writing. Error: {ex.Message}");
                    return false;
                }
            }
            return true;

        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File Not Fount. File: `{InputFileName}`");
            return false;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Something went wrong while writing. Error: {ex.Message}");
            return false;
        }
        
    }
}