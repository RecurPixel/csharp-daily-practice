// ### ✅ Problem 65: JSON Deserializer and Query

// **Concepts:** `JsonSerializer.Deserialize`, LINQ on deserialized objects

// **Instructions:**
// * Deserialize the employee file created in the previous problem.
// * Filter and print all employees whose salary is above a user-specified threshold.

// 📝 **Bonus:** Gracefully handle `FileNotFoundException` and malformed JSON using exception handling.

using System.Text.Json;
using System.Text;

enum JobPosition
{
    Developer, Tester, DevOps, BDE, Manager, CFO, CTO, CEO
}

class Employee
{
    private static double _baseSalary = 7500;
    public int ID { get; init; }
    public string? Name { get; set; }
    public JobPosition Position { get; set; }
    public double? Salary { get; set; }

    public Employee(int id, string? name, JobPosition position, double? salary)
    {
        this.ID = id;
        this.Name = name ?? "N/A";
        this.Position = position;
        this.Salary = salary ?? _baseSalary;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Position: {Position}, Salary: {Salary:F2}";
    }
}

class JSONPractice
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>();

        Console.Write("\nEnter Json file name: ");
        string fileName = Console.ReadLine();

        // 1. Get user input for the minimum salary threshold
        double threshold = 0;
        Console.Write("\nEnter minimum salary threshold to view: ");

        // Basic validation for numeric input
        while (!double.TryParse(Console.ReadLine(), out threshold) || threshold < 0)
        {
            Console.Write("Invalid input. Please enter a positive salary number: ");
        }
        
        try
        {

            string JsonString = File.ReadAllText(fileName, Encoding.UTF8);
            employees = JsonSerializer.Deserialize<List<Employee>>(JsonString);

        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"\nError: File not found at path: {fileName}.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"\nError: Invalid Json. Discription: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: Something Went Wrong. Discription: {ex.Message}");
        }

        var filteredEmployee = employees.Where(e => e.Salary.HasValue && e.Salary.Value > threshold).OrderByDescending(e => e.Salary);

        foreach (var e in filteredEmployee)
        {
            Console.WriteLine(e.ToString());
        }
    }
}