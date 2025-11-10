// ### ✅ Problem 74: Task-Based Asynchronous Programming

// **Concepts:** `Task`, `Task.Run`, `Wait`, `WhenAll`

// **Instructions:**
// * Run three independent computations (e.g., factorial, Fibonacci, prime check) in parallel tasks.
// * Await all results and display total execution time.

// 📝 **Bonus:** Compare the synchronous vs asynchronous runtime.

using System.Diagnostics;
using System.Threading.Tasks;

class TaskPractice
{
    public static async Task Main()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        Task<long> t1 = Task.Run(() => Factorial(21));

        Task<string> t2 = Task.Run(() => Fibonacci(21));

        Task<string> t3 = Task.Run(() => IsPrime(21));

        await Task.WhenAll(t1, t2, t3);

        long factResultAsync = t1.Result; // This is the 'long' returned by Factorial
        string fibResultAsync = t2.Result;   // This is the 'int' returned by Fibonacci
        string primeResultAsync = t3.Result; // This is the 'bool' returned by IsPrime

        Console.WriteLine($"Async:\nFactorial = {factResultAsync}\nFibonaci Sequence = {fibResultAsync}\nPrime Resutl = {primeResultAsync}");

        stopwatch.Stop();

        Console.WriteLine($"Total time taken Async: {stopwatch.Elapsed}");

        Stopwatch stopwatchSync = Stopwatch.StartNew();
        long factResult = await Factorial(21);
        string fibResult = await Fibonacci(21);
        string primeResult = await IsPrime(21);

        Console.WriteLine($"Sync:\nFactorial = {factResult}\nFibonaci Sequence = {fibResult}\nPrime Resutl = {primeResult}");

        stopwatchSync.Stop();

        Console.WriteLine($"Total time taken Sync: {stopwatchSync.Elapsed}");

    }

    private static async Task<long> Factorial(int number)
    {
        await Task.Delay(2000);
        if (number < 0)
        {
            return 0L;
        }
        else
        {
            long factorial = 1;

            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }

    private static async Task<string> Fibonacci(int n)
    {
        string s;
        int numTerms = n;
        int a = 0;
        int b = 1;

        s = a + " " + b + " ";

        for (int i = 2; i < numTerms; i++)
        {
            int c = a + b;
            s += (c + " ");
            a = b;
            b = c;
        }
        Console.WriteLine();

        await Task.Delay(2000);
        return s;
    }

    private static async Task<string> IsPrime(int number)
    {
        bool isPrime = true;
        if (number <= 1)
        {
            isPrime = false;
        }
        if (number == 2)
        {
            isPrime = true;
        }
        if (number % 2 == 0)
        {
            isPrime = false;
        }

        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0)
            {
                isPrime = false;
            }
        }
        var msg = isPrime ? "Prime" : "Not Prime";
        await Task.Delay(2000);
        return msg;
    }
}




// Note: As The functions. Fibonaci, Fatorial, IsPrime are generally example of CPU bound operation. But Task.Delay patern as async await is used to for IO operation.
// Currently we are not concerned about what to use where but about possiblity itself. so no worries in due time we will understand.