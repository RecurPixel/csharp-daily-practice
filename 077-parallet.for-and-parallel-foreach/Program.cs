// ### ✅ Problem 77: Parallel.For and Parallel.ForEach

// **Concepts:** `Parallel` class, parallel loops

// **Instructions:**
// * Given a list of numbers, compute their squares in parallel using `Parallel.ForEach`.
// * Display thread IDs to show parallel execution.

// 📝 **Bonus:** Measure performance difference with sequential loops.

using System.Diagnostics;

class ParallelPractice
{
    public static void Main(string[] args)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        long[] resultsParallel = new long[100000000];
        long[] resultsSequential = new long[100000000];
        stopwatch.Start();
        Parallel.For(0, 100000000, (i) => resultsParallel[i] = i * i);
        stopwatch.Stop();


        Stopwatch stopwatchOnSingleThread = Stopwatch.StartNew();

        stopwatchOnSingleThread.Start();
        for (long i = 0; i < 100000000; i++)
        {
            resultsSequential[i] = i * i;
        }
        stopwatchOnSingleThread.Stop();

        Console.WriteLine($"{resultsParallel[300]} == {resultsSequential[300]}");
        Console.WriteLine($"Time taken with Parallel Processing {stopwatch.ElapsedMilliseconds}");
        Console.WriteLine($"Time taken without Parallel Processing {stopwatchOnSingleThread.ElapsedMilliseconds}");
    }
}

// Note: It is not worth it to use Parallel for simple operations like these because of it's worth it.
// - Even in this example the result was minimal 678 - 351 = 327 mili second i.e 0.327 seconds
// - but for very complex and CPU intensive tasks it can be a game changer.