// * Create an `Employee` class with properties: `Name`, `Age`, `Salary`.
// * Validate inside setters:

//   * `Age` must be > 18
//   * `Salary` > 0
// * Use a constructor for initialization and display details via a method.

// 📝 *Bonus:* Add a static field to count total employees created.


class Employee
{
    private string _name;
    private int _age;
    private int _salary;
    public static int EmployeeCount = 0;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Age
    {
        get { return _age; }
        set
        {
            if (value > 18)
            {
                _age = value;
            }
            else
            {
                Console.WriteLine("Age must be > 18");
            }

        }
    }
    public int Salary
    {
        get { return _salary; }
        set
        {
            if (value > 0)
            {
                _salary = value;
            }
            else
            {
                Console.WriteLine("Salary must be > 0");
            }

        }
    }
    public Employee(string name, int age, int salary)
    {
        Name = name;
        Age = age;
        Salary = salary;

        ++EmployeeCount;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine($"Employee count: {Employee.EmployeeCount}");
        Employee e = new Employee("Adam", 18, 100);
        e.Salary = 0;
        e.Age = 10;
        e.Salary = 9000;
        e.Age = 25;
        Console.WriteLine($"Employee count: {Employee.EmployeeCount}");
    }
}

// // Note:
// 1. could add a disply method
// 2. currently even if validation fails in setter the object is created. to prevent it we could use c# exceptions.