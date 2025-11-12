// ### ✅ Problem 91: Simple Async Downloader

// **Concepts:** `async/await`, `HttpClient`, `I/O`

// **Instructions:**
// * Write an asynchronous method that downloads the HTML content of a given URL.
// * Display the size (in bytes) and first 200 characters of the response.

// 📝 **Bonus:** Allow downloading multiple URLs in sequence asynchronously.


using System.Net.Http;
using System.Text;

class SimpleAsyncDownloader
{
    private static readonly HttpClient s_httpClient = new HttpClient();

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

            var downloadTasks = urls.Select(url => DownloadHTML(url)).ToList();

            await Task.WhenAll(downloadTasks);

            Console.WriteLine("\nDownload Complete.");
            
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

            HttpResponseMessage response = await s_httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"\nUrl: `{requestUrl}`: ");
            Console.WriteLine($"\nResponse Sample: ");
            Console.WriteLine(responseBody.Substring(0, 200));

            var responseSizeByte = Encoding.UTF8.GetBytes(responseBody).Count();

            Console.WriteLine("Response Size in Bytes {0}", responseSizeByte);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request Error: {e.Message}");
        }


    }
}