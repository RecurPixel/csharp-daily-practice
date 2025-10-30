// **Concepts:** combining delegates with collections

// * Given a list of employee objects (Name, Age, Salary):

//   * Use a delegate or lambda to sort employees by salary.
//   * Use another delegate to filter employees older than 30.

// **📝 Bonus:**
// Use `List<T>.FindAll()` and `Comparison<T>` delegate.

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Salary { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Age = 26, Name = "John", Salary = 1000 },
            new Employee { Age = 22, Name = "Mark"  , Salary = 900},
            new Employee { Age = 41, Name = "Ken" , Salary = 1100}
        };

        // Using a lambda expression for the Comparison<T> delegate
        employees.Sort((x, y) => x.Salary.CompareTo(y.Salary));

        Console.WriteLine("Sorted By Salary");
        foreach (var emp in employees)
        {
            Console.WriteLine($"Age: {emp.Age}, Name: {emp.Name}, Salary: {emp.Salary}");
        }

        // Using a lambda expression for Employee older than 30
        
        Console.WriteLine("\nEmployee Older Than 30");
        foreach (var emp in employees.FindAll(x => x.Age > 30))
        {
            Console.WriteLine($"Age: {emp.Age}, Name: {emp.Name}, Salary: {emp.Salary}");
        }
    }
}