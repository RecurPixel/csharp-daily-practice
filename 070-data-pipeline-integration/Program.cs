// ### ✅ Problem 70: Data Pipeline Integrator

// **Concepts:** LINQ + JSON + Regex + Exception Handling Integration

// **Instructions:**
// * Build a small data pipeline that:
//   1. Reads unstructured text from a `.txt` file (containing names, emails, and ages)
//   2. Extracts structured info using **Regex**
//   3. Converts data into objects and serializes them as **JSON**
//   4. Queries the final data with **LINQ** for specific results

// 📝 **Bonus:** Add progress notifications using events or delegates from Level 5.


using System.Text.Json;
using System.Text.RegularExpressions;

struct Person
{
    public int ID { get; init; }
    public string? Name { get; init; }
    public string? Email { get; init; }
    public int? Age { get; init; }

    public Person(int ID, string? Name, string? Email, int? Age)
    {
        this.ID = ID;
        this.Name = Name;
        this.Email = Email;
        this.Age = Age ?? 0;
    }

    public override string ToString()
    {
        return $"{ID,-15}{Name,15}{Email ?? "N/A",30},{Age,45}";
    }

}



class DataPipeline
{
    private static DataExtractor _dataExtractor;
    public static void Manager_ExtractionComplete(object sender, EventArgs e)
    {
        _dataExtractor.ShowCompleteRecords();

        Console.WriteLine(_dataExtractor.ToJson());

        Console.WriteLine("\nExtraction Complete.");
    }

    public static void Main()
    {
        string fileName = "./data-unstructured-sample.txt";
        string pattern = @"Record\s\d+\.*(\*\*\w\s\w\*\*)";

        _dataExtractor = new DataExtractor(pattern, fileName);
        _dataExtractor.ExtractionComplte += Manager_ExtractionComplete;

        _dataExtractor.ExtractFromFile();

    }
}

class DataExtractor
{

    public event EventHandler ExtractionComplte;

    private string _matchPattern, _inputFile;
    private int _nextID = 10001;
    private List<Person> _people;

    public DataExtractor(string pattern, string inputFile)
    {
        _matchPattern = pattern;
        _inputFile = inputFile;
        _people = new List<Person>();
    }

    private void ProcessWithTwoPassPattern(string data, string pattern)
    {
        var matches = Regex.Matches(data, pattern, RegexOptions.Singleline);

        Console.WriteLine($"Found {matches.Count} records:\n");

        foreach (Match match in matches)
        {
            string name = match.Groups["Name"].Value.Trim();
            string block = match.Groups["Block"].Value;

            // Second pass: Extract email and age from the block
            string emailPattern = @"([a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,})";
            string agePattern = @"(?:Age[:\s]+(\d{1,3})|\b(\d{2})\b(?!\d))";

            var emailMatch = Regex.Match(block, emailPattern);
            var ageMatches = Regex.Matches(block, agePattern);

            string? email = emailMatch.Success ? emailMatch.Groups[1].Value : null;

            // Get the last age match (more reliable for this format)
            int age = 0;
            if (ageMatches.Count > 0)
            {
                // Try to find age with "Age:" prefix first
                foreach (Match am in ageMatches)
                {
                    if (am.Groups[1].Success)
                    {
                        age = int.Parse(am.Groups[1].Value);
                        break;
                    }
                }
                // If not found, use standalone number
                if (age == 0)
                {
                    foreach (Match am in ageMatches)
                    {
                        if (am.Groups[2].Success)
                        {
                            age = int.Parse(am.Groups[2].Value);
                        }
                    }
                }
            }

            _people.Add(new Person(_nextID++, name, email, age));

            // Console.WriteLine($"ID: {_nextID - 1}");
            // Console.WriteLine($"Name:  {name}");
            // Console.WriteLine($"Email: {email}");
            // Console.WriteLine($"Age:   {age}");
            // Console.WriteLine(new string('-', 50));
        }
    }

    internal void ExtractFromFile()
    {
        if (!File.Exists(_inputFile))
        {
            Console.WriteLine($"\nError: File does not exit. File: {_inputFile}");
        }

        try
        {
            string jsonStringFromFile = File.ReadAllText(_inputFile);

            string pattern = @"\*\*(?<Name>[^*]+)\*\*(?<Block>.*?)(?=Record\s+\d+|--- END|$)";
            ProcessWithTwoPassPattern(jsonStringFromFile, pattern);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"\nERROR loading file: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERROR loading file: {ex.Message}");
        }

        Thread.Sleep(5000); // Simulate Processing Time;
        OnExtractionComplete();
    }

    internal string ToJson()
    {
        string jsonString = JsonSerializer.Serialize(_people, new JsonSerializerOptions { WriteIndented = true });
        return jsonString;
    }

    internal void ShowCompleteRecords()
    {
        var completeRecords = _people.Where(p => p.Age > 0 && !String.IsNullOrEmpty(p.Email));

        Console.WriteLine("\nPeople with All Date:");
        foreach (var r in completeRecords)
        {
            Console.WriteLine(r);
        }
    }

    protected virtual void OnExtractionComplete()
    {
        ExtractionComplte?.Invoke(this, EventArgs.Empty);
    }
}