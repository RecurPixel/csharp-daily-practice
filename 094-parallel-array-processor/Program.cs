// ### ✅ Problem 94: Parallel Array Processor

// **Concepts:** `Parallel.For`, `PLINQ`, `Performance`

// **Instructions:**
// * Create a large integer array and use `Parallel.For` to compute the square of each element.
// * Compare time taken with a regular `for` loop.

// 📝 **Bonus:** Use `PLINQ` (`AsParallel()`) to perform the same operation.

using System.Diagnostics;

class ParallelArrayProcessor
{
    public static void Main(string[] args)
    {

        long[] largeIntegerArray = new long[100000000];

        long[] resultsParallelFor = new long[100000000];
        long[] resultsForLoop = new long[100000000];
        long[] resultsAsParallel = new long[100000000];

        Parallel.For(0, 100000000, (i) => largeIntegerArray[i] = i);


        Stopwatch stopwatchWithParallel_For = Stopwatch.StartNew();
        Parallel.For(0, 100000000, (i) => resultsParallelFor[i] = i * i);
        stopwatchWithParallel_For.Stop();


        Stopwatch stopwatchWith_ForLoop = Stopwatch.StartNew();
        for (long i = 0; i < 100000000; i++)
        {
            resultsForLoop[i] = i * i;
        }
        stopwatchWith_ForLoop.Stop();

        Stopwatch stopwatchWith_AsParallel = Stopwatch.StartNew();

        resultsAsParallel = largeIntegerArray.AsParallel().Select(num => num * num).ToArray<long>();

        stopwatchWith_AsParallel.Stop();

        Console.WriteLine($"With Parallel.For: {stopwatchWithParallel_For.ElapsedMilliseconds}");
        Console.WriteLine($"With For Loop: {stopwatchWith_ForLoop.ElapsedMilliseconds}");
        Console.WriteLine($"With AsParallel: {stopwatchWith_AsParallel.ElapsedMilliseconds}");
    }
}

// Output:
// With Parallel.For: 410
// With For Loop: 883
// With AsParallel: 1664


// Method,Time (ms),Takeaway
// Parallel.For,Fastest (410),Offers the best performance here because it provides the lowest overhead and high control for simple loop-based data-independent tasks. The framework efficiently chunks the work and writes directly to the destination array.
// For Loop,Medium (883),"This is the baseline, showing a near 2x speedup with parallelism (which is expected on a multi-core machine)."
// AsParallel() (PLINQ),Slowest (1664),"While conceptually cleaner, PLINQ is slower here. This is because it introduces significant overhead for partitioning (breaking the list into chunks) and merging (assembling the final ToArray() result). For a very simple operation like squaring, the overhead outweighs the parallel speedup."