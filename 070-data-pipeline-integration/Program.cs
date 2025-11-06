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
        this.Name = Name ?? "N/A";
        this.Email = Email ?? "N/A";
        this.Age = Age ?? 0;
    }

    public override string ToString()
    {
        return $"{ID,-15}{Name,15}{Email,30},{Age,45}";
    }

}


class DataExtractor
{
    private string _matchPattern, _inputFile;
    private List<Person> _people;

    public DataExtractor(string pattern, string inputFile)
    {
        _matchPattern = pattern;
        _inputFile = inputFile;
        _people = new List<Person>();
    }

    private void ExtractFromFile()
    {
        if (!File.Exists(_inputFile))
        {
            Console.WriteLine($"\nError: File does not exit. File: {_inputFile}");
        }

        try
        {
            string jsonStringFromFile = File.ReadAllText(_inputFile);

                    string pattern = @"
        (?xsi)
        (?<Record>
            (?<Name>
                (?:
                    \*\*(?<InnerName>[^*]+?)\*\*       # **Name**
                    |
                    ['""](?<InnerNameQ>[^'""]+?)['""] 
                )
            )
            (?<Details>
                (?:
                    (?!\*\*|['""])                     # Stop before next name marker
                    .
                )*?
            )
        )";

        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

        Regex emailRegex = new Regex(@"[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}", RegexOptions.IgnoreCase);
        Regex ageRegex = new Regex(@"(?:(?:Age\s*(?:is)?|He is|She is|Her Age is)\s*(?<Age>\d{1,2}))", RegexOptions.IgnoreCase);

            foreach (Match m in regex.Matches(jsonStringFromFile))
            {
                string name = m.Groups["InnerName"].Success ? m.Groups["InnerName"].Value : m.Groups["InnerNameQ"].Value;
                string details = m.Groups["Details"].Value;

                string email = emailRegex.Match(details).Value;
                string age = ageRegex.Match(details).Groups["Age"].Value;

                Console.WriteLine("--------");
                Console.WriteLine($"Name: {name}");
                if (!string.IsNullOrEmpty(email))
                    Console.WriteLine($"Email: {email}");
                if (!string.IsNullOrEmpty(age))
                    Console.WriteLine($"Age: {age}");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"\nERROR loading file: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERROR loading file: {ex.Message}");
        }
        return;
    }

    private string ToJson()
    {
        string jsonString = JsonSerializer.Serialize(_people, new JsonSerializerOptions { WriteIndented = true });
        return jsonString;
    }

    public static void Main()
    {
        string fileName = "./data-unstructured-sample.txt";
        string pattern = @"Record\s\d+\.*(\*\*\w\s\w\*\*)";

        DataExtractor dataExtractor = new DataExtractor(pattern, fileName);
        dataExtractor.ExtractFromFile();
        // dataExtractor.ToJson();

    }
}