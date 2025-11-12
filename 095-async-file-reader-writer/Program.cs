// ### ✅ Problem 95: Async File Reader and Writer

// **Concepts:** `FileStream`, `StreamReader`, `StreamWriter`, `async/await`

// **Instructions:**
// * Create a program that reads text from a file asynchronously, converts it to uppercase, and writes it to a new file.
// * Display total time taken.

// 📝 **Bonus:** Run multiple read/write operations concurrently for multiple files.


using System.Diagnostics;

class AysncFileIO
{

    public static async Task Main()
    {
        string[] fileList = ["README.md", ".gitignore", "csharp-daily-practice.sln"];

        var progressHandler = new Progress<string>(message => Console.WriteLine(message));

        var tasks = fileList.Select(file => ProcessFileAsync(progressHandler, file));

        await Task.WhenAll(tasks);

        Console.WriteLine($"Conversion Complete.");

    }
    
    private static async Task ProcessFileAsync(IProgress<string> progress, string file)
    {

        try
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            progress.Report($"Starting Conversion for `{file}`. {DateTime.Now}");

            // await using FileStream fsR = new FileStream(file, FileMode.Open);
            // using StreamReader sr = new StreamReader(fsR);

            // await using FileStream fsW = new FileStream("OUTPUT_"+file, FileMode.OpenOrCreate);
            // using StreamWriter sw = new StreamWriter(fsW);

            // while (!sr.EndOfStream)
            // {
            //     var tempString = await sr.ReadLineAsync();
            //     await sw.WriteLineAsync(tempString?.ToUpper());
            // }

            string fileContent = await File.ReadAllTextAsync(file);

            string upperContent = fileContent.ToUpper();

            await File.WriteAllTextAsync("OUTPUT_" + file, upperContent);

            progress.Report($"Process Complete for `{file}`. Output saved at `{"OUTPUT_" + file}`");
            stopwatch.Stop();
            progress.Report($"Time Taken: {stopwatch.Elapsed}");

        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File Not Fount. File: `{"OUTPUT_"+file}`");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Something went wrong while writing. Error: {ex.Message}");
        }
        
    }
}
