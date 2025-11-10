// ### ✅ Problem 80: Async Data Pipeline

// **Concepts:** Combining async + LINQ + JSON

// **Instructions:**
// * Simulate fetching JSON data asynchronously (use delay).
// * Deserialize it and process it using LINQ queries while keeping the UI responsive (console messages).

// 📝 **Bonus:** Use `ConfigureAwait(false)` and explain its purpose in comments.

using System.Net.Http;
using System.Text.Json;

class Post
{
    public int id { get; init; }
    public string title { get; init; }
    public string body { get; init; }
    public int userId { get; init; }

    public Post() { }

    public override string ToString()
    {
        return $"Post ID: {id,-15}\nTitle: {title}\n Body: {body}\nUser ID: {userId}";
    }
}

class AsyncDataPractice
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task Main()
    {
        var progress = new Progress<string>(message => Console.WriteLine(message));

        var data = await FetchJsonData(progress).ConfigureAwait(false);

        if (data != null)
        {
            var pageData = data.Take(10);

            foreach (var post in pageData)
            {
                Console.WriteLine(post);
                Console.WriteLine("\n------\n");
            }
        }

        return;
    }

    private static async Task<List<Post>> FetchJsonData(IProgress<string> progress)
    {
        string apiUrl = "https://jsonplaceholder.typicode.com/posts";
        List<Post> posts = null;
        try
        {
            // Make an asynchronous GET request to the API
            progress.Report("Sending API call.");
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            progress.Report("API Response Recieved");

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            progress.Report("API returned Success Status code");

            // Read the response content as a string
            string responseBody = await response.Content.ReadAsStringAsync();

            progress.Report("Reading Response Content");

            posts = JsonSerializer.Deserialize<List<Post>>(responseBody);

            progress.Report("Deserialize API Data");
        }
        catch (HttpRequestException e)
        {
            progress.Report($"Request exception: {e.Message}");
        }
        catch (Exception e)
        {
            progress.Report($"An unexpected error occurred: {e.Message}");
        }

        return posts;

    }
}


// Note: .ConfigureAwait(false)
// ConfigureAwait(false) tells the runtime not to capture the current synchronization context (like the UI thread). This allows the continuation of the method (the code after await) to run on any available thread pool thread, which is more efficient for library methods or non-UI code. If set to true (the default), it forces the continuation to jump back to the original thread, which is necessary only for UI updates.