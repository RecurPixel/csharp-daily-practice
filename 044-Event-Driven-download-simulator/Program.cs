// **Concepts:** `event`, `delegate`, `event handler pattern`

// * Create a `FileDownloader` class with an event `DownloadCompleted`.
// * Simulate a file download using `Thread.Sleep` or a simple loop.
// * Raise the event when the “download” finishes and display a message in the subscriber class.

// **📝 Bonus:**
// Add progress notifications using a second event `ProgressChanged`.


using System.Threading;


class DownloadEventArgs: EventArgs
{
    public string Progress { get; }
    public DownloadEventArgs(string progress)
    {
        Progress = progress;
    }
}

// Event Class
class FileDownloader
{
    public event EventHandler DownloadCompleted;
    public event EventHandler<DownloadEventArgs> ProgressChanged;

    public void Start()
    {
        for (int i = 0; i <= 100; i++)
        {
            OnProgressChanged($"Download Progress: {i}%");
            Thread.Sleep((i % 10) * 100);
        }
        OnDownloadComplete();
    }

    protected virtual void OnDownloadComplete()
    {
        DownloadCompleted?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnProgressChanged(string progress)
    {
        ProgressChanged?.Invoke(this, new DownloadEventArgs(progress));
    }


}


// Subscriber class
class DownloadManager
{

    static void DownloadCompletedHandler(object sender, EventArgs e)
    {
        Console.WriteLine("\nDownload Completed!");
    }

    static void ProgressChangedHandler(object sender, DownloadEventArgs e)
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(e.Progress);
    }

    public static void Main()
    {
        FileDownloader fileDownloader = new FileDownloader();

        fileDownloader.DownloadCompleted += DownloadCompletedHandler;
        fileDownloader.ProgressChanged += ProgressChangedHandler;

        fileDownloader.Start();

    }

}


/*

Simple Understanding:

Event Handler Class: 
                    - This class has some tasks to handle but we do not want to track these tasks.
                    - So what do we do. We tell it to process on it's on and call back on some function. i.e. a delegate.
                    - simply it has a delegate or it's derevative event. that stores reference to object
                    - how do we know that which process is which? We solve this by passing reference and data from this class to caller
Event Subscriber:
                    - This class simply use functionality of event handler.
                    - How? It creates an instance of the handler, assign delegate, and call specific method on it.

It is not that complicated it is just application on delegates(callback) that allows us event driven development. 
For event driven development to work there is need of delegates/a type that can hold reference to methods and a way to handle concurrency (threading).


*/