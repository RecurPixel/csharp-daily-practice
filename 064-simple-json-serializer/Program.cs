// ### ✅ Problem 64: Simple JSON Serializer

// **Concepts:** `System.Text.Json`, `JsonSerializer.Serialize`

// **Instructions:**
// * Serialize a list of employees into a JSON file.
// * Show a message when the file is created successfully.

// 📝 **Bonus:** Include a timestamp in the JSON file name using `DateTime.Now`.

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

    public static void SetBaseSalary(double baseSalary)
    {
        _baseSalary = baseSalary;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Position: {Position}, Salary: {Salary:F2}";
    }

}

class JSONPractice
{
    private static int _id = 10001;
    private const string FileName = "employees.json";
    
    public static void Main()
    {
        List<Employee> employees = new List<Employee>();

        Random r = new Random();

        for (int i = 0; i < r.Next(20); i++)
        {
            employees.Add(new Employee(_id++, Faker.Name.FullName(), (JobPosition)r.Next(8), r.NextDouble() * 1000));
        }


        string employeeString = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(employeeString);


        var fName = $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{FileName}";

        // byte[] buffer = Encoding.UTF8.GetBytes(employeeString);
        // using (FileStream fs = new FileStream(fName, FileMode.OpenOrCreate))
        // {
        //     using (BufferedStream bs = new BufferedStream(fs))
        //     {
        //         foreach (byte b in buffer)
        //         {
        //             bs.WriteByte(b);
        //         }
        //     }
        // }

        File.WriteAllText(fName, employeeString, Encoding.UTF8);

        Console.WriteLine($"File `{fName}` is Saved latest Data.");
    }
}