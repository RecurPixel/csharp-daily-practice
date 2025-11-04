// ### ✅ Problem 66: JSON CRUD Operations

// **Concepts:** Read/Write JSON, File Handling, LINQ Updates

// **Instructions:**
// * Create a small menu-based program that allows:
//   * Adding a record
//   * Updating a record
//   * Deleting a record
//   * Saving data back to JSON

// 📝 **Bonus:** Use `try-finally` to ensure file closure and show user-friendly messages.


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


class JSONCRUD
{
    public const string FileName = "Employee_Records.json";

    private List<Employee> _employeeRecords;
    public JSONCRUD()
    {
        _employeeRecords = new List<Employee>();
        LoadRecords();
    }

    private void LoadRecords()
    {
        try
        {
            string fileData = File.ReadAllText(FileName, Encoding.UTF8);
            _employeeRecords = JsonSerializer.Deserialize<List<Employee>>(fileData);
            Console.WriteLine($"\nData Loaded from file {FileName}");
            return;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"\nFile `{FileName}` Not Found. Continuing Opesation without loading. Details: {ex.Message} ");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"\nError: Invalid Json. Discription: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Something Went Wrong. Details: {ex.Message}");
        }
    }

    private void Add()
    {
        string name;
        string contact;

        Console.Write("\nEnter Name: ");
        while (String.IsNullOrWhiteSpace(name = Console.ReadLine()))
        {
            Console.Write("Invalid Name. Try Agrain: ");
        }
    }

    private void Remove()
    {

    }
    private void Update()
    {

    }
    
    private void Save()
    {
        
    }


    public static void Main()
    {
        JSONCRUD handler = new JSONCRUD();

        bool keepAlive = true;

        while (keepAlive)
        {

            try
            {
                Console.WriteLine("\n---Employee Menu---\n");
                Console.WriteLine(" > Add: 1");
                Console.WriteLine(" > Remove: 2");
                Console.WriteLine(" > Update: 3");
                Console.WriteLine(" > Save and Exit: 0");

                if(!int.TryParse(Console.ReadLine(), out var input))
                {
                    Console.WriteLine("Invalid Input! Try Again.");
                    continue;
                }
                switch(input)
                {
                    case 1: 
                        handler.Add();
                        break;
                    case 2: 
                        handler.Remove();
                        break;
                    case 3: 
                        handler.Update();
                        break;
                    case 0:
                        handler.Save();
                        keepAlive = false;
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: Something Went Wrong. Details: {ex.Message}");
            }
            finally
            {
                handler.Show();
            }

        }
    }
}