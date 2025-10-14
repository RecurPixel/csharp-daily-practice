// * Create a `Calculator` class with multiple `Add()` methods:

//   * `Add(int, int)`
//   * `Add(double, double)`
//   * `Add(int, int, int)`
// * Call all variants to show overloading.

// 📝 *Bonus:* Add an `Add(params int[] numbers)` version.


class Calculator
{
    public static void Add(int a, int b)
    {
        Console.WriteLine($"{a} + {b} = {a + b}");
    }
    public static void Add(double a, double b)
    {
        Console.WriteLine($"{a} + {b} = {a + b}");
    }
    public static void Add(int a, int b, int c)
    {
        Console.WriteLine($"{a} + {b} + {c} = {a + b + c}");
    }

    public static void Add(params int[] nums)
    {
        if(nums.Length == 0)
        {
            Console.WriteLine("There is nothing to add.");
            return;
        }
        string s = String.Join(" + ", nums);
        Console.WriteLine($"{s} = {nums.Sum()}");
    }
    
    public static void Main(string[] args)
    {
        Calculator.Add(1,2);
        Calculator.Add(1,2,3);
        Calculator.Add(1.2, 23.4);
        Calculator.Add(1, 2, 3, 4, 5);
        Calculator.Add(1);
        Calculator.Add();
                                
    }
}