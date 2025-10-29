// **Concepts:** `delegate`, `method reference`, `invocation`

// * Define a delegate that takes two integers and returns their sum.
// * Create a static method that performs the addition.
// * Assign the method to the delegate and invoke it.

// **📝 Bonus:**
// Display the method name being invoked using `Delegate.Method.Name`.


class DelegatePractice
{
    public delegate int SumDelegate(int a, int b);

    public static int Addition(int a, int b)
    {
        Console.WriteLine("Addition Ran");
        return a + b;
    }

    public static void Main()
    {
        SumDelegate sD = Addition;
        int a = 2, b = 3;

        var output = sD.Invoke(a, b);

        Console.WriteLine($"Delegate Method Invoked: {sD.Method.Name}");
        Console.WriteLine($"{a} + {b} = {output}");
    }
}
