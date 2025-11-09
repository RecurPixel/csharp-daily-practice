// ### ✅ Problem 75: Async/Await Basics

// **Concepts:** `async`, `await`, `Task.Delay`

// **Instructions:**
// * Write an async method `DownloadFileAsync()` that simulates file download with delay.
// * Print progress updates using events or callbacks.

// 📝 **Bonus:** Add a cancellation option using `CancellationTokenSource`.

using System.Threading.Tasks;

class AsyncAwaitPractice
{

    public static async Task Main()
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        var progressHandler = new Progress<string>(message => Console.WriteLine(message));

        Task task = DownloadFileAsync(progressHandler, cts.Token);

        cts.CancelAfter(10000);

        Console.WriteLine("Awating Download Completion");

        try
        {
            await task;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operation canceled");
        }


    }
    
    public static async Task DownloadFileAsync(IProgress<string> progress, CancellationToken token)
    {
        for(int i = 0; i < 100; i++)
        {
            progress.Report($"Downloading Progress {i + 1}%");
            await Task.Delay(1000, token);
            // if (token.IsCancellationRequested)
            // {
            //     token.ThrowIfCancellationRequested();
            // }
            // No need of above code as Task.Delay Will be done after 1 sec or if token asked for termination
        }
    }
}