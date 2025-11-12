// ### ✅ Problem 100: Async Task Orchestrator

// **Concepts:** `async/await`, `Task.WhenAll`, `Error Handling`, `Logging`

// **Instructions:**
// * Create a console app that simulates multiple independent background tasks:
//   * Data Fetch
//   * File Write
//   * API Simulation
// * Run all tasks concurrently and handle exceptions gracefully.

// 📝 **Bonus:** Use a logging system that writes status messages asynchronously to a file.


using System.Threading.Tasks;

class AsyncTaskOrchestrator
{
    private static readonly string LogFileName = "task_orchestrator.log";

    public static async Task Main()
    {
        Console.WriteLine("Starting all tasks...");

        Task dataFetch = DataFetchTask();
        Task fileWrite = FileWriteTask();
        Task apiSim = APISimulationTask();

        var allTasks = new[] { dataFetch, fileWrite, apiSim };

        try
        {
            await Task.WhenAll(allTasks);
            Console.WriteLine("\nSUCCESS: All tasks completed successfully!");
        }
        catch (Exception ex)
        {
            if (ex is AggregateException aggEx)
            {
                Console.WriteLine($"\n--- One or more tasks failed ({aggEx.InnerExceptions.Count} failures) ---");
                
                foreach (var innerEx in aggEx.InnerExceptions)
                {
                    Console.WriteLine($"FAILURE: {innerEx.GetType().Name} in task: {innerEx.Message}");
                    await LogMessage($"Task Failed: {innerEx.GetType().Name}");
                }
            }
            else
            {
                var error = $"CRITICAL ERROR: {ex.Message}";
                Console.WriteLine(error);
                await LogMessage(error);
            }
        }

    }

    private static async Task DataFetchTask()
    {
        // 1. Simulate network delay (500ms - 1500ms)
        await Task.Delay(new Random().Next(500, 1500));
        
        // 2. Introduce random failure (e.g., 1 in 3 chance)
        if (new Random().Next(3) == 0)
        {
            throw new HttpRequestException("Simulated 404 Not Found error during data fetch.");
        }
        
        await LogMessage("Status [200]: Data Fetch Success.");
    }

    private static async Task FileWriteTask()
    {
        // 1. Simulate I/O access delay
        await Task.Delay(new Random().Next(300, 800));

        // 2. Introduce random failure
        if (new Random().Next(5) == 0)
        {
            throw new IOException("Simulated file permission denied error.");
        }
        
        await LogMessage("Success: File Write Complete.");
    }

    private static async Task APISimulationTask()
    {
        await Task.Delay(3000);
        await LogMessage("Status [200]: API Code Success.");
    }
    
    private static async Task LogMessage(string message)
    {
        string logEntry = $"{DateTime.Now:HH:mm:ss} | {message}\n";
        await File.AppendAllTextAsync(LogFileName, logEntry); 
    }
}