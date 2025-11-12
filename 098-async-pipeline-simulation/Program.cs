// ### ✅ Problem 98: Async Pipeline Simulation

// **Concepts:** `Task Chaining`, `Dataflow Simulation`, `async/await`

// **Instructions:**
// * Create a 3-step data pipeline:
//   1. Generate random numbers.
//   2. Process them (e.g., multiply by 2).
//   3. Write results to a file.
// * Each step should be asynchronous.

// 📝 **Bonus:** Display step-wise progress and total elapsed time.


using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

class AsyncPipelineSimulation
{
    public static async Task Main()
    {
        string fileName = "output.txt";
        
        var generateNumbers = (int count) =>
        {
            return Enumerable.Range(0, count).ToArray<int>();
        };

        var squareOfNumbers = (int[] nums) =>
        {
            return nums.Select(n => n * n).ToArray<int>();
        };

        var showOutPut = async (int[] nums) =>
        {
            string output = "";
            foreach (var n in nums) output += n + " ";

            await File.WriteAllTextAsync(fileName, output);
        };

        Stopwatch _stopwatch = Stopwatch.StartNew();

        // var task1 = await Task.Run(() => generateNumbers(100)); // CPU bound work
        // Console.WriteLine($"\nTask 1 Done. TimeLapse: {_stopwatch.ElapsedMilliseconds}");
        // var task2 = await Task.Run(() => squareOfNumbers(task1)); // CPU bound work
        // Console.WriteLine($"\nTask 2 Done. TimeLapse: {_stopwatch.ElapsedMilliseconds}");
        // await showOutPut(task2); // IO bound work
        // Console.WriteLine($"\nTask 3 Done. TimeLapse: {_stopwatch.ElapsedMilliseconds}");
        // _stopwatch.Stop();

        // Task 1 Done. TimeLapse: 20

        // Task 2 Done. TimeLapse: 32

        // Task 3 Done. TimeLapse: 41

        // OR

        var task1 = Task.Run(() => generateNumbers(100)); // CPU bound work
        Console.WriteLine($"\nTask 1 Done. TimeLapse: {_stopwatch.ElapsedMilliseconds}");
        var task2 = task1.ContinueWith(t => squareOfNumbers(t.Result)); // CPU bound work
        Console.WriteLine($"\nTask 2 Done. TimeLapse: {_stopwatch.ElapsedMilliseconds}");
        var finalTask = task2.ContinueWith(t => showOutPut(t.Result)); // IO bound work
        Console.WriteLine($"\nTask 3 Done. TimeLapse: {_stopwatch.ElapsedMilliseconds}");
        _stopwatch.Stop();

        // Task 1 Done. TimeLapse: 4

        // Task 2 Done. TimeLapse: 13

        // Task 3 Done. TimeLapse: 14

    }
}