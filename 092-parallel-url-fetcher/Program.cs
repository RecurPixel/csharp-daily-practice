// ### ✅ Problem 92: Parallel URL Fetcher

// **Concepts:** `Task`, `Task.WhenAll`, `async/await`

// **Instructions:**
// * Extend the previous program to fetch multiple URLs **in parallel** using `Task.WhenAll`.
// * Print the time taken vs. sequential execution.

// 📝 **Bonus:** Display the fastest and slowest download.
using System.Net.Http;
using System.Text;
using System.Diagnostics;

class SimpleAsyncDownloader
{
    private static readonly HttpClient s_httpClient = new HttpClient();
    private static Dictionary<string, long> downloadSpeed = new Dictionary<string, long>();

    public static async Task Main()
    {
        try
        {
            string[] urls = new string[]
            {
                "https://example.com",
                "https://google.com",
                "https://recurpixel.io",
                "https://github.com/"
            };

            // Sequential Download

            Stopwatch stopwatchSequential = Stopwatch.StartNew();

            foreach(var url in urls)
            {
                await DownloadHTML(url);
            }

            stopwatchSequential.Stop();

            var fastestS = downloadSpeed.MaxBy(d => d.Value);
            var slowestS = downloadSpeed.MinBy(d => d.Value);

            downloadSpeed.Clear(); // Reset to avoid cache.

            // Paralled Download


            Stopwatch stopwatchParallel = Stopwatch.StartNew();

            var downloadTasks = urls.Select(url => DownloadHTML(url)).ToList();

            await Task.WhenAll(downloadTasks);

            stopwatchParallel.Stop();


            Console.WriteLine($"\nSequential Download Time: {stopwatchSequential.Elapsed}\nParallel Download Time: {stopwatchParallel.Elapsed}");
            Console.WriteLine("\nDownload Complete.");

            var fastestP = downloadSpeed.MaxBy(d => d.Value);
            var slowestP = downloadSpeed.MinBy(d => d.Value);

                        Console.WriteLine($"\nSequential\nFastest Download URL: `{fastestS.Key}` Timme(miniseconds): {fastestS.Value}\nSlowest Download URL: `{slowestS.Key}` Timme(miniseconds): {slowestS.Value}");
            Console.WriteLine($"\nParallel\nFastest Download URL: `{fastestP.Key}` Timme(miniseconds): {fastestP.Value}\nSlowest Download URL: `{slowestP.Key}` Timme(miniseconds): {slowestP.Value}");
            
        }catch(AggregateException ae)
        {
            foreach (var innerException in ae.InnerExceptions)
            {
                Console.WriteLine($"Caught inner exception: {innerException.GetType().Name} - {innerException.Message}");
            }
        }
        

    }
    private static async Task DownloadHTML(string requestUrl)
    {
        try
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            HttpResponseMessage response = await s_httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"\nUrl: `{requestUrl}`: ");
            Console.WriteLine($"\nResponse Sample: ");
            Console.WriteLine(responseBody.Substring(0, 200));

            var responseSizeByte = Encoding.UTF8.GetBytes(responseBody).Count();

            Console.WriteLine("Response Size in Bytes {0}", responseSizeByte);

            stopwatch.Stop();

            downloadSpeed.TryAdd(requestUrl, stopwatch.ElapsedMilliseconds);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request Error: {e.Message}");
        }


    }
}