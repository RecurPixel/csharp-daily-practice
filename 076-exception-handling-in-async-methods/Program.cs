// ### ✅ Problem 76: Exception Handling in Async Methods

// **Concepts:** Exception propagation in async code

// **Instructions:**
// * Modify the previous problem to throw exceptions for invalid URLs.
// * Catch and handle them gracefully in the calling method.

// 📝 **Bonus:** Use `AggregateException` to handle multiple task failures.

using System.Text.RegularExpressions;
using System.Threading.Tasks;

class InvalidURLException : ArgumentException
{
    public string AttemptedURL { get; }
    public InvalidURLException()
        : base("URL validation failed. Invalid URL.")
    {
    }
    public InvalidURLException(string message, Exception inner)
        : base(message, inner)
    {
    }

    public InvalidURLException(string AttemptedURL)
        : base($"URL validation failed. The entered url ({AttemptedURL}) is invalid.")
    {
        this.AttemptedURL = AttemptedURL;
    }
}

class AsyncAwaitPractice
{

    public static async Task Main()
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        var progressHandler = new Progress<string>(message => Console.WriteLine(message));

        List<string> urls = ["https://example.com", ".abc.com", ".com.abc", "www.abc.com"];

        IEnumerable<Task> downloadTasks = urls.Select(url => DownloadSingleFileAsync(url, progressHandler, cts.Token));

        try
        {
            Console.WriteLine("\nAwating Download Completion\n");

            // Task.WhenAll(downloadTasks); // need to be awated. because of this AggregatedException does not work.
            Task.WaitAll(downloadTasks); // Blocking Wait.

            Console.WriteLine("\nDownload Process Complete\n"); // This will not be called even if there is only one exception thrown
        }
        catch (AggregateException ex)
        {
            Console.WriteLine("Caught aggregate exception-Task.Wait behavior");
            ex.Handle((x) =>
            {
                if (x is InvalidURLException) // This we know how to handle.
                {
                    Console.WriteLine(x.Message);
                    return true;
                }
                return false; // Let anything else stop the application.
            });
        }
        catch(OperationCanceledException)
        {
            Console.WriteLine("Operation was Cancled");
        }


    }

    public static async Task DownloadSingleFileAsync(string url, IProgress<string> progress, CancellationToken token)
    {
            bool isValid = Regex.IsMatch(url, @"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?");
            if (!isValid)
            {
                throw new InvalidURLException(url);
            }
            else
            {
                for(int i = 0; i < 100; i++)
                {
                    progress.Report($"Resource `{url}` Downloading Progress {i + 1}%");
                    await Task.Delay(100, token);
                }
            }
    }
}
                    